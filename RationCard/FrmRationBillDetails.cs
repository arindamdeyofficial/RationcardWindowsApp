using iTextSharp.text;
using iTextSharp.text.pdf;
using RationCard.DbSaveFireAndForget;
using RationCard.Helper;
using RationCard.MasterDataManager;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RationCard
{
    public partial class FrmRationBillDetails : Form
    {
        List<RationCardDetailExtended> _membersToGiveRation = new List<RationCardDetailExtended>();
        int _memberCount = 0;
        List<Product> _items = new List<Product>();
        List<Product> _defaultPrds = new List<Product>();
        string _billSavePath = "";
        string _fileName = "";
        string _keys = "";
        bool _isShowLogoInBill = ConfigManager.GetConfigValue("ShowLogoInBill") == "TRUE";
        int _billTxtSize = 8;
        int _billNotificationTxtSize = 8;
        int _billHeaderTxtSize = 10;
        int _billPartHeadingTxtSize = 9;
        int _billPrintNumberOfCopies = int.Parse(ConfigManager.GetConfigValue("BillPrintNumberOfCopies"));
        float _chnkHeight = 0;
        float _chnkWidth = 0;
        Bill _billObj = new Bill();        

        int _totalBillCounter = 0;
        int _dayBillCounterOrCount = 0;
        bool _isDrpClicked = false;

        //customer payment summary
        double _total = 0;
        double _totalRoundedOff = 0;
        double _discount = 0;

        private Font CalculateFont(int fontSize)
        {
            return new iTextSharp.text.Font(BaseFont.CreateFont(@"C:\Windows\Fonts\ARIALNB.TTF", BaseFont.IDENTITY_H,
                        BaseFont.EMBEDDED), fontSize);
        }
        public FrmRationBillDetails(List<RationCardDetailExtended> membersToGiveRation)
        {
            InitializeComponent();
            _membersToGiveRation = membersToGiveRation;
            _memberCount = _membersToGiveRation.Count;
            _billObj.BillDetails = new List<BillDetails>();
            _billObj.CreatedDate = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
            lblDt.Text = _billObj.CreatedDate;
            AdddefaultProduct(null);
            cmbCommodity.Select();
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
            catch (Exception ex)
            {
                //Logger.LogError(ex);
            }
        }

        private void RationBillDetails_Load(object sender, EventArgs e)
        {
            grdVwMembers.ScrollBars = ScrollBars.Vertical;
            try
            {
                //internet check logo
                Network.CheckForInternet(InternetStatusChange);

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
                grdVwMembers.Columns["CardStatus"].Visible = false;
                grdVwMembers.Columns["Gaurdian_Relation"].Visible = false;
                grdVwMembers.Columns["SlNo"].Visible = false;
                grdVwMembers.Columns["Adhar_No"].Visible = false;
                grdVwMembers.Columns["Mobile_No"].Visible = false;
                grdVwMembers.Columns["Hof_Name"].Visible = false;
                grdVwMembers.Columns["Relation_With_Hof"].Visible = false;
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
                grdVwMembers.Columns["Name"].Width = 100;
                grdVwMembers.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                grdVwMembers.Columns["Name"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                grdVwMembers.Columns["Hof_Flag"].HeaderText = "IsHof";
                grdVwMembers.Columns["Hof_Flag"].DisplayIndex = 6;
                grdVwMembers.Columns["Hof_Flag"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                grdVwMembers.Columns["Hof_Flag"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.ColumnHeader, true);
                
                btnSaveBill.Visible = true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            //Fetch bill counter
            ErrorEnum errType = ErrorEnum.Other;
            string errMsg = string.Empty;
            bool isSuccess = false;

            List<BillCounter> billCounters = DBSaveManager.FetchBillCounter(out errType, out errMsg, out isSuccess);
            if(isSuccess)
            {
                int count = 1;
                int convertedNum = 0;
                foreach (BillCounter r in billCounters)
                {
                    lblCashMemoCounter.Text = r.TotalBillCOunter;
                    _totalBillCounter = int.TryParse(lblCashMemoCounter.Text, out convertedNum) ? convertedNum : 0;

                    lblSerialNumber.Text = r.DailyBillCOunterOrCount;
                    _dayBillCounterOrCount = int.TryParse(lblSerialNumber.Text, out convertedNum) ? convertedNum : 0;

                    count++;
                }

                //Assign prd list to prd dropdown
                cmbCommodity.DataSource = MasterData.PrdData.Data;
                cmbCommodity.ValueMember = "Product_Master_Identity";
                cmbCommodity.DisplayMember = "Name";
                cmbCommodity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCommodity.AutoCompleteSource = AutoCompleteSource.ListItems;

                lblBalRs.Text = "";
                cmbCommodity.Select();
            }
        }

        private void CalculatePriceSummary()
        {
            try
            {
                double convertedNum = 0;
                _total = _items.Sum(i => i.Price);
                _totalRoundedOff = Math.Ceiling(_total);
                _discount = _items.Sum(i => i.Discount);

                lblCustomerToPayRs.Text = _total.ToString("0.00");
                lblTotalRsRounded.Text = _totalRoundedOff.ToString("0.00");
                lblDiscount.Text = _discount.ToString("0.00");
                if (!string.IsNullOrEmpty(txtCustPaid.Text.Trim()))
                {
                    lblBalRs.Text = Math.Round((double.TryParse(txtCustPaid.Text, out convertedNum) ? convertedNum : 0)
                            - _totalRoundedOff, 2).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        private Bill SaveBillToDrive()
        {
            var billObj = new Bill();
            try
            {                
                string googleDrivePath = ConfigManager.GetConfigValue("GoogleDrivePath");
                string billSavePath = ConfigManager.GetConfigValue("BillSavePath");
                _billSavePath = googleDrivePath + billSavePath + TimeStampHelper.GetDateStamp();
                _fileName = "/" + TimeStampHelper.GetDateTimeStamp() + ".pdf";
                if (!Directory.Exists(_billSavePath))
                {
                    Directory.CreateDirectory(_billSavePath);
                }
                FileStream flStrm = new FileStream(_billSavePath + _fileName, FileMode.Create);

                //Header
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Directory.GetCurrentDirectory().Replace(@"bin\Debug", "") + @"\image\logo.jpg");
                jpg.ScaleToFit(50f, 37f);
                jpg.SpacingBefore = 0f;
                jpg.SpacingAfter = 0f;
                jpg.Alignment = Element.ALIGN_CENTER;

                var para = new Paragraph();
                para.MultipliedLeading = 1;
                para.SpacingBefore = 0;
                para.SpacingAfter = 0;
                if (_isShowLogoInBill)
                {
                    para.Add(jpg);
                }

                para.Add(new Chunk(lblFpsDealer.Text + " || "
                    + lblFPSCodeNo.Text + " || "
                    + lblAddrLn1.Text + " || "
                    + lblAddrLn2.Text + " || "
                    + lblAddrLn3.Text + Environment.NewLine
                    , CalculateFont(_billNotificationTxtSize)));

                //BillCounter
                PdfPTable billCounterTable = new PdfPTable(2) { WidthPercentage = 100 };
                billCounterTable.SpacingBefore = 0f;
                billCounterTable.SpacingAfter = 0f;

                //billcounter
                _billObj.BillNumber = _totalBillCounter.ToString();
                _billObj.BillSerialNumber = _dayBillCounterOrCount.ToString();

                PdfPCell billCounterTableCell1 = new PdfPCell(new Phrase(lblBillNoText.Text + "  " + lblCashMemoCounter.Text
                        , CalculateFont(_billHeaderTxtSize)));
                //billCounterTableCell1.Colspan = 1;
                billCounterTableCell1.HorizontalAlignment = Element.ALIGN_LEFT;
                billCounterTableCell1.BorderWidth = 0f;

                //Serialnumber or DailyCounter
                PdfPCell billCounterTableCell2 = new PdfPCell(new Phrase(lblSerialText.Text + "  " + lblSerialNumber.Text
                        , CalculateFont(_billHeaderTxtSize)));
                //billCounterTableCell2.Colspan = 1;
                billCounterTableCell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                billCounterTableCell2.BorderWidth = 0f;

                billCounterTable.Rows.Add(new PdfPRow(new PdfPCell[] { billCounterTableCell1, billCounterTableCell2 }));

                //Date            

                PdfPCell billCounterTableCell3 = new PdfPCell(new Phrase(lblDt.Text
                        , CalculateFont(_billHeaderTxtSize)));
                //billCounterTableCell3.Colspan = 1;
                billCounterTableCell3.HorizontalAlignment = Element.ALIGN_LEFT;
                billCounterTableCell3.BorderWidth = 0f;

                //Fortnight
                _billObj.Fortnight = TimeStampHelper.GetFortNight(lblDt.Text);

                PdfPCell billCounterTableCell4 = new PdfPCell(new Phrase("( " + TimeStampHelper.GetFortNightString(lblDt.Text) + " ) "
                        , CalculateFont(_billHeaderTxtSize)));
                //billCounterTableCell3.Colspan = 1;
                billCounterTableCell4.HorizontalAlignment = Element.ALIGN_RIGHT;
                billCounterTableCell4.BorderWidth = 0f;

                billCounterTable.Rows.Add(new PdfPRow(new PdfPCell[] { billCounterTableCell3, billCounterTableCell4 }));

                billCounterTable.CompleteRow();
                para.Add(billCounterTable);

                //Members
                _billObj.TotalCardServed = _memberCount;

                para.Add(new Chunk(Environment.NewLine + "Number of Unit : " + _memberCount
                    , CalculateFont(_billPartHeadingTxtSize)));

                int totalCards = grdVwMembers.Rows.Count;
                int totalFamilyMember = grdVwMembers.Rows.Count;

                PdfPTable memberTable = new PdfPTable(1) { WidthPercentage = 100 };
                memberTable.SpacingBefore = 0f;
                memberTable.SpacingAfter = 0f;
                //memberTable.TotalWidth = 226f;
                //memberTable.LockedWidth = true;
                string numbers = "";
                
                foreach (DataGridViewRow item in grdVwMembers.Rows)
                {
                    RationCardDetail lnItem = (RationCardDetail)item.DataBoundItem;
                    numbers += ", " + lnItem.Number;
                }
                _billObj.RationcardNumbers = numbers.TrimStart(',', ' ');

                PdfPCell memberCell2 = new PdfPCell(new Phrase(numbers.TrimStart(',', ' ') + Environment.NewLine + Environment.NewLine
                       , CalculateFont(_billTxtSize)));

                memberCell2.Colspan = 1;
                memberCell2.HorizontalAlignment = Element.ALIGN_LEFT;
                memberCell2.BorderWidth = 0f;
                memberTable.AddCell(memberCell2);
                para.Add(memberTable);

                //Items
                //para.Add(new Chunk(lblItemsText.Text
                //    , new iTextSharp.text.Font(BaseFont.CreateFont(@"C:\Windows\Fonts\ARLRDBD.TTF", BaseFont.IDENTITY_H,
                //        BaseFont.EMBEDDED), _billPartHeadingTxtSize)));

                PdfPTable itemTable = new PdfPTable(21) { WidthPercentage = 100 };
                itemTable.SpacingBefore = 0f;
                itemTable.SpacingAfter = 0f;
                itemTable.TotalWidth = 226f;
                itemTable.LockedWidth = true;

                //HeaderCell                
                PdfPCell headerCell0 = new PdfPCell(new Phrase("SlNo."
                       , CalculateFont(_billTxtSize)));
                headerCell0.Colspan = 2;
                headerCell0.HorizontalAlignment = Element.ALIGN_LEFT;
                headerCell0.BorderWidth = 0f;
                itemTable.AddCell(headerCell0);

                PdfPCell headerCell1 = new PdfPCell(new Phrase("Commodity"
                        , CalculateFont(_billTxtSize)));
                headerCell1.Colspan = 7;
                headerCell1.HorizontalAlignment = Element.ALIGN_LEFT;
                headerCell1.BorderWidth = 0f;
                itemTable.AddCell(headerCell1);

                PdfPCell headerCell2 = new PdfPCell(new Phrase("Quantity"
                   , CalculateFont(_billTxtSize)));
                headerCell2.Colspan = 4;
                headerCell2.HorizontalAlignment = Element.ALIGN_LEFT;
                headerCell2.BorderWidth = 0f;
                itemTable.AddCell(headerCell2);

                PdfPCell headerCell3 = new PdfPCell(new Phrase("Rate"
                   , CalculateFont(_billTxtSize)));
                headerCell3.Colspan = 4;
                headerCell3.HorizontalAlignment = Element.ALIGN_LEFT;
                headerCell3.BorderWidth = 0f;
                itemTable.AddCell(headerCell3);

                PdfPCell headerCell4 = new PdfPCell(new Phrase("Price"
                   , CalculateFont(_billTxtSize)));
                headerCell4.Colspan = 4;
                headerCell4.HorizontalAlignment = Element.ALIGN_LEFT;
                headerCell4.BorderWidth = 0f;
                itemTable.AddCell(headerCell4);

                //PdfPCell headerCell5 = new PdfPCell(new Phrase("Discount"
                //   , CalculateFont(_billTxtSize)));
                //headerCell5.Colspan = 2;
                //headerCell5.HorizontalAlignment = Element.ALIGN_LEFT;
                //headerCell5.BorderWidth = 0f;
                //itemTable.AddCell(headerCell5);

                int itemCount = 0;

                foreach (DataGridViewRow item in grdVwItems.Rows)
                {
                    Product lnItem = (Product)item.DataBoundItem;
                    //_billObj.BillDetails.Add(new BillDetails { ProductsSold = lnItem });

                    PdfPCell itemCell0 = new PdfPCell(new Phrase((itemCount + 1).ToString()
                        , CalculateFont(_billTxtSize)));
                    itemCell0.Colspan = 2;
                    itemCell0.HorizontalAlignment = Element.ALIGN_LEFT;
                    itemCell0.BorderWidth = 0f;
                    itemTable.AddCell(itemCell0);

                    PdfPCell itemCell1 = new PdfPCell(new Phrase(lnItem.Name
                        , CalculateFont(_billTxtSize)));
                    itemCell1.Colspan = 7;
                    itemCell1.HorizontalAlignment = Element.ALIGN_LEFT;
                    itemCell1.BorderWidth = 0f;
                    itemTable.AddCell(itemCell1);

                    PdfPCell itemCell2 = new PdfPCell(new Phrase(lnItem.ConsumptionQuantityToDisplay
                       , CalculateFont(_billTxtSize)));
                    itemCell2.Colspan = 4;
                    itemCell2.HorizontalAlignment = Element.ALIGN_LEFT;
                    itemCell2.BorderWidth = 0f;
                    itemTable.AddCell(itemCell2);

                    PdfPCell itemCell3 = new PdfPCell(new Phrase(lnItem.SellingRateInCurrentUomDisplay
                       , CalculateFont(_billTxtSize)));
                    itemCell3.Colspan = 4;
                    itemCell3.HorizontalAlignment = Element.ALIGN_LEFT;
                    itemCell3.BorderWidth = 0f;
                    itemTable.AddCell(itemCell3);

                    PdfPCell itemCell4 = new PdfPCell(new Phrase(lnItem.PriceToDisplay
                       , CalculateFont(_billTxtSize)));
                    itemCell4.Colspan = 4;
                    itemCell4.HorizontalAlignment = Element.ALIGN_LEFT;
                    itemCell4.BorderWidth = 0f;
                    itemTable.AddCell(itemCell4);

                    //PdfPCell itemCell5 = new PdfPCell(new Phrase(lnItem.DiscountToDisplay
                    //   , CalculateFont(_billTxtSize)));
                    //itemCell5.Colspan = 2;
                    //itemCell5.HorizontalAlignment = Element.ALIGN_LEFT;
                    //itemCell5.BorderWidth = 0f;
                    //itemTable.AddCell(itemCell5);

                    itemCount++;
                }
                para.Add(itemTable);

                //Devider
                para.Add(new Chunk("         ---------------------------------------------------------------------------------------------    "
                    , CalculateFont(_billTxtSize)));

                float convertedNum = 0;
                //Total Price
                PdfPTable priceTable = new PdfPTable(2) { WidthPercentage = 80 };
                priceTable.SpacingBefore = 0f;
                priceTable.SpacingAfter = 0f;

                //Total
                _billObj.TotalPrice = float.TryParse(lblCustomerToPayRs.Text, out convertedNum) ? convertedNum : 0;

                PdfPCell priceCell1 = new PdfPCell(new Phrase(lblTotal.Text
                       , CalculateFont(_billPartHeadingTxtSize)));
                priceCell1.Colspan = 1;
                priceCell1.HorizontalAlignment = Element.ALIGN_LEFT;
                priceCell1.BorderWidth = 0f;

                PdfPCell priceCell2 = new PdfPCell(new Phrase(lblCustomerToPayRs.Text
                       , CalculateFont(_billPartHeadingTxtSize)));
                priceCell2.Colspan = 1;
                priceCell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                priceCell2.BorderWidth = 0f;

                priceTable.Rows.Add(new PdfPRow(new PdfPCell[] { priceCell1, priceCell2 }));

                //Total Roundedoff
                _billObj.TotalRoundedOff = float.TryParse(lblTotalRsRounded.Text, out convertedNum) ? convertedNum : 0;

                PdfPCell priceCell3 = new PdfPCell(new Phrase(lblTotalRoundedOff.Text
                       , CalculateFont(_billPartHeadingTxtSize)));
                priceCell3.Colspan = 1;
                priceCell3.HorizontalAlignment = Element.ALIGN_LEFT;
                priceCell3.BorderWidth = 0f;

                PdfPCell priceCell4 = new PdfPCell(new Phrase(lblTotalRsRounded.Text
                       , CalculateFont(_billPartHeadingTxtSize)));
                priceCell4.Colspan = 1;
                priceCell4.HorizontalAlignment = Element.ALIGN_RIGHT;
                priceCell4.BorderWidth = 0f;

                priceTable.Rows.Add(new PdfPRow(new PdfPCell[] { priceCell3, priceCell4 }));

                //Discount
                _billObj.TotalDiscount = float.TryParse(lblDiscount.Text, out convertedNum) ? convertedNum : 0;

                //PdfPCell priceCell5 = new PdfPCell(new Phrase(lblDiscountText.Text
                //       , CalculateFont(_billPartHeadingTxtSize)));
                //priceCell5.Colspan = 1;
                //priceCell5.HorizontalAlignment = Element.ALIGN_LEFT;
                //priceCell5.BorderWidth = 0f;

                //PdfPCell priceCell6 = new PdfPCell(new Phrase(lblDiscount.Text
                //       , CalculateFont(_billPartHeadingTxtSize)));
                //priceCell6.Colspan = 1;
                //priceCell6.HorizontalAlignment = Element.ALIGN_RIGHT;
                //priceCell6.BorderWidth = 0f;

                //priceTable.Rows.Add(new PdfPRow(new PdfPCell[] { priceCell5, priceCell6 }));

                //CustomerPaid
                _billObj.CustomerPaid = float.TryParse(txtCustPaid.Text, out convertedNum) ? convertedNum : 0;

                PdfPCell priceCell7 = new PdfPCell(new Phrase(lblCustomerPaid.Text
                       , CalculateFont(_billPartHeadingTxtSize)));
                priceCell7.Colspan = 1;
                priceCell7.HorizontalAlignment = Element.ALIGN_LEFT;
                priceCell7.BorderWidth = 0f;

                PdfPCell priceCell8 = new PdfPCell(new Phrase(txtCustPaid.Text
                       , CalculateFont(_billPartHeadingTxtSize)));
                priceCell8.Colspan = 1;
                priceCell8.HorizontalAlignment = Element.ALIGN_RIGHT;
                priceCell8.BorderWidth = 0f;

                priceTable.Rows.Add(new PdfPRow(new PdfPCell[] { priceCell7, priceCell8 }));

                //Balance
                _billObj.BalanceReturn = float.TryParse(lblBalRs.Text, out convertedNum) ? convertedNum : 0;

                PdfPCell priceCell9 = new PdfPCell(new Phrase(lblBalance.Text
                       , CalculateFont(_billPartHeadingTxtSize)));
                priceCell9.Colspan = 1;
                priceCell9.HorizontalAlignment = Element.ALIGN_LEFT;
                priceCell9.BorderWidth = 0f;

                PdfPCell priceCell10 = new PdfPCell(new Phrase(lblBalRs.Text
                       , CalculateFont(_billPartHeadingTxtSize)));
                priceCell10.Colspan = 1;
                priceCell10.HorizontalAlignment = Element.ALIGN_RIGHT;
                priceCell10.BorderWidth = 0f;

                priceTable.Rows.Add(new PdfPRow(new PdfPCell[] { priceCell9, priceCell10 }));

                priceTable.CompleteRow();
                para.Add(priceTable);

                //Disclaimer
                para.Add(new Chunk("         ----------------------------------------------------------------------------------------------    "
                    + Environment.NewLine + "N.B. Please check your item count and quantity, compare with bill and count your cash and balance before leaving the counter."
                    , CalculateFont(_billNotificationTxtSize)));


                para.Add(new Chunk(Environment.NewLine));

                _chnkHeight = 0;
                _chnkWidth = Utilities.MillimetersToPoints(80);
                while (true)
                {
                    _chnkHeight += 10;
                    iTextSharp.text.Document tmpPdfDoc = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(_chnkWidth, _chnkHeight), 0, 0, 0, 0);
                    PdfWriter tmpPdfWriter = PdfWriter.GetInstance(tmpPdfDoc, flStrm);
                    tmpPdfDoc.Open();
                    tmpPdfDoc.Add(para);
                    if(tmpPdfWriter.PageNumber == 1)
                    {
                        tmpPdfWriter.CloseStream = false;
                        tmpPdfDoc.Close();
                        tmpPdfWriter.Close();
                        break;
                    }
                    tmpPdfWriter.CloseStream = false;
                    tmpPdfDoc.Close();
                    tmpPdfWriter.Close();
                }                

                iTextSharp.text.Rectangle pgSize = new iTextSharp.text.Rectangle(_chnkWidth, _chnkHeight);
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(pgSize, 0, 0, 0, 0);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, flStrm);
                pdfDoc.Open();
                pdfDoc.Add(para);
                pdfWriter.CloseStream = true;
                
                pdfDoc.Close();
                flStrm.Close();
                pdfWriter.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return _billObj;
        }
        
        private void SaveBill()
        {
            var billObj = SaveBillToDrive();

            //Fire & Forget save bills to db
            //Add DB save as task for parallelism
            DBSaveManager.AddTaskToBillSaveQueue(billObj);

            FrmFrontDeskEntry frm = (FrmFrontDeskEntry)FormHelper.OpenFrmFrontDeskEntry();
            ((DataGridView)frm.Controls["grdVwSearchResult"]).DataSource = null;
            ((Label)frm.Controls["lblCardCount"]).Text = "";            
            FormHelper.CloseFrmPrdQuantityInBill();            
            ((TextBox)frm.Controls["txtRationcardNumber"]).Focus();
            FormHelper.CloseRationBillDetails();
        }

        private void cmbCommodity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bool isProductToAdd = true;
                if ((_isDrpClicked && (string.IsNullOrEmpty(_keys)))
                    ||(!string.IsNullOrEmpty(_keys)))
                {
                    Product prd;
                    if (string.IsNullOrEmpty(_keys))
                    {
                        prd = MasterData.PrdData.Data.Find(i => i.Name.Equals(((Product)cmbCommodity.SelectedItem).Name));
                    }
                    else
                    {
                        prd = MasterData.PrdData.Data.Find(i => (i.BarCode == _keys) || (i.Name == _keys));
                    }
                    _keys = "";
                    _isDrpClicked = false;
                    if (prd != null)
                    {
                        //check for duplicate product
                        foreach (DataGridViewRow row in grdVwItems.Rows)
                        {
                            if (row.Cells["Name"].Value.ToString() == prd.Name)
                            {
                                isProductToAdd = false;
                                if(prd.IsDefaultProduct)
                                {
                                    MessageBox.Show(prd.Name + " already added.");
                                }
                                else
                                {
                                    MessageBox.Show(prd.Name + " already added. Please change the quantity if you want.");
                                }                                
                            }
                        }
                        if (isProductToAdd)
                        {
                            if (!prd.IsDefaultProduct)
                            {
                                FormHelper.OpenFrmPrdQuantityInBill(prd);
                            }
                            else
                            {
                                AdddefaultProduct(prd);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No product found with this barcode");
                    }
                }
                else
                {
                    FormHelper.OpenFrmPrdQuantityInBill(((Product)cmbCommodity.SelectedItem));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void AdddefaultProduct(Product prdToAdd)
        {
            try
            {
                List<Product> prdsToAdd = new List<Product>();
                if(prdToAdd != null)
                {
                    prdsToAdd.Add(MasterData.PrdData.Data.Find(i => 
                                            (i.IsDefaultProduct == true) 
                                            && (i.IsDefaultGiveRation == true) 
                                            && (i.Name.Equals(prdToAdd.Name))));
                }
                else
                {
                    _defaultPrds.AddRange(MasterData.PrdData.Data.Select(i => i).Where(i => (i.IsDefaultProduct == true) & (i.IsDefaultGiveRation == true)));
                    prdsToAdd.AddRange(_defaultPrds);
                }

                //Set default quantity for this product according to rationcard category

                foreach (Product prd in prdsToAdd)
                {
                    float quantityToAdd = 0;
                    List<ProductQuantityMaster> familyQnt = prd.PrdQuantityAllocated.FindAll(i => i.IsQuantityForFamily).ToList();
                    List<ProductQuantityMaster> individualQnt = prd.PrdQuantityAllocated.FindAll(i => !i.IsQuantityForFamily).ToList();
                    foreach (ProductQuantityMaster qnt in familyQnt)
                    {
                        List<RationCardDetailExtended> familyCards = _membersToGiveRation.FindAll(i => i.Cat_Id == qnt.CategoryDetails.Cat_Id);
                        if (familyCards.Count > 0)
                        {
                            _billObj.PrdDefaultQuantitySummary += qnt.PrdQuantityListDisplay + Environment.NewLine;
                            quantityToAdd += qnt.DefaultQuantityInBaseUom;
                            if (qnt.DefaultQuantityInBaseUom > 0)
                            {                                
                                _billObj.BillDetails.Add(new BillDetails
                                {
                                    CardCategory = MasterData.Categories.Data.Find(i => i.Cat_Id.Equals(familyCards[0].Card_Category_Id)),
                                    CardNumbers = string.Join(",", familyCards.Select(i => i.Number)),
                                    NumberOfCards = familyCards.Count,
                                    ProductsSold = prd
                                });
                            }
                        }
                    }

                    foreach (ProductQuantityMaster qnt in individualQnt)
                    {
                        List<RationCardDetailExtended> individualCards = _membersToGiveRation.FindAll(i => i.Cat_Id == qnt.CategoryDetails.Cat_Id);
                        if (individualCards.Count > 0)
                        {
                            _billObj.PrdDefaultQuantitySummary += qnt.PrdQuantityListDisplay + ",";
                            quantityToAdd += qnt.DefaultQuantityInBaseUom * individualCards.Count;
                            if (qnt.DefaultQuantityInBaseUom > 0)
                            {
                                _billObj.BillDetails.Add(new BillDetails
                                {
                                    CardCategory = MasterData.Categories.Data.Find(i => i.Cat_Id.Equals(individualCards[0].Card_Category_Id)),
                                    CardNumbers = string.Join(",", individualCards.Select(i => i.Number)),
                                    NumberOfCards = individualCards.Count,
                                    ProductsSold = prd
                                });
                            }
                        }
                    }
                    if(quantityToAdd > 0)
                    {
                        _items.Add(prd);
                    }
                    prd.ConsumptionQuantity = quantityToAdd;

                    //unit of mesure as base uom for default product
                    prd.UnitOfMeasure = prd.BaseUom.UOMName;
                    prd.UnitOfMeasureDetail = prd.BaseUom;

                    if ((_billObj != null) && (_billObj.PrdDefaultQuantitySummary != null))
                    {
                        _billObj.PrdDefaultQuantitySummary.TrimEnd(',');
                    }
                }

                BindProductGrid();
                CalculatePriceSummary();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        public void AddProduct(Product prd)
        {
            try
            {
                Product selectedItem;
                if (prd == null)
                {
                    selectedItem = (Product)cmbCommodity.SelectedItem;
                }
                else
                {
                    selectedItem = prd;
                }
                selectedItem.ConsumptionQuantity = prd.ConsumptionQuantity;
                selectedItem.UnitOfMeasureDetail = prd.UnitOfMeasureDetail;
                selectedItem.UnitOfMeasure = prd.UnitOfMeasure;

                _billObj.BillDetails.Add(new BillDetails
                {
                    CardCategory = new Category(),
                    CardNumbers = string.Join(",", _membersToGiveRation),
                    NumberOfCards = _membersToGiveRation.Count,
                    ProductsSold = selectedItem
                });

                _items.Add(selectedItem);
                BindProductGrid();
                CalculatePriceSummary();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void BindProductGrid()
        {
            try
            {
                grdVwItems.DataSource = null;
                grdVwItems.DataSource = _items;

                //make unneccesary fileds hidden
                grdVwItems.Columns["UnitOfMeasureDetail"].Visible = false;
                grdVwItems.Columns["UnitOfMeasure"].Visible = false;
                grdVwItems.Columns["ConsumptionQuantity"].Visible = false;
                grdVwItems.Columns["Active"].Visible = false;
                grdVwItems.Columns["Product_Master_Identity"].Visible = false;

                grdVwItems.Columns["SellingRateInBaseUom"].Visible = false;
                grdVwItems.Columns["BuyingRateInBaseUom"].Visible = false;
                grdVwItems.Columns["MrpRateInBaseUom"].Visible = false;
                grdVwItems.Columns["SellingRateInCurrentUom"].Visible = false;
                grdVwItems.Columns["BuyingRateInCurrentUomDisplay"].Visible = false;
                grdVwItems.Columns["BuyingRateInCurrentUom"].Visible = false;
                grdVwItems.Columns["MrpRateInCurrentUom"].Visible = false;
                grdVwItems.Columns["Discount"].Visible = false;
                grdVwItems.Columns["Total"].Visible = false;
                grdVwItems.Columns["Price"].Visible = false;

                grdVwItems.Columns["ArticleCode"].Visible = false;
                grdVwItems.Columns["ProdDescription"].Visible = false;
                grdVwItems.Columns["BaseUom"].Visible = false;
                grdVwItems.Columns["IsDefaultProduct"].Visible = false;
                grdVwItems.Columns["IsDefaultGiveRation"].Visible = false;

                grdVwItems.Columns["ProductDept"].Visible = false;
                grdVwItems.Columns["ProductSubDept"].Visible = false;
                grdVwItems.Columns["ProductClass"].Visible = false;
                grdVwItems.Columns["ProductSubClass"].Visible = false;
                grdVwItems.Columns["ProductMc"].Visible = false;
                grdVwItems.Columns["ProductBrand"].Visible = false;

                grdVwItems.Columns["Name"].HeaderText = "Commodity";
                grdVwItems.Columns["Name"].DisplayIndex = 0;
                grdVwItems.Columns["Name"].Width = 200;
                grdVwItems.Columns["Name"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                grdVwItems.Columns["ConsumptionQuantityToDisplay"].HeaderText = "No.";
                grdVwItems.Columns["ConsumptionQuantityToDisplay"].DisplayIndex = 1;
                grdVwItems.Columns["ConsumptionQuantityToDisplay"].Width = 80;
                grdVwItems.Columns["ConsumptionQuantityToDisplay"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                grdVwItems.Columns["MrpRateInCurrentUomDisplay"].HeaderText = "MRP";
                grdVwItems.Columns["MrpRateInCurrentUomDisplay"].DisplayIndex = 2;
                grdVwItems.Columns["MrpRateInCurrentUomDisplay"].Width = 80;
                grdVwItems.Columns["MrpRateInCurrentUomDisplay"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                grdVwItems.Columns["SellingRateInCurrentUomDisplay"].HeaderText = "Rate";
                grdVwItems.Columns["SellingRateInCurrentUomDisplay"].DisplayIndex = 3;
                grdVwItems.Columns["SellingRateInCurrentUomDisplay"].Width = 80;
                grdVwItems.Columns["SellingRateInCurrentUomDisplay"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                grdVwItems.Columns["TotalToDisplay"].HeaderText = "Total";
                grdVwItems.Columns["TotalToDisplay"].DisplayIndex = 4;
                grdVwItems.Columns["TotalToDisplay"].Width = 80;
                grdVwItems.Columns["TotalToDisplay"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                grdVwItems.Columns["PriceToDisplay"].HeaderText = "Price";
                grdVwItems.Columns["PriceToDisplay"].DisplayIndex = 5;
                grdVwItems.Columns["PriceToDisplay"].Width = 80;
                grdVwItems.Columns["PriceToDisplay"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                grdVwItems.Columns["DiscountToDisplay"].HeaderText = "Discount";
                grdVwItems.Columns["DiscountToDisplay"].DisplayIndex = 6;
                grdVwItems.Columns["DiscountToDisplay"].Width = 80;
                grdVwItems.Columns["DiscountToDisplay"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);


                grdVwItems.Columns["BarCode"].HeaderText = "BarCode";
                grdVwItems.Columns["BarCode"].DisplayIndex = 7;
                grdVwItems.Columns["BarCode"].Width = 150;
                grdVwItems.Columns["BarCode"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);

                grdVwItems.Refresh();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtCustPaid_KeyDown(object sender, KeyEventArgs e)
        {
            double convertedNum = 0;
            ValidationHelper.ValidateDecimal(sender, e);
            double paid = double.TryParse(txtCustPaid.Text.Trim(), out convertedNum) ? convertedNum : 0;
            double toBePaid = double.TryParse(lblTotalRoundedOff.Text, out convertedNum) ? convertedNum : 0;
            lblBalRs.Text = (paid - toBePaid).ToString();
        }

        private void btnDelitem_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVwItems.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in grdVwItems.SelectedRows)
                    {
                        string prdName = row.Cells["Name"].Value.ToString();
                        _billObj.BillDetails.RemoveAll(i => i.ProductsSold.Name == prdName);                                            
                        _items.RemoveAll(i => i.Name == prdName);
                        BindProductGrid();
                    }
                }
                else
                {
                    MessageBox.Show("Please select an item to delete");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        
        private void cmbCommodity_KeyPress(object sender, KeyPressEventArgs e)
        {            
            _keys += e.KeyChar.ToString();
        }

        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            SaveBill();
            PrintHelper.PrintBill(_billSavePath + _fileName, _billPrintNumberOfCopies, _chnkHeight, _chnkWidth);
        }        
        private void btnSaveBill_Click(object sender, EventArgs e)
        {
            SaveBill();
        }

        private void grdVwMembers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                var rowNo = grdVwMembers.Rows.Count;
                var totalRowHeight = grdVwMembers.Rows.GetRowsHeight(new DataGridViewElementStates());
                var rowHeight = totalRowHeight / rowNo;
                grdVwMembers.Width = grdVwMembers.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed);
                grdVwMembers.Height = rowHeight * (rowNo + 1);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void grdVwItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Product prd = MasterData.PrdData.Data.Find(i => i.Name == grdVwItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());            
            if (!prd.IsDefaultProduct)
            {
                FormHelper.OpenFrmPrdQuantityInBill(prd);
            }
        }

        private void txtCustPaid_TextChanged(object sender, EventArgs e)
        {
            CalculatePriceSummary();
        }

        private void txtCustPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                btnSaveAndPrint_Click(sender, (EventArgs) e);
            }
        }

        private void cmbCommodity_Leave(object sender, EventArgs e)
        {
            txtCustPaid.Focus();
        }

        private void cmbCommodity_MouseClick(object sender, MouseEventArgs e)
        {
            _isDrpClicked = true;
        }
    }
}

