using RationCard.Helper;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RationCard
{
    public partial class FrmStockDetails : Form
    {
        public FrmProductDetails _frmPrd;
        public FrmStockDetails(FrmProductDetails frmPrd)
        {
            InitializeComponent();
            _frmPrd = frmPrd;
        }

        private void FrmStockDetails_Load(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Parse("01-01-1900");
            dtTo.Value = DateTime.Now;

            LoadGrisData(_frmPrd._prd.StockInBaseUom);
        }

        private void LoadGrisData(List<ProductStock> stcks)
        {
            //Load stocks
            grdVwStocks.DataSource = null;
            grdVwStocks.DataSource = stcks;
            grdVwStocks.Refresh();

            grdVwStocks.Columns["Product_Stock_Id_Ui"].Visible = false;
            grdVwStocks.Columns["Product_Stock_Identity"].Visible = false;
            grdVwStocks.Columns["Prod_Id"].Visible = false;
            grdVwStocks.Columns["StockUom"].Visible = false;
            grdVwStocks.Columns["EntryMode"].Visible = false;
            grdVwStocks.Columns["StockToShow"].Visible = false;
            grdVwStocks.Columns["StockEntryTimeInDateFormat"].Visible = false;
            grdVwStocks.Columns["CategoryDetails"].Visible = false;

            if (grdVwStocks.RowCount > 0)
            {
                btnPrintStockReport.Visible = true;
            }
        }

        private void btnSearchStock_Click(object sender, EventArgs e)
        {
            LoadGrisData(_frmPrd._prd.StockInBaseUom.FindAll(i=>(i.StockEntryTimeInDateFormat.Date >= dtFrom.Value.Date) && (i.StockEntryTimeInDateFormat.Date <= dtTo.Value.Date)));
        }

        private void btnPrintStockReport_Click(object sender, EventArgs e)
        {
            try
            {
                var prds = new List<Product>();
                prds.Add(_frmPrd._prd);

                string rptHeader = "Dealer Name\t\t : " + User.Name + Environment.NewLine
                   + "Liscence Number\t : " + User.LiscenceNo + Environment.NewLine
                   + "MR Shop Number\t : "
                   + User.MrShopNo + Environment.NewLine + Environment.NewLine + Environment.NewLine;

                string rptCriteria = "From " + dtFrom.Value + "To " + dtTo.Value;

                string rptDate = Environment.NewLine + "Date : " + DateTime.Now.ToLongDateString();
                string rptSignature = "____________________" + Environment.NewLine + "\t Signature";
                StockPrint.PrintForm(
                        prds
                        , rptHeader
                        , rptCriteria
                        , rptDate
                        , rptSignature
                        , "L"
                        , "A3"
                        , "Daily Stock Register"
                    );
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
