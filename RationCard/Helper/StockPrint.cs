using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Linq;
using RationCard.Model;
using System.Data;
using System.Data.SqlClient;

namespace RationCard.Helper
{
    public static class StockPrint
    {
        #region Variables

        static int iCellHeight = 0; //Used to get/set the datagridview cell height
        static int iTotalWidth = 0; //
        static int iRow = 0;//Used as counter
        static bool bFirstPage = false; //Used to check whether we are printing first page
        static bool bNewPage = false;// Used to check whether we are printing a new page
        static int iHeaderHeight = 0; //Used for the header height
        static StringFormat _centreAlignstrFormat; //Used to format the grid rows.
        static StringFormat _leftAlignstrFormat; //Used to format the grid rows.
        static StringFormat _rightAlignstrFormat; //Used to format the grid rows.
        static ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        static ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        private static PrintDocument _printDocument = new PrintDocument();
        private static List<Product> _prds = new List<Product>();
        private static string _ReportHeader;
        private static string _ReportDate;
        private static string _ReportSignature;
        private static string _ReportCriteria;
        static int _printerTopMargin = 100;
        static int _pageCount = 0;
        static int _totalNumOfHeaderColumn = 0;
        static int _totalNumOfColumn = 0;
        static string[] _columnHeader;
        static List<ProductStockReport> _stkToPrint = new List<ProductStockReport>();

        #endregion

        public static void InitiateClsPrint(List<Product> prds, string ReportHeader, string ReportCriteria, string ReportDate, string ReportSignature)
        {
            _printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            _printDocument.BeginPrint += new PrintEventHandler(PrintDocument_BeginPrint);
            _prds = prds
                ;
            _ReportHeader = ReportHeader;
            _ReportDate = ReportDate;
            _ReportSignature = ReportSignature;
            _ReportCriteria = ReportCriteria;
        }

        public static void PrintForm(List<Product> prds, string ReportHeader, string ReportCriteria, string ReportDate, string ReportSignature, string pageType, string printSize, string docName)
        {
            PaperSize ps = new PaperSize();
            ps.RawKind = (int)PaperKind.A3;
            _printDocument.DefaultPageSettings.PaperSize = ps;
            _printDocument.DefaultPageSettings.Landscape = pageType == "L";
            _printDocument.DefaultPageSettings.Margins = new Margins { Top = _printerTopMargin, Bottom = 170, Left = 100, Right = 100 };

            InitiateClsPrint(prds, ReportHeader, ReportCriteria, ReportDate, ReportSignature);

            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = _printDocument;
            printDialog.UseEXDialog = true;
            _printDocument.DocumentName = docName;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                try
                {
                    _printDocument.Print();
                }
                catch(Exception ex)
                {
                    Logger.LogError(ex);
                }
            }

