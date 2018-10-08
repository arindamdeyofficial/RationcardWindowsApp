using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using RationCard.Model;
using RationCard.MasterDataManager;

namespace RationCard.Helper
{
    public static class PrintHelper
    {
        private static string _printerName = ConfigManager.GetConfigValue("PrinterName");
        private static Process p = new Process();
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private static Bitmap memoryImage;
        public static void CaptureScreen(Form formObj)
        {
            try
            {
                Graphics mygraphics = formObj.CreateGraphics();
                Size s = formObj.Size;
                memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
                Graphics memoryGraphics = Graphics.FromImage(memoryImage);
                IntPtr dc1 = mygraphics.GetHdc();
                IntPtr dc2 = memoryGraphics.GetHdc();
                BitBlt(dc2, 0, 0, formObj.ClientRectangle.Width, formObj.ClientRectangle.Height, dc1, 0, 0, 13369376);
                mygraphics.ReleaseHdc(dc1);
                memoryGraphics.ReleaseHdc(dc2);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        public static void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        public static void printDocument1_EndPrintPage(System.Object sender, PrintEventArgs e)
        {
            //KillAdobe("AcroRd32");
        }

        public static void PrintForm(Form frmObj, PrintDocument prntDoc, string size, string pageType)
        {
            try
            {
                PrintHelper.CaptureScreen(frmObj);
                prntDoc.PrintPage += new PrintPageEventHandler(PrintHelper.printDocument1_PrintPage);
                prntDoc.EndPrint += new PrintEventHandler(PrintHelper.printDocument1_EndPrintPage);
                PaperSize ps = new PaperSize();
                switch (size)
                {
                    case "A4": ps.RawKind = (int)PaperKind.A4; break;
                    case "A3": ps.RawKind = (int)PaperKind.A3; break;
                    case "A2": ps.RawKind = (int)PaperKind.A2; break;
                    default: ps.RawKind = (int)PaperKind.A4; break;
                }

                prntDoc.DefaultPageSettings.PaperSize = ps;
                prntDoc.DefaultPageSettings.Landscape = pageType == "L";
                prntDoc.Print();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public static bool PrintBillProcess(string fileName, int numberOfCopies, float height, float width)
        {
            try
            {
                for (var i = 0; i < numberOfCopies; i++)
                {
                    KillAdobe("AcroRd32");
                    //this requires adobe reader to be installed and set as default app for .pdf
                    p = new Process
                    {
                        EnableRaisingEvents = true,
                        StartInfo = new ProcessStartInfo()
                        {
                            CreateNoWindow = true,
                            Arguments = "\"EPSON TM-T82 Receipt\"",
                            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                            UseShellExecute = true,
                            Verb = "PrintTo",
                            FileName = fileName //put the correct path here
                        }
                    };
                    p.Exited += new EventHandler(CloseProcess);
                    p.Start();                    
                }
                //KillAdobe("AcroRd32");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return false;
            }
            return true;
        }

        public static bool PrintBill(string fileName, int numberOfCopies, float height, float width)
        {
            //https://msdn.microsoft.com/en-us/library/bb776883.aspx
            PrintDocument pdoc = new PrintDocument();

            pdoc.DefaultPageSettings.PrinterSettings.PrinterName = _printerName;
            pdoc.DefaultPageSettings.Landscape = false;
            pdoc.DefaultPageSettings.PaperSize = new PaperSize("Custom", (int)Math.Ceiling(width), (int)Math.Ceiling(height));
            
            bool status;
            string printMethod = ConfigManager.GetConfigValue("PrintMethod");
            if(printMethod.Equals("Adobe"))
            {
                status = PrintPdfBill(fileName, numberOfCopies, height, width);
            }
            else
            {
                status = PrintBillProcess(fileName, numberOfCopies, height, width);
            }
            return status;
        }

        public static bool PrintPdfBill(string fileName, int numberOfCopies, float height, float width)
        {
            try
            {
                for (var i = 0; i < numberOfCopies; i++)
                {
                    //this requires adobe reader to be installed and set as default app for .pdf
                    p = new Process
                    {
                        EnableRaisingEvents = true,
                        StartInfo = new ProcessStartInfo()
                        {
                            CreateNoWindow = true,
                            Arguments = String.Format(@"/p /h {0}", fileName),
                            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                            UseShellExecute = false,
                            FileName = @"C:\Program Files (x86)\Adobe\Acrobat Reader DC\Reader\AcroRd32.exe"
                        }
                    };
                    p.Exited += new EventHandler(CloseProcess);
                    p.Start();
                }
                //KillAdobe("AcroRd32");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return false;                
            }
            return true;
        }
        private static void CloseProcess(object sender, System.EventArgs e)
        {
            //KillAdobe("AcroRd32");
            //p.Close();
        }
        private static bool KillAdobe(string name)
        {
            try
            {
                foreach (Process clsProcess in Process.GetProcesses().Where(
                             clsProcess => clsProcess.ProcessName.StartsWith(name)))
                {
                    clsProcess.Kill();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return false;
            }
            return false;
        }        
    }
}
