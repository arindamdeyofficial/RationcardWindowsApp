using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Linq;

namespace RationCard.Helper
{
    public static class ClsPrint
    {
        #region Variables

        static int iCellHeight = 0; //Used to get/set the datagridview cell height
        static int iTotalWidth = 0; //
        static int iRow = 0;//Used as counter
        static bool bFirstPage = false; //Used to check whether we are printing first page
        static bool bNewPage = false;// Used to check whether we are printing a new page
        static int iHeaderHeight = 0; //Used for the header height
        static StringFormat strFormat; //Used to format the grid rows.
        static ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        static ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        private static PrintDocument _printDocument = new PrintDocument();
        private static DataGridView gw = new DataGridView();
        private static string _ReportHeader;
        private static string _ReportDate;
        private static string _ReportSignature;
        private static string _ReportCriteria;
        static int _printerTopMargin = 100;
        static int _pageCount = 0;
        static bool _isNondrawal;
        static int nonDrawalColToAdd = 18;

        #endregion

        public static void InitiateClsPrint(DataGridView gridview, string ReportHeader, string ReportCriteria, string ReportDate, string ReportSignature)
        {
            _printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            _printDocument.BeginPrint += new PrintEventHandler(PrintDocument_BeginPrint);
            gw = gridview;
            _ReportHeader = ReportHeader;
            _ReportDate = ReportDate;
            _ReportSignature = ReportSignature;
            _ReportCriteria = ReportCriteria;
        }

