using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using RationCard.Model;
using System.Configuration;
using RationCard.Helper;
using RationCard.MasterDataManager;
using RationCard.DbSaveFireAndForget;

namespace RationCard
{    
    public partial class FrmRationEntry : Form
    {
        int _totalHofCount = 0;
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
                //Logger.LogError(ex);
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
                _hofList = MasterData.Hofs.Data;
                cmbHof.DataSource = _hofList;
                cmbHof.DisplayMember = "ShowVal";
                cmbHof.ValueMember = "Customer_Id";
                cmbHof.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbHof.AutoCompleteSource = AutoCompleteSource.ListItems;
                
                _catList = MasterData.Categories.Data;
                _cat = cmbCat.Text;
                cmbCat.DataSource = _catList;
                cmbCat.DisplayMember = "Cat_Desc";
                cmbCat.ValueMember = "Cat_Id";
                if (_cat != "")
                {
                    cmbCat.Text = _cat;
                }
                _hofRelation = MasterData.Relations.Data.Select(i=> new RelationMaster
                {
                    Mst_Rel_With_Hof_Id = i.Mst_Rel_With_Hof_Id,
                    Relation = i.Relation
                }).ToList();
                _relation = MasterData.Relations.Data.Select(i => new RelationMaster
                {
                    Mst_Rel_With_Hof_Id = i.Mst_Rel_With_Hof_Id,
                    Relation = i.Relation
                }).ToList();
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
                FormHelper.ResetAllControls(groupBox1);
                FormHelper.ResetAllControls(groupBox3);
                FormHelper.ResetAllControls(panel2);
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

        private void Save()
        {
            bool isSuccess;
            string msgToShow = string.Empty;
            try
            {
                //Logger.LogInfo(dateTimePicker1.Value.ToString());
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "MM-dd-yyyy";

                string hofId = cmbHof.SelectedValue.ToString();

                DBSaveManager.SaveRationCard(rationCardId: lblRationCardId.Text, categoryId: cmbCat.SelectedValue.ToString(), categoryDesc: cmbCat.Text, CardNo: cmbCat.Text + "-" + txtCardNo.Text
                    , customerId: lblCustId.Text, adhar: txtAdharOrEpic.Text, cardHolderName: txtCardHolderName.Text, isHof: (chkHof.Checked ? "1" : "0")
                    , hofId: hofId, hofName: cmbHof.Text.Split(new string[] { "||" }, StringSplitOptions.None)[0].Trim()
                    , RelWithHofId: ((cmbRelHof.SelectedValue != null) ? cmbRelHof.SelectedValue.ToString() : ""), RelWithHofDesc: cmbRelHof.Text
                    , FatherName: txtFatherName.Text, typeOfRelationId: ((cmbRel.SelectedValue != null) ? cmbRel.SelectedValue.ToString() : "")
                    , typeOfRelationDesc: cmbRel.Text, activeOrInactiveDt: DateTime.Parse(dateTimePicker1.Value.ToString()).ToString("MM-dd-yyyy HH:mm:ss")
                    , mobileNo: txtMobileNo.Text, age: txtAge.Text, isActive: (chkActive.Checked ? "1" : "0"), address: txtAddress.Text
                    , remarks: txtRemarks.Text, isSuccess: out isSuccess, msgToShow: out msgToShow);

                if(!isSuccess)
                {
                    MessageBox.Show(msgToShow);
                }
                else
                {
                    MessageBox.Show("Rationcard Details successfuly saved...");
                }
                
                //Refresh the form data for new entry
                RefreshCatWiseCountInUi();
                ResetForm();
                FetchFormData();

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
                    string password = DialogConfirm.ShowInputDialog("Please provide password to continue.", "Confirm with Password");
                    string finalPass = SecurityEncrypt.Decrypt(ConfigurationManager.AppSettings["CriticalSectionPassword"].ToString(), "nakshal");

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

        public void RefreshCatWiseCountInUi()
        {
            try
            {
                var frmObj = (FrmCatwiseCount)FormHelper.OpenFrmCatwiseCount();
                frmObj.RefreshGrid(DBSaveManager.CatWiseCardCountData);
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
                string password = DialogConfirm.ShowInputDialog("Please provide password to continue.", "Confirm with Password");
                string finalPass = SecurityEncrypt.Decrypt(ConfigurationManager.AppSettings["CriticalSectionPassword"], "nakshal");

                if (password == finalPass)
                {
                    bool isSuccess;
                    string msg = DBSaveManager.RationcardDelete(lblRationCardId.Text, lblCustId.Text, out isSuccess);
                    if (isSuccess)
                    {
                        txtMsg.Text = msg;
                        RefreshCatWiseCountInUi();
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
            RefreshCatWiseCountInUi(); 
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
            if (!string.IsNullOrEmpty(txtCardNo.Text.Trim()))
            {
                DuplicateCheck(cmbCat.Text + "-" + txtCardNo.Text, "RATIONCARD");
            }
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
            if (!string.IsNullOrEmpty(val.Trim()))
            {
                try
                {
                    bool isDuplicate, isRecordExists;
                    string finalMsg = DBSaveManager.DuplicateCheck(val,checkBy,out isDuplicate, out isRecordExists, out _cardExists, out _adharExists, out _mobileNoexists);
                    if (isRecordExists)
                    {
                        if (isDuplicate)
                        {
                            MessageBox.Show(finalMsg);
                        }
                        if (_cardExists || _adharExists)
                            btnSave.Enabled = false;
                        else
                            btnSave.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
        }
    }
}
