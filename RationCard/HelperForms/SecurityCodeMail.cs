using RationCard.Helper;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace RationCard.HelperForms
{
    public partial class SecurityCodeMail : Form
    {
        List<SecurityCode> _codes = new List<SecurityCode>();
        public SecurityCodeMail()
        {
            InitializeComponent();
        }

        private void SecurityCodeMail_Load(object sender, EventArgs e)
        {
            _codes.Clear();
            _codes.AddRange(OprateSecurityCodes(string.Empty, string.Empty, "GET"));
            BindCodeData();
        }

        private void cmbEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            var select = cmbEmails.SelectedItem;
            if(select != null)
            {
                SecurityCode selectedCode = (SecurityCode)cmbEmails.SelectedItem;
                if(selectedCode !=null)
                {
                    SecurityCode searchedCode = _codes.FirstOrDefault(a => a.Security_Code_Identity
                                    == selectedCode.Security_Code_Identity);
                    if(searchedCode!= null)
                    {
                        txtCode.Text = searchedCode.Security_Code_In_Mail;
                    }
                }
            }
        }

        private void btnSendSecurityCode_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(txtEmailId.Text.Trim()))
                && (!string.IsNullOrEmpty(txtMobileNo.Text.Trim())))
            {
                string statusMsg = "";
                bool isSuccess;
                string mobileNo = txtMobileNo.Text.Trim();
                string emailId = txtEmailId.Text.Trim();
                string code = GenerateSecurityCode(emailId);
                txtCode.Text = code;
                try
                {
                    EmailHelper.SendSecurityCode(emailId, code, out isSuccess);
                    SmsHelper.SendSms("Your security code for initial setup: " + Environment.NewLine + code, mobileNo, out statusMsg);
                    if (isSuccess)
                    {
                        _codes.Clear();
                        _codes.AddRange(OprateSecurityCodes(emailId, code, "ADD"));
                        BindCodeData();
                    }
                }
                catch(Exception ex)
                {
                    Logger.LogError(ex);
                }
                
            }
            else
            {
                MessageBox.Show("Please enter a email");
            }
        }
        private string GenerateSecurityCode(string email)
        {
            DateTime dt = DateTime.Now;
            return SecurityEncrypt.Encrypt(dt.Day.ToString() + dt.Month.ToString() + dt.Year.ToString() + dt.Hour.ToString() 
                                + dt.Minute.ToString() + dt.Second.ToString() + email, "nakshal");
        }        

        private List<SecurityCode> OprateSecurityCodes(string email, string code, string operation)
        {
            List<SecurityCode> codes = new List<SecurityCode>();
            try
            {               
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Email", SqlDbType = SqlDbType.VarChar, Value = email });
                sqlParams.Add(new SqlParameter { ParameterName = "@Code", SqlDbType = SqlDbType.VarChar, Value = code });
                sqlParams.Add(new SqlParameter { ParameterName = "@operation", SqlDbType = SqlDbType.VarChar, Value = operation });

                DataSet ds = ConnectionManager.Exec("Sp_Security_Code_Get_Add", sqlParams);

                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    codes.AddRange(ds.Tables[0].AsEnumerable().Select(i => new SecurityCode
                    {
                        Security_Code_Identity = i["Security_Code_Identity"].ToString(),
                        Security_Code_In_Mail = i["Security_Code_In_Mail"].ToString(),
                        Mail_Id = i["Mail_Id"].ToString(),
                        Created_Date = i["Created_Date"].ToString()
                    }));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return codes;
        }

        private void btnRemoveSecurityCode_Click(object sender, EventArgs e)
        {
            if (cmbEmails.Items.Count > 0)
            {
                string emailId = ((SecurityCode)cmbEmails.SelectedItem).Mail_Id;
                _codes.Clear();
                _codes.AddRange(OprateSecurityCodes(emailId, string.Empty, "REMOVE"));
                BindCodeData();
            }
        }
        private void BindCodeData()
        {
            cmbEmails.DataSource = null;           
            cmbEmails.DataSource = _codes;
            cmbEmails.DisplayMember = "Mail_Id";
            cmbEmails.ValueMember = "Security_Code_Identity";

            if (cmbEmails.Items.Count > 0)
            {
                cmbEmails.SelectedIndex = 0;
            }
        }
    }
}