        public static void PrintForm(DataGridView gridview, string ReportHeader, string ReportCriteria, string ReportDate, string ReportSignature, string pageType, string printSize, string docName, bool isNonDrawal)
        {
            _isNondrawal = isNonDrawal;
            PaperSize ps = new PaperSize();
            if (_isNondrawal)
            {
                ps.RawKind = (int)PaperKind.A3;
            }
            else
            {
                switch (printSize)
                {
                    case "A4": ps.RawKind = (int)PaperKind.A4; break;
                    case "A3": ps.RawKind = (int)PaperKind.A3; break;
                    case "A2": ps.RawKind = (int)PaperKind.A2; break;
                    default: ps.RawKind = (int)PaperKind.A4; break;
                }
            }
            _printDocument.DefaultPageSettings.PaperSize = ps;
            _printDocument.DefaultPageSettings.Landscape = pageType == "L";
            _printDocument.DefaultPageSettings.Margins = new Margins { Top = _printerTopMargin, Bottom = 170, Left = 100, Right = 100 };

            InitiateClsPrint(gridview, ReportHeader, ReportCriteria, ReportDate, ReportSignature);

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

        private static void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                _pageCount++;
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;
                List<DataGridViewColumn> _GridCol = new List<DataGridViewColumn>();
                int colNum = 0;
                colNum = _isNondrawal ? (nonDrawalColToAdd + gw.Columns.Count) : gw.Columns.Count;
                if (gw.Columns.Count > 0)
                {
                    int displayIndexCounter = 0;
                    var genericColToAdd = gw.Columns[gw.Columns.Count - 1];
                    genericColToAdd.HeaderText = "";
                    genericColToAdd.Name = "";
                    genericColToAdd.Width = 50;                    

                    for (var i = 0; i < colNum; i++)
                    {
                        if (gw.Columns.Count > i)
                        {
                            if (!gw.Columns[i].Visible) continue;
                            _GridCol.Add(gw.Columns[i]);
                        }
                        else
                        {
                            genericColToAdd.DisplayIndex = displayIndexCounter;
                            _GridCol.Add(genericColToAdd);
                        }
                        displayIndexCounter++;
                    }
                }
                //foreach (DataGridViewColumn GridCol in gw.Columns)
                //{
                //    if (!GridCol.Visible) continue;
                //    _GridCol.Add(GridCol);
                //}
                _GridCol = _GridCol.OrderBy(i => i.DisplayIndex).ToList();

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in _GridCol)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                        (double)iTotalWidth * (double)iTotalWidth *
                        ((double)e.MarginBounds.Width / (double)iTotalWidth))));
                        if (iTmpWidth > GridCol.Width)
                        {
                             iTmpWidth = GridCol.Width;
                        }
                        if (GridCol.Name == "Address")
                            iTmpWidth = GridCol.Width * 2;
                        else if (GridCol.Name == "Hof_Name")
                            iTmpWidth = GridCol.Width * 2;
                        else if (GridCol.Name == "Name")
                            iTmpWidth = GridCol.Width * 2;
                        else if (GridCol.Name == "Remarks")
                            iTmpWidth = GridCol.Width * 2;
                        else if (GridCol.Name == "FamilyCount")
                            iTmpWidth = GridCol.Width / 2;
                        else
                            iTmpWidth = GridCol.Width;

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }                
                //Loop till all the grid rows not get printed
                while (iRow <= gw.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = gw.Rows[iRow];
                    
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
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
                                new Font(gw.Font.FontFamily,10, FontStyle.Bold),
                                Brushes.Black, new Point(e.MarginBounds.Left, e.MarginBounds.Top));
                            
                            //e.MarginBounds.Top - e.Graphics.MeasureString(_ReportHeader, new Font(gw.Font, FontStyle.Bold), e.MarginBounds.Width).Height

                            //Draw seperating line
                            e.Graphics.DrawLine(Pens.Black, new Point(e.MarginBounds.Left, e.MarginBounds.Top + 50), new Point(e.MarginBounds.Right, e.MarginBounds.Top + 50));

                            //Draw Criteria text
                            e.Graphics.DrawString(_ReportCriteria,
                                new Font(gw.Font.FontFamily, 8, FontStyle.Bold),
                                Brushes.Black, new Point(e.MarginBounds.Left, e.MarginBounds.Top + 55));

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top + 100;
                            foreach (DataGridViewColumn drc in _GridCol)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(drc.HeaderText,
                                    drc.InheritedStyle.Font,
                                    new SolidBrush(drc.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            //Draw Footer
                            e.Graphics.DrawString(_ReportDate,
                                new Font(gw.Font.FontFamily, 10, FontStyle.Bold),
                                Brushes.Black, new Point(e.MarginBounds.Left, e.MarginBounds.Bottom + 40));
                            e.Graphics.DrawString(_ReportSignature,
                               new Font(gw.Font.FontFamily, 10, FontStyle.Bold),
                               Brushes.Black, new Point(e.MarginBounds.Right - 200, e.MarginBounds.Bottom + 40));
                            //Draw Pagenumber
                            e.Graphics.DrawString("Pagenumber #" + _pageCount,
                                new Font(gw.Font.FontFamily, 9, FontStyle.Bold),
                                Brushes.Black, new Point(((e.MarginBounds.Right - e.MarginBounds.Left) / 2), e.MarginBounds.Bottom + 10));

                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        bool isInActive = false;
                        bool isHof = false;
                        List<DataGridViewCell> _GridCell = new List<DataGridViewCell>();
                        
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (!(isInActive || isHof))
                            {
                                isInActive = ((Cel.OwningColumn.DataPropertyName == "CardStatus") && (Cel.Value.ToString() != "Active"));
                                isHof = ((Cel.OwningColumn.DataPropertyName == "Hof_Flag") && (Cel.Value.ToString() == "True"));
                            }
                            if (!Cel.Visible) continue;

                            _GridCell.Add(Cel);
                        }
                        _GridCell = _GridCell.OrderBy(i => i.OwningColumn.DisplayIndex).ToList();
                        
                        //Draw Columns Contents                
                        foreach (DataGridViewCell cell in _GridCell)
                        {
                            if (cell.Value != null)
                            {
                                //Fill with gray if Inactive or HOF
                                if (isInActive || isHof)
                                    e.Graphics.FillRectangle(new SolidBrush(Color.LightGreen),
                                       new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                       (int)arrColumnWidths[iCount], iCellHeight));

                                string val = cell.FormattedValue.ToString();
                                string valToPrint = cell.FormattedValue.ToString().Substring(0, (val.Length <= 40) ? val.Length : 40);

                                e.Graphics.DrawString(valToPrint,
                                    new Font(cell.InheritedStyle.Font.FontFamily,cell.InheritedStyle.Font.Size - 1, ((isHof) ? FontStyle.Regular : 
                                        ((isInActive) ? FontStyle.Strikeout : FontStyle.Regular))),
                                    new SolidBrush(cell.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount] + 1,
                                    (float)iTopMargin + 1,
                                    (int)arrColumnWidths[iCount], (float)iCellHeight),
                                    strFormat);
                            }

                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iCellHeight));
                            iCount++;
                        }
                        if (_isNondrawal)
                        {
                            for (var i = 0; i < nonDrawalColToAdd; i++)
                            {
                                //Drawing Cells Borders 
                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[i + iCount], iTopMargin,
                                    (int)arrColumnWidths[i + iCount], iCellHeight));
                            }
                        }
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
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Center;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;
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
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in gw.Columns)
                {
                    if (!dgvGridCol.Visible) continue;
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

    }
}
