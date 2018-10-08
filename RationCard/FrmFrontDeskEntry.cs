using RationCard.Helper;
using RationCard.MasterDataManager;
using RationCard.Model;
using System;
using System.Collections.Generic;
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
            lblCardCount.Text = "";
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
                         List<RationCardDetail> cardWithRationThisFortnight = searchedCards.CardSearchResult.FindAll(i=> MasterData.AllCardsOfThisFortnight.Data.Any(j=>j.Equals(i.Number)));
                        if((cardWithRationThisFortnight != null) && (cardWithRationThisFortnight.Count > 0))
                        {
                            MessageBox.Show("RationCard already given in this Fortnight for below cards :" + Environment.NewLine
                                + string.Join(Environment.NewLine
                                    , cardWithRationThisFortnight.Select(i=> "Name : " + i.Name + "   CardNumber : " + i.Number).ToList()));
                        }
                        searchedCards.CardSearchResult.RemoveAll(i=> cardWithRationThisFortnight.Any(j=>j.Number.Equals(i.Number)));
                        searchedCards.CardCountOfCategory = searchedCards.CardSearchResult.Count;
                        _searchedCards.Clear();
                       foreach (RationCardDetail card in searchedCards.CardSearchResult)
                        {
                            if (card.ActiveCard)
                            {
                                var cardExtended = new RationCardDetailExtended();
                                cardExtended = AutomapperHelper.ConvertAutoMapper<RationCardDetail, RationCardDetailExtended>(card);
                                cardExtended.IsSelected = true;
                                _searchedCards.Add(cardExtended);
                            }
                        }
                    }

                    grdVwSearchResult.DataSource = null;
                    grdVwSearchResult.DataSource = _searchedCards;

                    //making card number complete
                    //var searchedCardNumber = _searchedCards.FirstOrDefault(i => i.Number.Contains(txtRationcardNumber.Text)).Number;
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
                    grdVwSearchResult.Columns["FamilyCount"].Visible = false;
                    grdVwSearchResult.Columns["CardCount"].Visible = false;

                    grdVwSearchResult.Columns["IsSelected"].HeaderText = "";
                    grdVwSearchResult.Columns["IsSelected"].DisplayIndex = 0;
                    grdVwSearchResult.Columns["IsSelected"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grdVwSearchResult.Columns["IsSelected"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                    grdVwSearchResult.Columns["Number"].HeaderText = "Card No.";
                    grdVwSearchResult.Columns["Number"].DisplayIndex = 1;
                    grdVwSearchResult.Columns["Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grdVwSearchResult.Columns["Number"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                          
                    grdVwSearchResult.Columns["Name"].DisplayIndex = 2;
                    grdVwSearchResult.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grdVwSearchResult.Columns["Name"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                    grdVwSearchResult.Columns["Mobile_No"].HeaderText = "Mobile No";
                    grdVwSearchResult.Columns["Mobile_No"].DisplayIndex = 3;
                    grdVwSearchResult.Columns["Mobile_No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    grdVwSearchResult.Columns["Mobile_No"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

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
                    CalculateCardCount();
                    grdVwSearchResult.Focus();
                }
                catch (Exception ex)
                {
                    txtRationcardNumber.Text = "";
                    Logger.LogError(ex);
                }
            }
        }

        private void CalculateCardCount()
        {
            try
            {
                int totalCount = 0;
                int activeCount = 0;
                for (var i = 0; i < grdVwSearchResult.Rows.Count; i++)
                {
                    //((DataGridViewCheckBoxCell)grdVwSearchResult.Rows[0].Cells["IsSelected"]).Selected;
                    bool isSelected = (bool)grdVwSearchResult.Rows[i].Cells["IsSelected"].Value;
                    bool isActive = (bool)grdVwSearchResult.Rows[i].Cells["Activecard"].Value;
                    if (isSelected)
                    {
                        totalCount++;
                        if (isActive)
                        {
                            activeCount++;
                        }
                    }
                }

                lblCardCount.Text = "Total " + totalCount + " cards and "
                                    + activeCount + " active cards.";
            }
            catch (Exception ex)
            {
                txtRationcardNumber.Text = "";
                Logger.LogError(ex);
            }
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            try
            {
                var finalCards = new List<RationCardDetailExtended>();
                for (var a = 0; a < grdVwSearchResult.Rows.Count; a++)
                {
                    if ((bool)grdVwSearchResult.Rows[a].Cells["IsSelected"].Value)
                    {
                        finalCards.Add(_searchedCards.FirstOrDefault(i => (i.RationCard_Id == grdVwSearchResult.Rows[a].Cells["RationCard_Id"].Value.ToString())));
                    }
                }
                FormHelper.OpenRationBillDetails(finalCards);
            }
            catch (Exception ex)
            {
                txtRationcardNumber.Text = "";
                Logger.LogError(ex);
            }
        }

        private void grdVwSearchResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmFrontDeskEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                btnCreateBill_Click(sender, (EventArgs)e);
            }
        }

        private void grdVwSearchResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13) //enter
                {
                    btnCreateBill_Click(sender, (EventArgs)e);
                }
                else if (e.KeyChar == 32) //space
                {
                    for (var a = 0; a < grdVwSearchResult.SelectedCells.Count; a++)
                    {
                        if (grdVwSearchResult.SelectedCells[a].ColumnIndex == 0)
                        {
                            grdVwSearchResult.SelectedCells[a].Value = !(bool)grdVwSearchResult.SelectedCells[a].Value;
                            grdVwSearchResult.Refresh();
                        }
                    }
                }
                else if (e.KeyChar == 9) //tab
                {
                    int currentRowIndex = grdVwSearchResult.CurrentCell.RowIndex;
                    int totalRow = grdVwSearchResult.Rows.Count;
                    int rowIndexToSelect = ((currentRowIndex + 1) > (totalRow - 1)) ? 0 : (currentRowIndex + 1);
                    grdVwSearchResult.CurrentCell = grdVwSearchResult.Rows[rowIndexToSelect].Cells[0];
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