            //Open the print preview dialog
            //PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            //objPPdialog.Document = _printDocument;
            //objPPdialog.ShowDialog();
        }
        public static string DoFormat(Decimal myNumber)
        {
            var s = string.Format("{0:0.00}", myNumber);

            if (s.EndsWith("00"))
            {
                return ((int)(myNumber)).ToString();
            }
            else
            {
                return s;
            }
        }
        private static void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@distId", SqlDbType = SqlDbType.VarChar, Value = User.DistId });
                sqlParams.Add(new SqlParameter { ParameterName = "@dtFrom", SqlDbType = SqlDbType.DateTime, Value = DateTime.Parse("01-01-1900").ToString("MM-dd-yyyy HH:mm:ss") });
                sqlParams.Add(new SqlParameter { ParameterName = "@dtTo", SqlDbType = SqlDbType.DateTime, Value = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") });
                sqlParams.Add(new SqlParameter { ParameterName = "@operation", SqlDbType = SqlDbType.VarChar, Value = string.Empty });

                DataSet ds = ConnectionManager.Exec("Sp_Stockreport", sqlParams);

                if ((ds != null) && (ds.Tables.Count > 1))
                {
                    _totalNumOfColumn = ds.Tables[1].Columns.Count;
                    _totalNumOfHeaderColumn = ds.Tables[0].Columns.Count;
                    _columnHeader = ds.Tables[0].Rows[0].ItemArray.Select(i=>i.ToString()).ToArray();
                    _stkToPrint = ds.Tables[1].AsEnumerable().Select(i => new ProductStockReport
                    {
                        Product_Stock_Report_Identity = i["Product_Stock_Report_Identity"].ToString(),
                        Dist_Id = i["Dist_Id"].ToString(),
                        Prod_Id = i["Prod_Id"].ToString(),
                        Cat_Id = i["Cat_Id"].ToString(),
                        UOM_Id = i["UOM_Id"].ToString(),
                        OpenningBalance = DoFormat(Decimal.Parse(i["OpenningBalance"].ToString())),
                        StockRecieved = DoFormat(Decimal.Parse(i["StockRecieved"].ToString())),
                        TotalStock = DoFormat(Decimal.Parse(i["TotalStock"].ToString())),
                        StockSold = DoFormat(Decimal.Parse(i["StockSold"].ToString())),
                        HandlingLoss = DoFormat(Decimal.Parse(i["HandlingLoss"].ToString())),
                        ClosingBalance = DoFormat(Decimal.Parse(i["ClosingBalance"].ToString())),
                        Created_Date = DateTime.Parse(i["Created_Date"].ToString()).ToShortDateString()
                    }).ToList();
                    _stkToPrint.RemoveAll(i=> !_prds.Any(p=>p.Name.Equals(i.ProdName)));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            try
            {
                _pageCount++;
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                Font stringFont = new Font("Arial", 12);
                int iTmpWidth = 0;
                
                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    for (var i=0; i< _totalNumOfHeaderColumn; i++)
                    {
                        // Set maximum width of string.
                        int stringWidth = 1000;
                        if (i == 0)//Date
                        {
                            iHeaderHeight = (int)(e.Graphics.MeasureString(_columnHeader[i], stringFont, stringWidth)).Height + 20;
                            iTmpWidth = (int)(e.Graphics.MeasureString(_columnHeader[i], stringFont, stringWidth).Width) + 75;
                        }
                        else if (i == 1)//Commodity
                        {
                            iHeaderHeight = (int)(e.Graphics.MeasureString(_columnHeader[i], stringFont, stringWidth)).Height + 20;
                            iTmpWidth = (int)(e.Graphics.MeasureString(_columnHeader[i], stringFont, stringWidth).Width) + 180;
                        }
                        else
                        {
                            iHeaderHeight = (int)(e.Graphics.MeasureString(_columnHeader[i], stringFont, stringWidth)).Height + 20;
                            iTmpWidth = (int)(e.Graphics.MeasureString(_columnHeader[i], stringFont, stringWidth).Width) + 11;
                        }
                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                string prevDate = "";
                string prevCat = "";
                string prevName = "";
                //Loop till all the grid rows not get printed
                while (iRow <= _stkToPrint.Count() - 1)
                {
                    //Set the cell height
                    iCellHeight = 20;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString(_ReportHeader,
                                new Font(stringFont.FontFamily, 10, FontStyle.Bold),
                                Brushes.Black, new Point(e.MarginBounds.Left, e.MarginBounds.Top));
                            
                            //Draw seperating line
                            e.Graphics.DrawLine(Pens.Black, new Point(e.MarginBounds.Left, e.MarginBounds.Top + 50), new Point(e.MarginBounds.Right, e.MarginBounds.Top + 50));

                            //Draw Criteria text
                            e.Graphics.DrawString(_ReportCriteria,
                                new Font(stringFont.FontFamily, 8, FontStyle.Bold),
                                Brushes.Black, new Point(e.MarginBounds.Left, e.MarginBounds.Top + 55));

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top + 100;
                            for (var iCount = 0; iCount < _totalNumOfHeaderColumn; iCount++)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(_columnHeader[iCount],
                                            stringFont,
                                            new SolidBrush(Color.Black),
                                            new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                            (int)arrColumnWidths[iCount], iHeaderHeight), _centreAlignstrFormat);
                            }
                            //Draw Footer
                            e.Graphics.DrawString(_ReportDate,
                                new Font(stringFont.FontFamily, 10, FontStyle.Bold),
                                Brushes.Black, new Point(e.MarginBounds.Left, e.MarginBounds.Bottom + 40));
                            e.Graphics.DrawString(_ReportSignature,
                               new Font(stringFont.FontFamily, 10, FontStyle.Bold),
                               Brushes.Black, new Point(e.MarginBounds.Right - 200, e.MarginBounds.Bottom + 40));
                            //Draw Pagenumber
                            e.Graphics.DrawString("Pagenumber #" + _pageCount,
                                new Font(stringFont.FontFamily, 9, FontStyle.Bold),
                                Brushes.Black, new Point(((e.MarginBounds.Right - e.MarginBounds.Left) / 2), e.MarginBounds.Bottom + 10));

                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        
                        for (var iCount = 0; iCount < _totalNumOfHeaderColumn; iCount++)
                        {
                            //Draw Columns Contents    
                            switch (iCount)
                            {
                                case 0:
                                    e.Graphics.DrawString(((prevDate == _stkToPrint[iRow].Created_Date) ? "" : _stkToPrint[iRow].Created_Date),
                                        new Font(stringFont.FontFamily, stringFont.Size - 1, FontStyle.Regular),
                                        new SolidBrush(Color.Black),
                                        new RectangleF((int)arrColumnLefts[iCount] + 1,
                                        (float)iTopMargin + 1,
                                        (int)arrColumnWidths[iCount], (float)iCellHeight),
                                        _leftAlignstrFormat);
                                    
                                    break;                                
                                case 1:
                                    e.Graphics.DrawString(
                                        (
                                        (prevDate == _stkToPrint[iRow].Created_Date)                                      
                                        && (prevName == _stkToPrint[iRow].ProdName) 
                                        ? "" : _stkToPrint[iRow].ProdName),
                                        new Font(stringFont.FontFamily, stringFont.Size - 1, FontStyle.Regular),
                                        new SolidBrush(Color.Black),
                                        new RectangleF((int)arrColumnLefts[iCount] + 1,
                                        (float)iTopMargin + 1,
                                        (int)arrColumnWidths[iCount], (float)iCellHeight),
                                        _leftAlignstrFormat);
                                    
                                    break;
                                case 2:
                                    e.Graphics.DrawString(
                                        (
                                        (prevDate == _stkToPrint[iRow].Created_Date)
                                        && (prevCat == _stkToPrint[iRow].Cat_Desc)
                                        && (prevName == _stkToPrint[iRow].ProdName)
                                        ? "" : _stkToPrint[iRow].Cat_Desc),
                                        new Font(stringFont.FontFamily, stringFont.Size - 1, FontStyle.Regular),
                                        new SolidBrush(Color.Black),
                                        new RectangleF((int)arrColumnLefts[iCount] + 1,
                                        (float)iTopMargin + 1,
                                        (int)arrColumnWidths[iCount], (float)iCellHeight),
                                        _leftAlignstrFormat);
                                    
                                    break;
                                case 3:                                    
                                    e.Graphics.DrawString(_stkToPrint[iRow].OpenningBalance,
                                        new Font(stringFont.FontFamily, stringFont.Size - 1, FontStyle.Regular),
                                        new SolidBrush(Color.Black),
                                        new RectangleF((int)arrColumnLefts[iCount] + 1,
                                        (float)iTopMargin + 1,
                                        (int)arrColumnWidths[iCount], (float)iCellHeight),
                                        _rightAlignstrFormat);
                                    break;
                                case 4:
                                    e.Graphics.DrawString(_stkToPrint[iRow].StockRecieved,
                                        new Font(stringFont.FontFamily, stringFont.Size - 1, FontStyle.Regular),
                                        new SolidBrush(Color.Black),
                                        new RectangleF((int)arrColumnLefts[iCount] + 1,
                                        (float)iTopMargin + 1,
                                        (int)arrColumnWidths[iCount], (float)iCellHeight),
                                        _rightAlignstrFormat);
                                    break;
                                case 5:
                                    e.Graphics.DrawString(_stkToPrint[iRow].TotalStock,
                                        new Font(stringFont.FontFamily, stringFont.Size - 1, FontStyle.Regular),
                                        new SolidBrush(Color.Black),
                                        new RectangleF((int)arrColumnLefts[iCount] + 1,
                                        (float)iTopMargin + 1,
                                        (int)arrColumnWidths[iCount], (float)iCellHeight),
                                        _rightAlignstrFormat);
                                    break;
                                case 6:
                                    e.Graphics.DrawString(_stkToPrint[iRow].StockSold,
                                       new Font(stringFont.FontFamily, stringFont.Size - 1, FontStyle.Regular),
                                        new SolidBrush(Color.Black),
                                        new RectangleF((int)arrColumnLefts[iCount] + 1,
                                        (float)iTopMargin + 1,
                                        (int)arrColumnWidths[iCount], (float)iCellHeight),
                                        _rightAlignstrFormat);
                                    break;
                                case 7:
                                    e.Graphics.DrawString(_stkToPrint[iRow].HandlingLoss,
                                        new Font(stringFont.FontFamily, stringFont.Size - 1, FontStyle.Regular),
                                        new SolidBrush(Color.Black),
                                        new RectangleF((int)arrColumnLefts[iCount] + 1,
                                        (float)iTopMargin + 1,
                                        (int)arrColumnWidths[iCount], (float)iCellHeight),
                                        _rightAlignstrFormat);
                                    break;
                                case 8:
                                    e.Graphics.DrawString(_stkToPrint[iRow].ClosingBalance,
                                        new Font(stringFont.FontFamily, stringFont.Size - 1, FontStyle.Regular),
                                        new SolidBrush(Color.Black),
                                        new RectangleF((int)arrColumnLefts[iCount] + 1,
                                        (float)iTopMargin + 1,
                                        (int)arrColumnWidths[iCount], (float)iCellHeight),
                                        _rightAlignstrFormat);
                                    break;
                                case 9:
                                    e.Graphics.DrawString("",
                                       new Font(stringFont.FontFamily, stringFont.Size - 1, FontStyle.Regular),
                                        new SolidBrush(Color.Black),
                                        new RectangleF((int)arrColumnLefts[iCount] + 1,
                                        (float)iTopMargin + 1,
                                        (int)arrColumnWidths[iCount], (float)iCellHeight),
                                        _leftAlignstrFormat);
                                    break;
                            }
                            e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iCellHeight));
                        }
                        prevDate = _stkToPrint[iRow].Created_Date;
                        prevName = _stkToPrint[iRow].ProdName;
                        prevCat = _stkToPrint[iRow].Cat_Desc;
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }
                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                Logger.LogError(exc);
            }
        }

        private static void PrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                _centreAlignstrFormat = new StringFormat();
                _centreAlignstrFormat.Alignment = StringAlignment.Center;
                _centreAlignstrFormat.LineAlignment = StringAlignment.Center;
                _centreAlignstrFormat.Trimming = StringTrimming.EllipsisCharacter;

                _leftAlignstrFormat = new StringFormat();
                _leftAlignstrFormat.Alignment = StringAlignment.Near;
                _leftAlignstrFormat.LineAlignment = StringAlignment.Near;
                _leftAlignstrFormat.Trimming = StringTrimming.EllipsisCharacter;

                _rightAlignstrFormat = new StringFormat();
                _rightAlignstrFormat.Alignment = StringAlignment.Far;
                _rightAlignstrFormat.LineAlignment = StringAlignment.Far;
                _rightAlignstrFormat.Trimming = StringTrimming.EllipsisCharacter;

                _printDocument = new PrintDocument();

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iHeaderHeight = 0;
                iCellHeight = 0;
                iRow = 0;
                _pageCount = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 1000;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

    }
}
