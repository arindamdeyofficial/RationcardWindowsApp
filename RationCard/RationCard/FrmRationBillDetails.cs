using Helper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using RationCard.Helper;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace RationCard
{
    public partial class FrmRationBillDetails : Form
    {
        List<RationCardDetailExtended> _membersToGiveRation = new List<RationCardDetailExtended>();
        List<Product> _items = new List<Product>();
        List<Product> _defaultPrds = new List<Product>();
        public FrmRationBillDetails(List<RationCardDetailExtended> membersToGiveRation)
        {
            InitializeComponent();
            _membersToGiveRation = membersToGiveRation;
            AdddefaultProduct();
        }

        private void RationBillDetails_Load(object sender, EventArgs e)
        {
            var dtNow = DateTime.Now;
            lblDt.Text = dtNow.ToLongDateString() + " " + dtNow.ToLongTimeString();
            try
            {                
                grdVwMembers.DataSource = null;
                grdVwMembers.DataSource = _membersToGiveRation;
                
                //make unneccesary fileds hidden
                grdVwMembers.Columns["Cat_Key"].Visible = false;
                grdVwMembers.Columns["Cat_Desc"].Visible = false;
                grdVwMembers.Columns["RationCard_Id"].Visible = false;
                grdVwMembers.Columns["Card_Category_Id"].Visible = false;
                grdVwMembers.Columns["Customer_Created_Date"].Visible = false;
                grdVwMembers.Columns["Customer_Id"].Visible = false;
                grdVwMembers.Columns["Hof_Id"].Visible = false;
                grdVwMembers.Columns["Dist_Id"].Visible = false;
                grdVwMembers.Columns["ActiveCustomer"].Visible = false;
                grdVwMembers.Columns["Cat_Id"].Visible = false;
                grdVwMembers.Columns["CardCount"].Visible = false;
                grdVwMembers.Columns["FamilyCount"].Visible = false;
                grdVwMembers.Columns["ActiveCard"].Visible = true;
                //grdVwSearchResult.Columns["Hof_Flag"].Visible = false;
                grdVwMembers.Columns["CardStatus"].Visible = false;
                grdVwMembers.Columns["Gaurdian_Relation"].Visible = false;
                grdVwMembers.Columns["SlNo"].Visible = false;
                //grdVwSearchResult.Columns["Number"].Visible = false;
                grdVwMembers.Columns["Adhar_No"].Visible = false;
                grdVwMembers.Columns["Mobile_No"].Visible = false;
                grdVwMembers.Columns["Hof_Name"].Visible = false;
                grdVwMembers.Columns["Relation_With_Hof"].Visible = false;
                //grdVwSearchResult.Columns["Name"].Visible = false;
                grdVwMembers.Columns["Age"].Visible = false;
                grdVwMembers.Columns["Address"].Visible = false;
                grdVwMembers.Columns["Card_Created_Date"].Visible = false;
                grdVwMembers.Columns["Gaurdian_Name"].Visible = false;
                grdVwMembers.Columns["Remarks"].Visible = false;
                grdVwMembers.Columns["IsSelected"].Visible = false;
                grdVwMembers.Columns["Activecard"].Visible = false;

                grdVwMembers.Columns["IsSelected"].HeaderText = "";
                grdVwMembers.Columns["IsSelected"].DisplayIndex = 0;
                grdVwMembers.Columns["IsSelected"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdVwMembers.Columns["IsSelected"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                grdVwMembers.Columns["Number"].HeaderText = "Card No.";
                grdVwMembers.Columns["Number"].DisplayIndex = 1;
                grdVwMembers.Columns["Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdVwMembers.Columns["Number"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                grdVwMembers.Columns["Name"].HeaderText = "Name";
                grdVwMembers.Columns["Name"].DisplayIndex = 2;
                grdVwMembers.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdVwMembers.Columns["Name"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                grdVwMembers.Columns["Hof_Flag"].HeaderText = "IsHof";
                grdVwMembers.Columns["Hof_Flag"].DisplayIndex = 6;
                grdVwMembers.Columns["Hof_Flag"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                grdVwMembers.Columns["Hof_Flag"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.ColumnHeader, true);

                //grdVwSearchResult.Width = grdVwSearchResult.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 40;
                //grdVwSearchResult.Height = grdVwSearchResult.Rows.GetRowsHeight(new DataGridViewElementStates());

                btnPrintBill.Visible = true;

                //Fetch bill counter
                try
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter { ParameterName = "@userId", SqlDbType = SqlDbType.VarChar, Value = User.LoginId });
                    DataSet ds = ConnectionManager.Exec("Sp_Fetch_Bill_Counter", sqlParams);
                    if ((ds != null) && (ds.Tables.Count > 0))
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            int count = 1;
                            foreach (DataRow r in ds.Tables[0].Rows)
                            {
                                lblCashMemoCounter.Text = r["BillCounter"].ToString();
                                count++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
                //Assign prd list to prd dropdown
                cmbCommodity.DataSource = MasterData.PrdData;
                cmbCommodity.ValueMember = "Product_Master_Identity";
                cmbCommodity.DisplayMember = "Name";
                cmbCommodity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCommodity.AutoCompleteSource = AutoCompleteSource.ListItems;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            string path = @"D:\RartionCard\RationCard\RationCard\image";//Directory.GetCurrentDirectory() + "/Bills_" + GetDateStamp();
            string fileName = "/" + GetDateTimeStamp() + ".pdf";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            FileStream flStrm = new FileStream(path + fileName, FileMode.Create);

            iTextSharp.text.Rectangle pgSize = new iTextSharp.text.Rectangle(Utilities.MillimetersToPoints(80), Utilities.MillimetersToPoints(127));
            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(pgSize, 1, 1, 1, 1);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, flStrm);
            pdfDoc.Open();

            var para = new Paragraph(lblCashMemo.Text
                + "                 " + lblBillNoText.Text + "  " + lblCashMemoCounter.Text                
                + Environment.NewLine + lblDt.Text
                + Environment.NewLine + "-------------------------------------------------------"
                + Environment.NewLine + lblFpsDealer.Text
                + Environment.NewLine + lblFPSCodeNo.Text
                + Environment.NewLine + lblAddrLn1.Text
                + Environment.NewLine + lblAddrLn2.Text
                + Environment.NewLine + lblAddrLn3.Text
                + Environment.NewLine + "-------------------------------------------------------"
                , new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11));

            //Header
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(@"D:\RartionCard\RationCard\RationCard\image\logo.jpg");
            jpg.ScaleToFit(80f, 60f);
            jpg.SpacingBefore = 1f;
            jpg.SpacingAfter = 1f;
            jpg.Alignment = Element.ALIGN_CENTER;

            //Members
            para.Add(new Chunk(Environment.NewLine + Environment.NewLine + lblMembersText.Text, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 9)));            

            //Items
            foreach (DataGridViewRow lnItem in grdVwMembers.Rows)
            {
                para.Add(new Chunk(Environment.NewLine + lnItem.Cells["Name"].Value.ToString()
                                 + "        " + lnItem.Cells["Number"].Value.ToString()
                    , new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 9)));
            }

            //Items
            para.Add(new Chunk(Environment.NewLine + Environment.NewLine + lblItemsText.Text, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 9)));
            foreach (DataGridViewRow lnItem in grdVwItems.Rows)
            {
                para.Add(new Chunk(Environment.NewLine + lnItem.Cells["Commodity"].Value.ToString()
                    + " ( " + lnItem.Cells["Quantity"].Value.ToString() + " " + lnItem.Cells["Uom"].Value.ToString() + " )"
                    + "    " +lnItem.Cells["Rate"].Value.ToString()
                                 + "        " + lnItem.Cells["Price"].Value.ToString()
                    , new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7)));
            }

            //Total Price
            para.Add(new Chunk(Environment.NewLine + "-------------------------------------------------------" + Environment.NewLine
                + lblTotal.Text
                + "                             " + lblCustomerToPayRs.Text
                + Environment.NewLine + lblTotalRoundedOff.Text
                + "                             " + lblTotalRsRounded.Text
                + Environment.NewLine + lblDiscountText.Text
                + "                             " + lblDiscount.Text
                 + Environment.NewLine + lblCustomerPaid.Text
                + "                             " + txtCustPaid.Text
                 + Environment.NewLine + lblBalance.Text
                + "                             " + lblBalRs.Text

                , new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 9))); 
            

            pdfDoc.Add(jpg);
            pdfDoc.Add(para);
            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            flStrm.Close();
            pdfWriter.Close();

            //Process p = new Process();
            //p.StartInfo = new ProcessStartInfo()
            //{
            //    //CreateNoWindow = true,
            //    //Verb = "print",
            //    FileName = path + fileName //put the correct path here
            //};
            //p.Start();
            
            // initialize PrintDocument object
            PrintDocument doc = new PrintDocument()
            {
                PrinterSettings = new PrinterSettings()
                {
                    // set the printer to 'Microsoft Print to PDF'
                    PrinterName = "EPSON TM-T82 Receipt",
                    
                    // set the filename to whatever you like (full path)
                    PrintFileName =  path + "/" + "2018211161323264.pdf"
                }
            };

            doc.Print();
        }
        private string GetDateTimeStamp()
        {
            var dtTime = DateTime.Now;
            return GetDateStamp() + GetTimeStamp();
        }
        private string GetDateStamp()
        {
            var dtTime = DateTime.Now;
            return dtTime.Year.ToString() + dtTime.Month.ToString() + dtTime.Day.ToString();
        }
        private string GetTimeStamp()
        {
            var dtTime = DateTime.Now;
            return dtTime.Hour.ToString() + dtTime.Minute.ToString()
                            + dtTime.Second.ToString() + dtTime.Millisecond.ToString();
        }

        private void grdVwSearchResult_DataSourceChanged(object sender, EventArgs e)
        {
            var rowNo = grdVwMembers.Rows.Count;
            var totalRowHeight = grdVwMembers.Rows.GetRowsHeight(new DataGridViewElementStates());
            var rowHeight = totalRowHeight / rowNo;
            grdVwMembers.Width = grdVwMembers.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed);
            grdVwMembers.Height = rowHeight * (rowNo + 1);
        }

        private void cmbCommodity_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormHelper.OpenFrmPrdQuantityInBill(((Product)cmbCommodity.SelectedItem).UOMType);
        }

        public void AdddefaultProduct()
        {
            _defaultPrds.AddRange(MasterData.PrdData.Select(i=>i).Where(i=>(i.IsDefaultProduct==true) & (i.IsDefaultGiveRation == true)));
        }
        public void AddProduct(Product prd)
        {
            Product selectedItem = (Product)cmbCommodity.SelectedItem;
            _items.Add(new Product { Name = selectedItem.Name, UOMType = selectedItem .UOMType, Active= selectedItem.Active, Quantity = prd.Quantity, UnitOfMeasure = prd.UnitOfMeasure});
            grdVwItems.DataSource = null;
            grdVwItems.DataSource = _items;

            //make unneccesary fileds hidden
            grdVwItems.Columns["BaseUom"].Visible = false;
            grdVwItems.Columns["ConversionFactor"].Visible = false;
            grdVwItems.Columns["RateInBaseUom"].Visible = false;
            grdVwItems.Columns["StockInBaseUom"].Visible = false;
            grdVwItems.Columns["AllocatedPerCustomerInBaseUom"].Visible = false;
            grdVwItems.Columns["Product_Master_Identity"].Visible = false;
            grdVwItems.Columns["ProdDescription"].Visible = false;
            grdVwItems.Columns["UOMType"].Visible = false;
            grdVwItems.Columns["Active"].Visible = false;
            grdVwItems.Columns["UnitOfMeasure"].Visible = false;
            grdVwItems.Columns["Quantity"].Visible = false;
            grdVwItems.Columns["RateInCurrentUom"].Visible = false;

            grdVwItems.Columns["Name"].HeaderText = "Item";
            grdVwItems.Columns["Name"].DisplayIndex = 0;
            grdVwItems.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVwItems.Columns["Name"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

            grdVwItems.Columns["QuantityToDisplay"].HeaderText = "Quantity";
            grdVwItems.Columns["QuantityToDisplay"].DisplayIndex = 1;
            grdVwItems.Columns["QuantityToDisplay"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVwItems.Columns["QuantityToDisplay"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

            grdVwItems.Columns["RateInCurrentUomDisplay"].HeaderText = "Rate";
            grdVwItems.Columns["RateInCurrentUomDisplay"].DisplayIndex = 2;
            grdVwItems.Columns["RateInCurrentUomDisplay"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVwItems.Columns["RateInCurrentUomDisplay"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

            grdVwItems.Refresh();
        }
    }
}
