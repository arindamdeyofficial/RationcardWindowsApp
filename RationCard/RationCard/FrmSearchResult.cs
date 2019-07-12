using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helper;
using RationCard.Model;
using System.Configuration;
using RationCard.Helper;
using System.Globalization;

namespace RationCard
{
    public partial class FrmSearchResult : Form
    {
        int _converted = 0;
        int _totalCont = 0;
        FrmRationEntry _frmEntry = null;
        List<Category> _catList = new List<Category>();
        List<RationCardDetail> _searchedCards = new List<RationCardDetail>();
        public FrmSearchResult(FrmRationEntry frmObj)
        {
            InitializeComponent();
            _frmEntry = frmObj;
            _catList = frmObj._catList;
            cmbCardCat.DataSource = _catList;
            cmbCardCat.DisplayMember = "Cat_Desc";
            cmbCardCat.ValueMember = "Cat_Id";
        }
        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //lblSearchBy.Text = (txtSearch.Text != "") ? lblSearchBy.Text : "";                
                _searchedCards = new List<RationCardDetail>();            
                lblSearchResult.Text = "";
                lblCriteria.Text = "";

                //if fetching from masterdata then updated or newly entered record must be updated into search result
                CategoryWiseSearchResult cards = null;
                if (string.IsNullOrEmpty(txtSearch.Text.Trim()) && (MasterData.MasterDataFetchComplete) && (MasterData.CategoryWiseSearchResult != null))
                {
                    cards = new CategoryWiseSearchResult();
                    CategoryWiseSearchResult fractionResult = MasterDataHelper.SearchCard(lblSearchBy.Text, txtSearch.Text, cmbCardCat.SelectedValue as string, true);                    
                    UpdateSearchCardMasterData(fractionResult, cmbCardCat.SelectedValue as string);
                    if ((cmbCardCat.SelectedValue != null) && (MasterData.CategoryWiseSearchResult != null))
                    {
                        cards = MasterData.CategoryWiseSearchResult.FirstOrDefault(i => (i.CategoryOfCard.Cat_Id == cmbCardCat.SelectedValue.ToString()));
                    }
                    else
                    {
                        MasterData.CategoryWiseSearchResult.ForEach(i =>
                        {
                            cards.CardSearchResult = new List<RationCardDetail>();
                            cards.CardSearchResult.AddRange(i.CardSearchResult);
                            cards.CardCountOfCategory += i.CardCountOfCategory;
                        });
                    }
                }
                if(cards == null)
                {
                    cards = MasterDataHelper.SearchCard(lblSearchBy.Text, txtSearch.Text, cmbCardCat.SelectedValue as string);
                }
                if ((cards != null) && (cards.CardCountOfCategory > 0))
                {
                    lblCriteria.Text = "Searched For " 
                        + ((txtSearch.Text != "") ? ("\"" + txtSearch.Text + "\""): "Blank")
                        +((lblSearchBy.Text != "") ? (" in \"" + lblSearchBy.Text + "\"") : "")
                        + ((cmbCardCat.Text != "") ? (" within RationCard Category \"" + cmbCardCat.Text + "\"") : "");
                        
                    grpBoxSearchCriteria.Visible = true;
                    lblSearchResult.Text = "Total Result " + cards.CardCountOfCategory;                                            
                }

