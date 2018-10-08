using RationCard.Helper;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace RationCard
{
    public partial class FrmRationcardHome : Form
    {
        public FrmRationcardHome()
        {
            InitializeComponent();
        }

        private void btnRationCardHome_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmRationcardHome();
        }

        private void btnFrontDeskEntry_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmFrontDeskEntry();
        }

        private void btnRationCardEntry_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmRationEntry();
        }

        private void btnCardSearch_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmSearchResult();
        }

        private void btnCatwiseCount_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmCatwiseCount();
        }

        private void btnOpenQuickEntryDoc_Click(object sender, EventArgs e)
        {
            using (PrintDialog pd = new PrintDialog())
            {
                ProcessStartInfo info = new ProcessStartInfo(@"image\Barcodes\Barcode Pages.docx");
                Process.Start(info);
            }
        }

        private void txtChoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                switch (txtChoice.Text)
                {
                    case "CardSearch":
                        FormHelper.OpenFrmSearchResult();
                        break;
                    case "CatwiseCount":
                        FormHelper.OpenFrmCatwiseCount();
                        break;
                    case "FrontDeskEntry":
                        FormHelper.OpenFrmFrontDeskEntry();
                        break;
                    case "RationCardEntry":
                        FormHelper.OpenFrmRationEntry();
                        break;
                    case "RationCardHome":
                        FormHelper.OpenFrmRationcardHome();
                        break;
                    default:
                        FormHelper.OpenFrmRationcardHome();
                        break;
                }
                txtChoice.Text = "";
            }
        }

        private void FrmRationcardHome_Load(object sender, EventArgs e)
        {
            //MasterData.MasterDataFetchComplete = true;
            ////Set Masterdatafetch Completion
            //Invoke(new Action(() =>
            //{
            //    lblMasterDataFetchComplete.Text = "Master Data Fetched";
            //}));
            txtChoice.Focus();
        }

        private void FrmRationcardHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
