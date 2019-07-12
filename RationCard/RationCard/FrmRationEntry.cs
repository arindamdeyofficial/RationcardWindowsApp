using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Helper;
using RationCard.Model;
using System.Configuration;
using RationCard.Helper;

namespace RationCard
{    
    public partial class FrmRationEntry : Form
    {
        int _totalHofCount = 0;
        int _converted = 0;
        public List<Hof> _hofList = new List<Hof>();
        public List<Category> _catList = new List<Category>();
        public List<RelationMaster> _hofRelation = new List<RelationMaster>();
        public List<RelationMaster> _relation = new List<RelationMaster>();
        public List<DocumentType> _docType = new List<DocumentType>();
        public List<Category> _catWiseCount = new List<Category>();
        private bool _cardExists, _adharExists, _mobileNoexists;
        string _cat = "";

        public FrmRationEntry()
        {
            InitializeComponent();
            lblSupportMsg.Text = ConfigurationManager.AppSettings["SupportMsg"].ToString();
            lblIsEdit.Text = "";
            lblCardCatId.Text = "";
            lblRationCardId.Text = "";
            lblCustId.Text = "";

            //picNetwork.Visible = false; //if don't deliver internet icon functionality
            Network.CheckForInternet(InternetStatusChange);
        }
        private void InternetStatusChange(bool isconnected)
        {
            try
            {
                if ((!picNetwork.IsDisposed) && (picNetwork.InvokeRequired))
                {
                    Invoke(new Action(() =>
                    {
                        picNetwork.Visible = isconnected;
                    }));
                }
                else
                {
                    picNetwork.Visible = isconnected;
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        

        private void FrmRationEntry_Load(object sender, EventArgs e)
        {
            FetchFormData();
            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "MM-dd-yyyy";
        }

        private void FetchFormData()
        {
            try
            {
                _totalHofCount = MasterData.TotalHofCount;
                txtTotalHof.Text = MasterData.TotalHofCount.ToString();
                _hofList = MasterData.Hofs;
                cmbHof.DataSource = _hofList;
                cmbHof.DisplayMember = "ShowVal";
                cmbHof.ValueMember = "Customer_Id";
                cmbHof.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbHof.AutoCompleteSource = AutoCompleteSource.ListItems;
                
                _catList = MasterData.Categories;
                _cat = cmbCat.Text;
                cmbCat.DataSource = _catList;
                cmbCat.DisplayMember = "Cat_Desc";
                cmbCat.ValueMember = "Cat_Id";
                if (_cat != "")
                {
                    cmbCat.Text = _cat;
                }
                _hofRelation = MasterData.Relations;
                _relation = MasterData.Relations;
                cmbRelHof.DataSource = _hofRelation;
                cmbRelHof.DisplayMember = "Relation";
                cmbRelHof.ValueMember = "Mst_Rel_With_Hof_Id";

                cmbRel.DataSource = _relation;
                cmbRel.DisplayMember = "Relation";
                cmbRel.ValueMember = "Mst_Rel_With_Hof_Id";

                cmbRelHof.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbRelHof.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbRel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbRel.AutoCompleteSource = AutoCompleteSource.ListItems;

                //SetCardCount
                //txtTotalCards.Text = hofObj.TotalCardCount.ToString();
                //txtTotalActiveCards.Text = hofObj.TotalActiveCardCount.ToString();
                //txtHofCardNo.Text = hofObj.CardNo;
                //txtTotalHof.Text = _totalHofCount.ToString();
                //txtMobileNo.Text = hofObj.Mobile_No;
                //txtAddress.Text = hofObj.Address;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSingleCard singleCard = new FrmSingleCard();
                singleCard.Show();
                singleCard.Controls["txtCat"].Text = cmbCat.Text;
                singleCard.Controls["txtRationCardNo"].Text = txtCardNo.Text;
                singleCard.Controls["txtAdhar"].Text = txtAdharOrEpic.Text;
                singleCard.Controls["txtHof"].Text = cmbHof.Text;
                singleCard.Controls["txtCardHolderName"].Text = txtCardHolderName.Text;
                singleCard.Controls["txtRelHof"].Text = cmbRelHof.Text;
                singleCard.Controls["txtFatherName"].Text = txtFatherName.Text;
                singleCard.Controls["txtAge"].Text = txtAge.Text;
                singleCard.Controls["txtAddress"].Text = txtAddress.Text;
                singleCard.Controls["txtInactive"].Text = chkActive.Checked ? "Active" : "Inactive";
                singleCard.Controls["txtTotalCards"].Text = txtTotalCards.Text;
                singleCard.Controls["txtActiveCards"].Text = txtTotalActiveCards.Text;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void entryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmRationEntry();
        }

        private void chkHof_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkHof.Checked)
            {
                Hof hofObj = _hofList.FirstOrDefault();
                cmbHof.SelectedIndex = 0;
                cmbHof.SelectedText = hofObj.Name + " || " + hofObj.CardNo + " || " + hofObj.Mobile_No;
                cmbHof.SelectedValue = _hofList.FirstOrDefault().Customer_Id;
            }
            else
            {
                PopulateHofDetails();
            }
        }      
        private void PopulateHofDetails()
        {
            try
            {
                cmbHof.Text = txtCardHolderName.Text + " || " + cmbCat.Text + "-" + txtCardNo.Text + " || " + txtMobileNo.Text;
                Hof hof = _hofList.FirstOrDefault(i => (i.Name == txtCardHolderName.Text) && ((txtCardNo.Text != "") ? (i.CardNo == txtCardNo.Text) : true));
                txtTotalActiveCards.Text = (hof != null) ? hof.TotalActiveCardCount.ToString() : "";
                txtHofCardNo.Text = (hof != null) ? hof.CardNo : "";
                txtTotalCards.Text = (hof != null) ? hof.TotalCardCount.ToString() : "";
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }  
        private void chkHof_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                chkHof.Checked = !chkHof.Checked;
            }
        }

        private void txtCardHolderName_TextChanged(object sender, EventArgs e)
        {
            if(chkHof.Checked)
            {
                PopulateHofDetails();
            }
        }

        private void cmbHof_SelectedIndexChanged(object sender, EventArgs e)
        {
            HofChange();
        }

        private void HofChange()
        {
            try
            {
                string hofValue = "";
                Hof hofObj = new Hof();

                if (cmbHof.SelectedValue.ToString() == "RationCard.Model.Hof")
                {
                    hofValue = ((Hof)cmbHof.SelectedValue).Customer_Id;
                }
                else
                {
                    hofValue = cmbHof.SelectedValue.ToString();
                }
                
                hofObj = _hofList.Find(i => i.Customer_Id == hofValue);

                txtTotalCards.Text = hofObj.TotalCardCount.ToString();
                txtTotalActiveCards.Text = hofObj.TotalActiveCardCount.ToString();
                txtHofCardNo.Text = hofObj.CardNo;
                txtTotalHof.Text = _totalHofCount.ToString();
                txtMobileNo.Text = hofObj.Mobile_No;
                txtAddress.Text = hofObj.Address;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All changes will be lost. To Save click No and save. To proceed click Yes.", "Form will be Reset", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                txtMsg.Text = "";
                ResetForm();
            }            
        }

        private void ResetForm()
        {
            try
            {
                _cat = cmbCat.Text;
                btnDelete.Enabled = false;
                ResetAllControls(groupBox1);
                ResetAllControls(groupBox3);
                ResetAllControls(panel2);
                dateTimePicker1.Value = DateTime.Now;
                chkActive.Checked = true;
                txtTotalHof.Text = _totalHofCount.ToString();
                lblIsEdit.Text = "";
                lblCardCatId.Text = "";
                lblRationCardId.Text = "";
                lblCustId.Text = "";
                cmbCat.Text = _cat;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        
        public void ResetAllControls(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }

                if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.ClearSelected();
                }
            }
        }
        private void Save()
        {
            try
            {
                //Logger.LogInfo(dateTimePicker1.Value.ToString());
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "MM-dd-yyyy";

                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@userId", SqlDbType = SqlDbType.VarChar, Value = User.LoginId });
                sqlParams.Add(new SqlParameter { ParameterName = "@mac", SqlDbType = SqlDbType.VarChar, Value = User.MacId });
                sqlParams.Add(new SqlParameter { ParameterName = "@rationCardId", SqlDbType = SqlDbType.VarChar, Value = lblRationCardId.Text });
                sqlParams.Add(new SqlParameter { ParameterName = "@categoryId", SqlDbType = SqlDbType.VarChar, Value = cmbCat.SelectedValue });
                sqlParams.Add(new SqlParameter { ParameterName = "@categoryDesc", SqlDbType = SqlDbType.VarChar, Value = cmbCat.Text });
                sqlParams.Add(new SqlParameter { ParameterName = "@CardNo", SqlDbType = SqlDbType.VarChar, Value = cmbCat.Text + "-" + txtCardNo.Text });
                sqlParams.Add(new SqlParameter { ParameterName = "@customerId", SqlDbType = SqlDbType.VarChar, Value = lblCustId.Text });
                sqlParams.Add(new SqlParameter { ParameterName = "@adhar", SqlDbType = SqlDbType.VarChar, Value = txtAdharOrEpic.Text });
                sqlParams.Add(new SqlParameter { ParameterName = "@cardHolderName", SqlDbType = SqlDbType.VarChar, Value = txtCardHolderName.Text });
                sqlParams.Add(new SqlParameter { ParameterName = "@isHof", SqlDbType = SqlDbType.VarChar, Value = chkHof.Checked ? "1" : "0" });
                sqlParams.Add(new SqlParameter { ParameterName = "@hofId", SqlDbType = SqlDbType.VarChar, Value = chkHof.Checked ? lblCustId.Text : "" });
                sqlParams.Add(new SqlParameter { ParameterName = "@hofName", SqlDbType = SqlDbType.VarChar, Value = cmbHof.Text.Split(new string[] { "||" }, StringSplitOptions.None)[0].Trim() });
                sqlParams.Add(new SqlParameter { ParameterName = "@RelWithHofId", SqlDbType = SqlDbType.VarChar, Value = ((cmbRelHof.SelectedValue != null) ? cmbRelHof.SelectedValue : "") });
                sqlParams.Add(new SqlParameter { ParameterName = "@RelWithHofDesc", SqlDbType = SqlDbType.VarChar, Value = cmbRelHof.Text });
                sqlParams.Add(new SqlParameter { ParameterName = "@FatherName", SqlDbType = SqlDbType.VarChar, Value = txtFatherName.Text });
                sqlParams.Add(new SqlParameter { ParameterName = "@typeOfRelationId", SqlDbType = SqlDbType.VarChar, Value = ((cmbRel.SelectedValue != null) ? cmbRel.SelectedValue : "") });
                sqlParams.Add(new SqlParameter { ParameterName = "@typeOfRelationDesc", SqlDbType = SqlDbType.VarChar, Value = cmbRel.Text });
                sqlParams.Add(new SqlParameter { ParameterName = "@activeOrInactiveDt", SqlDbType = SqlDbType.VarChar, Value = dateTimePicker1.Value.ToString() });
                sqlParams.Add(new SqlParameter { ParameterName = "@mobileNo", SqlDbType = SqlDbType.VarChar, Value = txtMobileNo.Text });
                sqlParams.Add(new SqlParameter { ParameterName = "@age", SqlDbType = SqlDbType.VarChar, Value = txtAge.Text });
                sqlParams.Add(new SqlParameter { ParameterName = "@isActive", SqlDbType = SqlDbType.VarChar, Value = chkActive.Checked ? "1" : "0" });
                sqlParams.Add(new SqlParameter { ParameterName = "@address", SqlDbType = SqlDbType.VarChar, Value = txtAddress.Text });
                sqlParams.Add(new SqlParameter { ParameterName = "@remarks", SqlDbType = SqlDbType.VarChar, Value = txtRemarks.Text });

                DataSet ds = ConnectionManager.Exec("Sp_RationCard_Save", sqlParams);
                if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    bool isSuccess = true; ;
                    string isInputSuccess = ds.Tables[0].Rows[0][0].ToString();
                    string cardMsg = ds.Tables[0].Rows[0][1].ToString();
                    string custMsg = ds.Tables[0].Rows[0][2].ToString();
                    if (isInputSuccess.Contains("FAILURE"))
                    {
                        txtMsg.Text += isInputSuccess;
                        isSuccess = false;
                    }
                    if (cardMsg.Contains("FAILURE"))
                    {
                        txtMsg.Text += cardMsg;
                        isSuccess = false;
                    }
                    if (custMsg.Contains("FAILURE"))
                    {
                        txtMsg.Text += custMsg;
                        isSuccess = false;
                    }

                    if (isSuccess)
                    {
                        MessageBox.Show("Rationcard saved successfully.");
                        RefreshCatWiseCount();
                        ResetForm();
                        FetchFormData();
                    }
                    else
                    {
                        MessageBox.Show("Rationcard not saved due to some error. Please contact administrator.");
                    }
                }
                dateTimePicker1.Format = DateTimePickerFormat.Long;
                dateTimePicker1.CustomFormat = null;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtMsg.Text = "";
                if (lblIsEdit.Text == "1")
                {
                    string password = DialogConfirm.ShowDialog("Please provide password to continue.", "Confirm with Password");
                    string finalPass = SecurityEncrypt.Decrypt(ConfigurationManager.AppSettings["ActionConfirmPassword"].ToString(), "nakshal");

                    if (password == finalPass)
                    {
                        Save();
                    }
                    else if (password == "")
                    {
                        MessageBox.Show("Save has been canceled by user.");
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password.");
                    }
                }
                else
                {
                    Save();
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void RefreshCatWiseCount()
        {
            try
            {
                //refresh catwise count
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@userId", SqlDbType = SqlDbType.VarChar, Value = User.LoginId });
                DataSet ds = ConnectionManager.Exec("Sp_Catwise_Count", sqlParams);

                if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    _catWiseCount = ds.Tables[0].AsEnumerable().Select(i => new Category { Cat_Desc = i[1].ToString(), CardCount = i[2].ToString(), FamilyCount = i[3].ToString() }).ToList();
                    var frmObj = (FrmCatwiseCount)FormHelper.OpenFrmCatwiseCount();
                    frmObj.RefreshGrid(_catWiseCount);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                txtMsg.Text = "";
                string password = DialogConfirm.ShowDialog("Please provide password to continue.", "Confirm with Password");
                string finalPass = SecurityEncrypt.Decrypt(ConfigurationManager.AppSettings["ActionConfirmPassword"].ToString(), "nakshal");

                if (password == finalPass)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter { ParameterName = "@userId", SqlDbType = SqlDbType.VarChar, Value = User.LoginId });
                    sqlParams.Add(new SqlParameter { ParameterName = "@rationCardId", SqlDbType = SqlDbType.VarChar, Value = lblRationCardId.Text });
                    sqlParams.Add(new SqlParameter { ParameterName = "@customerId", SqlDbType = SqlDbType.VarChar, Value = lblCustId.Text });
                    DataSet ds = ConnectionManager.Exec("Sp_RationCard_Delete", sqlParams);
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                    {
                        txtMsg.Text = ds.Tables[0].Rows[0][1].ToString();
                        RefreshCatWiseCount();
                        ResetForm();
                        FetchFormData();
                    }
                }
                else if (password == "")
                {
                    MessageBox.Show("Delete has been canceled by user.");
                }
                else
                {
                    MessageBox.Show("Wrong Password.");
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshCatWiseCount(); 
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmObj = Application.OpenForms["FrmSearchResult"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmSearchResult searchResult = new FrmSearchResult(this);
                searchResult.Show();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var frmObj = Application.OpenForms["FrmSearchResult"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmSearchResult searchResult = new FrmSearchResult(this);
                searchResult.Show();
            }
        }

        public void SplitCardNo()
        {
            try
            {
                string cat = cmbCat.Text;
                string cardNo = txtCardNo.Text;
                if (cardNo.Contains("-"))
                {
                    string originalCardNo = "";
                    string category = "";
                    var ents = cardNo.Split(new String[] { "-" }, StringSplitOptions.None);
                    if (ents.Length >= 1)
                    {
                        if (ents[0] == "RKSY")
                        {
                            category = ents[0] + ents[1];
                            int count = 2;
                            while (count < ents.Length)
                            {
                                originalCardNo += ents[count];
                                count++;
                            }
                        }
                        else
                        {
                            category = ents[0];
                            int count = 1;
                            while (count < ents.Length)
                            {
                                originalCardNo += ents[count];
                                count++;
                            }
                        }
                    }
                    else
                    {
                        originalCardNo = cardNo;
                    }

                    cmbCat.Text = category;
                    txtCardNo.Text = originalCardNo;
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }      
        }

        private void chkActive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                chkActive.Checked = !chkActive.Checked;
        }

        private void txtCardNo_Leave(object sender, EventArgs e)
        {
            DuplicateCheck(cmbCat.Text + "-" + txtCardNo.Text, "RATIONCARD");
        }
        private void txtAdharOrEpic_Leave(object sender, EventArgs e)
        {
            DuplicateCheck(txtAdharOrEpic.Text, "ADHARCARD");
        }

        private void txtCardNo_TextChanged(object sender, EventArgs e)
        {
            SplitCardNo();
            if(chkHof.Checked)
                PopulateHofDetails();
        }

        private void txtCardHolderName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtMobileNo_TextChanged(object sender, EventArgs e)
        {
            if (chkHof.Checked)
            {
                PopulateHofDetails();
            }
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmObj = Application.OpenForms["FrmSearchResult"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmSearchResult searchResult = new FrmSearchResult(this);
                searchResult.Show();
            }
        }

        private void txtCardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtAdharOrEpic_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void cmbHof_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtMobileNo_Leave(object sender, EventArgs e)
        {
            DuplicateCheck(txtMobileNo.Text, "MOBILENO");
        }
        private void DuplicateCheck(string val, string checkBy)
        {
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@userId", SqlDbType = SqlDbType.VarChar, Value = User.LoginId });
                sqlParams.Add(new SqlParameter { ParameterName = "@checkName", SqlDbType = SqlDbType.VarChar, Value = checkBy });
                sqlParams.Add(new SqlParameter { ParameterName = "@param", SqlDbType = SqlDbType.VarChar, Value = val });
                DataSet ds = ConnectionManager.Exec("Sp_Unique_Check", sqlParams);
                if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[1].Rows.Count > 0))
                {
                    if (!(ds.Tables[1].Rows[0][0].ToString().Contains("SUCCESS")))
                    {
                        string msg = "";
                        foreach (DataRow r in ds.Tables[1].Rows)
                        {
                            msg += r["MSG"].ToString() + Environment.NewLine;
                        }
                        MessageBox.Show(msg);
                        switch (ds.Tables[0].Rows[0]["DUPLICATE_TYPE"].ToString())
                        {
                            case "RATIONCARD_DUPLICATE": _cardExists = true;
                                break;
                            case "ADHARCARD_DUPLICATE": _adharExists = true;
                                break;
                            case "MOBILENO_DUPLICATE": _mobileNoexists = true;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (checkBy)
                        {
                            case "RATIONCARD":
                                _cardExists = false;
                                break;
                            case "ADHARCARD":
                                _adharExists = false;
                                break;
                            case "MOBILENO":
                                _mobileNoexists = false;
                                break;
                            default:
                                break;
                        }
                    }
                    if (_cardExists || _adharExists)
                        btnSave.Enabled = false;
                    else
                        btnSave.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