                _searchedCards = cards.CardSearchResult;
                grdVwSearchResult.DataSource = null;
                grdVwSearchResult.DataSource = _searchedCards;
                grdVwSearchResult.Refresh();
                btnPrint.Visible = true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void UpdateSearchCardMasterData(CategoryWiseSearchResult fractionResult, string catId)
        {
            if ((fractionResult != null) && (fractionResult.CardSearchResult != null) && (fractionResult.CardSearchResult.Count > 0))
            {
                if (catId != null)
                {
                    CategoryWiseSearchResult cardListOfThatCat = MasterData.CategoryWiseSearchResult.FirstOrDefault(i => (i.CategoryOfCard.Cat_Id == catId));
                    if (cardListOfThatCat != null)
                    {
                        cardListOfThatCat.CardSearchResult.AddRange(fractionResult.CardSearchResult);
                        cardListOfThatCat.CardCountOfCategory += fractionResult.CardCountOfCategory;
                    }
                }
                else
                {
                    foreach (RationCardDetail card in fractionResult.CardSearchResult)
                    {
                        CategoryWiseSearchResult cardListOfThatCat = MasterData.CategoryWiseSearchResult.FirstOrDefault(i => (i.CategoryOfCard.Cat_Id == card.Cat_Id));
                        if (cardListOfThatCat != null)
                        {
                            cardListOfThatCat.CardSearchResult.Add(card);
                            cardListOfThatCat.CardCountOfCategory ++;
                        }                        
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var frmObj = Application.OpenForms["FrmLableSelectForPrint"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmLableSelectForPrint printFrm = new FrmLableSelectForPrint(this);
                printFrm.Show();
            }          
        }

        private void rdPhone_CheckedChanged(object sender, EventArgs e)
        {
            lblSearchBy.Text = "PHONE";
            txtSearch.Enabled = true;
        }

        private void rdCardNo_CheckedChanged(object sender, EventArgs e)
        {
            lblSearchBy.Text = "RATIONCARD";
            txtSearch.Enabled = true;
        }

        private void rdAdhar_CheckedChanged(object sender, EventArgs e)
        {
            lblSearchBy.Text = "ADHAR";
            txtSearch.Enabled = true;
        }
        
        private void rdName_CheckedChanged(object sender, EventArgs e)
        {
            lblSearchBy.Text = "NAME";
            txtSearch.Enabled = true;
        }

        private void grdVwSearchResult_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdVwSearchResult.Columns["Cat_Key"].Visible = false;
                grdVwSearchResult.Columns["Cat_Desc"].Visible = false;
                grdVwSearchResult.Columns["RationCard_Id"].Visible = false;
                grdVwSearchResult.Columns["Card_Category_Id"].Visible = false;
                grdVwSearchResult.Columns["Customer_Created_Date"].Visible = false;
                grdVwSearchResult.Columns["Customer_Id"].Visible = false;
                grdVwSearchResult.Columns["Hof_Id"].Visible = false;
                grdVwSearchResult.Columns["Dist_Id"].Visible = false;
                grdVwSearchResult.Columns["ActiveCustomer"].Visible = false;
                grdVwSearchResult.Columns["Cat_Id"].Visible = false;
                grdVwSearchResult.Columns["CardCount"].Visible = false;
                grdVwSearchResult.Columns["FamilyCount"].Visible = false;
                grdVwSearchResult.Columns["ActiveCard"].Visible = true;
                grdVwSearchResult.Columns["Hof_Flag"].Visible = false;
                grdVwSearchResult.Columns["CardStatus"].Visible = false;
                grdVwSearchResult.Columns["Gaurdian_Relation"].Visible = false;

                grdVwSearchResult.Columns["SlNo"].HeaderText = "SlNo.";
                grdVwSearchResult.Columns["SlNo"].DisplayIndex = 0;
                grdVwSearchResult.Columns["SlNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                grdVwSearchResult.Columns["SlNo"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, true);

                grdVwSearchResult.Columns["Number"].HeaderText = "RationCard No.";
                grdVwSearchResult.Columns["Number"].DisplayIndex = 1;
                grdVwSearchResult.Columns["Number"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, true);

                grdVwSearchResult.Columns["Adhar_No"].HeaderText = "Epic / Adhar No.";
                grdVwSearchResult.Columns["Adhar_No"].DisplayIndex = 2;
                grdVwSearchResult.Columns["Adhar_No"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.ColumnHeader, true);

                grdVwSearchResult.Columns["Mobile_No"].HeaderText = "Phone No.";
                grdVwSearchResult.Columns["Mobile_No"].DisplayIndex = 3;
                grdVwSearchResult.Columns["Mobile_No"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, true);

                grdVwSearchResult.Columns["Hof_Name"].HeaderText = "Head Of the Family";
                grdVwSearchResult.Columns["Hof_Name"].DisplayIndex = 4;
                grdVwSearchResult.Columns["Hof_Name"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.ColumnHeader, true);


                grdVwSearchResult.Columns["FamilyCount"].HeaderText = "No. Of Card";
                grdVwSearchResult.Columns["FamilyCount"].DisplayIndex = 5;
                grdVwSearchResult.Columns["FamilyCount"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, true);

                grdVwSearchResult.Columns["Relation_With_Hof"].HeaderText = "Relation with HOF";
                grdVwSearchResult.Columns["Relation_With_Hof"].DisplayIndex = 6;
                grdVwSearchResult.Columns["Relation_With_Hof"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, true);

                grdVwSearchResult.Columns["Name"].HeaderText = "Card Holder";
                grdVwSearchResult.Columns["Name"].DisplayIndex = 7;
                grdVwSearchResult.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                grdVwSearchResult.Columns["Name"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, true);

                grdVwSearchResult.Columns["Age"].HeaderText = "Age";
                grdVwSearchResult.Columns["Age"].DisplayIndex = 8;
                grdVwSearchResult.Columns["Age"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                grdVwSearchResult.Columns["Age"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.ColumnHeader, true);

                grdVwSearchResult.Columns["Address"].HeaderText = "Address";
                grdVwSearchResult.Columns["Address"].DisplayIndex = 9;
                grdVwSearchResult.Columns["Address"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, true);

                grdVwSearchResult.Columns["Card_Created_Date"].HeaderText = "Active Since";
                grdVwSearchResult.Columns["Card_Created_Date"].DisplayIndex = 10;
                grdVwSearchResult.Columns["Card_Created_Date"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, true);

                grdVwSearchResult.Columns["Gaurdian_Name"].HeaderText = "Gaurdian Name";
                grdVwSearchResult.Columns["Gaurdian_Name"].DisplayIndex = 11;
                grdVwSearchResult.Columns["Gaurdian_Name"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, true);

                grdVwSearchResult.Columns["Remarks"].HeaderText = "Remarks";
                grdVwSearchResult.Columns["Remarks"].DisplayIndex = 12;
                grdVwSearchResult.Columns["Remarks"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.ColumnHeader, true);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void grdVwSearchResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _frmEntry = (FrmRationEntry)FormHelper.OpenFrmRationEntry();
            try
            {
                Control ctrlsPanel = _frmEntry.Controls["pnlRationCardEntry"];
                Control btnPanel = ctrlsPanel.Controls["panel3"];
                Control ctrlsPanel2 = ctrlsPanel.Controls["panel2"];
                Control grp1 = ctrlsPanel.Controls["groupBox1"];
                Control grp3 = ctrlsPanel.Controls["groupBox3"];
                string cardNo = grdVwSearchResult.Rows[e.RowIndex].Cells["Number"].Value.ToString();
                grp1.Controls["txtCardNo"].Text = cardNo;
                grp1.Controls["lblIsEdit"].Text = "1";

                string mobileNo = grdVwSearchResult.Rows[e.RowIndex].Cells["Mobile_No"].Value.ToString();

                ComboBox cmbCat = (ComboBox)grp1.Controls["cmbCat"];
                cmbCat.Text = grdVwSearchResult.Rows[e.RowIndex].Cells["Cat_Desc"].Value.ToString();
                cmbCat.SelectedValue = grdVwSearchResult.Rows[e.RowIndex].Cells["Cat_Id"].Value.ToString();
                cmbCat.SelectedIndex = Int32.Parse(((List<Category>)cmbCat.DataSource).FirstOrDefault(i => i.Cat_Id == grdVwSearchResult.Rows[e.RowIndex].Cells["Cat_Id"].Value.ToString()).Cat_Id) - 1;

                grp1.Controls["lblCardCatId"].Text = grdVwSearchResult.Rows[e.RowIndex].Cells["Cat_Id"].Value.ToString();
                grp1.Controls["txtAdharOrEpic"].Text = grdVwSearchResult.Rows[e.RowIndex].Cells["Adhar_No"].Value.ToString();

                grp3.Controls["txtCardHolderName"].Text = grdVwSearchResult.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                CheckBox hofCheck = (CheckBox)grp3.Controls["chkHof"];
                hofCheck.Checked = grdVwSearchResult.Rows[e.RowIndex].Cells["Hof_Flag"].Value.ToString() == "True";
                string hofName = grdVwSearchResult.Rows[e.RowIndex].Cells["Hof_Name"].Value.ToString();
                grp3.Controls["cmbHof"].Text = hofName + " || " + cardNo + " || " + mobileNo;
                grp3.Controls["txtFatherName"].Text = grdVwSearchResult.Rows[e.RowIndex].Cells["Gaurdian_Name"].Value.ToString();
                grp3.Controls["cmbRelHof"].Text = grdVwSearchResult.Rows[e.RowIndex].Cells["Relation_With_Hof"].Value.ToString();
                grp3.Controls["cmbRel"].Text = grdVwSearchResult.Rows[e.RowIndex].Cells["Gaurdian_Relation"].Value.ToString();

                string custId = grdVwSearchResult.Rows[e.RowIndex].Cells["Customer_Id"].Value.ToString();
                RationCardDetail card = MasterDataHelper.FetchFamilyCount(custId);
                grp3.Controls["txtTotalActiveCards"].Text = card.FamilyCount;
                grp3.Controls["txtTotalCards"].Text = card.CardCount;
                //grp3.Controls["txtHofCardNo"].Text = grdVwSearchResult.Rows[e.RowIndex].Cells["CardCount"].Value.ToString();

                DateTimePicker dt = (DateTimePicker)ctrlsPanel2.Controls["dateTimePicker1"];
                dt.Value = DateTime.ParseExact(grdVwSearchResult.Rows[e.RowIndex].Cells["Card_Created_Date"].Value.ToString(),
                    "d", CultureInfo.InvariantCulture);
                CheckBox active = (CheckBox)ctrlsPanel2.Controls["chkActive"];
                active.Checked = grdVwSearchResult.Rows[e.RowIndex].Cells["ActiveCard"].Value.ToString() == "True";
                ctrlsPanel2.Controls["txtMobileNo"].Text = mobileNo;
                ctrlsPanel2.Controls["txtAge"].Text = grdVwSearchResult.Rows[e.RowIndex].Cells["Age"].Value.ToString();
                ctrlsPanel2.Controls["txtAddress"].Text = grdVwSearchResult.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                ctrlsPanel2.Controls["txtRemarks"].Text = grdVwSearchResult.Rows[e.RowIndex].Cells["Remarks"].Value.ToString();
                ctrlsPanel2.Controls["lblRationCardId"].Text = grdVwSearchResult.Rows[e.RowIndex].Cells["RationCard_Id"].Value.ToString();
                ctrlsPanel2.Controls["lblCustId"].Text = custId;

                btnPanel.Controls["btnDelete"].Enabled = true;                
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void FrmSearchResult_Load(object sender, EventArgs e)
        {

        }
    }
}
