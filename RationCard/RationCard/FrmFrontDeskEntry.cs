using Helper;
using RationCard.Helper;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace RationCard
{
    public partial class FrmFrontDeskEntry : Form
    {
        List<RationCardDetailExtended> _searchedCards = new List<RationCardDetailExtended>();
        public FrmFrontDeskEntry()
        {
            InitializeComponent();
        }

        private void FrmFrontDeskEntry_Load(object sender, EventArgs e)
        {
            txtRationcardNumber.Focus();
        }

        private void txtRationcardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {                
                try
                {
                    CategoryWiseSearchResult searchedCards = MasterDataHelper.SearchCard("RATIONCARD", txtRationcardNumber.Text, null);
                    if(searchedCards != null)
                    {
                       foreach(RationCardDetailExtended card in searchedCards.CardSearchResult)
                        {
                            card.IsSelected = true;
                            _searchedCards.Add(card);
                        }
                    }

                    grdVwSearchResult.DataSource = null;
                    grdVwSearchResult.DataSource = _searchedCards;

                    //making card number complete
                    var searchedCardNumber = _searchedCards.FirstOrDefault(i => i.Number.Contains(txtRationcardNumber.Text)).Number;
                    txtRationcardNumber.Text = "";

                    //make unneccesary fileds hidden
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
                    //grdVwSearchResult.Columns["CardCount"].Visible = false;
                    //grdVwSearchResult.Columns["FamilyCount"].Visible = false;
                    grdVwSearchResult.Columns["ActiveCard"].Visible = true;
                    //grdVwSearchResult.Columns["Hof_Flag"].Visible = false;
                    grdVwSearchResult.Columns["CardStatus"].Visible = false;
                    grdVwSearchResult.Columns["Gaurdian_Relation"].Visible = false;
                    grdVwSearchResult.Columns["SlNo"].Visible = false;
                    //grdVwSearchResult.Columns["Number"].Visible = false;
                    grdVwSearchResult.Columns["Adhar_No"].Visible = false;
                    //grdVwSearchResult.Columns["Mobile_No"].Visible = false;
                    grdVwSearchResult.Columns["Hof_Name"].Visible = false;
                    grdVwSearchResult.Columns["Relation_With_Hof"].Visible = false;
                    //grdVwSearchResult.Columns["Name"].Visible = false;
                    grdVwSearchResult.Columns["Age"].Visible = false;
                    grdVwSearchResult.Columns["Address"].Visible = false;
                    grdVwSearchResult.Columns["Card_Created_Date"].Visible = false;
                    grdVwSearchResult.Columns["Gaurdian_Name"].Visible = false;
                    grdVwSearchResult.Columns["Remarks"].Visible = false;

                    grdVwSearchResult.Columns["IsSelected"].HeaderText = "";
                    grdVwSearchResult.Columns["IsSelected"].DisplayIndex = 0;
                    grdVwSearchResult.Columns["IsSelected"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grdVwSearchResult.Columns["IsSelected"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                    grdVwSearchResult.Columns["Number"].HeaderText = "Card No.";
                    grdVwSearchResult.Columns["Number"].DisplayIndex = 1;
                    grdVwSearchResult.Columns["Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grdVwSearchResult.Columns["Number"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                    grdVwSearchResult.Columns["Name"].HeaderText = "Name";
                    grdVwSearchResult.Columns["Name"].DisplayIndex = 2;
                    grdVwSearchResult.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grdVwSearchResult.Columns["Name"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                    grdVwSearchResult.Columns["Mobile_No"].HeaderText = "Mobile No";
                    grdVwSearchResult.Columns["Mobile_No"].DisplayIndex = 3;
                    grdVwSearchResult.Columns["Mobile_No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grdVwSearchResult.Columns["Mobile_No"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                    grdVwSearchResult.Columns["FamilyCount"].HeaderText = "FamilyCount";
                    grdVwSearchResult.Columns["FamilyCount"].DisplayIndex = 4;
                    grdVwSearchResult.Columns["FamilyCount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grdVwSearchResult.Columns["FamilyCount"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                    grdVwSearchResult.Columns["CardCount"].HeaderText = "CardCount";
                    grdVwSearchResult.Columns["CardCount"].DisplayIndex = 5;
                    grdVwSearchResult.Columns["CardCount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grdVwSearchResult.Columns["CardCount"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                    grdVwSearchResult.Columns["Hof_Flag"].HeaderText = "IsHof";
                    grdVwSearchResult.Columns["Hof_Flag"].DisplayIndex = 6;
                    grdVwSearchResult.Columns["Hof_Flag"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    grdVwSearchResult.Columns["Hof_Flag"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.ColumnHeader, true);                    

                    grdVwSearchResult.Columns["ActiveCard"].HeaderText = "Is Active";
                    grdVwSearchResult.Columns["ActiveCard"].DisplayIndex = 7;
                    grdVwSearchResult.Columns["ActiveCard"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    grdVwSearchResult.Columns["ActiveCard"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.ColumnHeader, true);
                    //grdVwSearchResult.Columns.Add(new DataGridViewColumn { ValueType = typeof(bool), Name = "IsSelected", HeaderText = "Select"});

                    //grdVwSearchResult.Width = grdVwSearchResult.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 40;
                    //grdVwSearchResult.Height = grdVwSearchResult.Rows.GetRowsHeight(new DataGridViewElementStates());

                    btnCreateBill.Visible = true;
                    txtRationcardNumber.Text = "";
                }
                catch (Exception ex)
                {
                    txtRationcardNumber.Text = "";
                    Logger.LogError(ex);
                }
            }
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            var finalCards = new List<RationCardDetailExtended>();
            for (var a=0; a<grdVwSearchResult.Rows.Count;a++)
            {
                if((bool)grdVwSearchResult.Rows[a].Cells["IsSelected"].Value)
                {
                    finalCards.Add(_searchedCards.FirstOrDefault(i => (i.RationCard_Id == grdVwSearchResult.Rows[a].Cells["RationCard_Id"].Value.ToString())));
                }
            }
            FormHelper.OpenRationBillDetails(finalCards);
        }
    }
}
