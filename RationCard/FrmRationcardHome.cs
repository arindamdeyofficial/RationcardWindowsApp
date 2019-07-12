using RationCard.Helper;
using RationCard.Model;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using RationCard.MasterDataManager;
using System.Configuration;
using System.Collections.Generic;

namespace RationCard
{
    public partial class FrmRationcardHome : Form
    {
        public FrmRationcardHome()
        {
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    control.Visible = !MasterData.Roles.Data.Any(i => i.ControlIdToHide == control.Name); 
                }
            }
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
                    case "stock":
                        FormHelper.OpenFrmStockSummary();
                        break;
                }
                txtChoice.Text = "";
            }
        }

        private void FrmRationcardHome_Load(object sender, EventArgs e)
        {            
            if (!User.IsSuperadmin)
            {
                btnAdmin.Visible = false;
            }
            txtChoice.Focus();
        }

        private void FrmRationcardHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
        private void btnStock_Click(object sender, EventArgs e)
        {
            string password = DialogConfirm.ShowInputDialog("Please provide password to continue.", "Confirm with Password");
            try
            {
                string finalPass = SecurityEncrypt.Decrypt(ConfigurationManager.AppSettings["CriticalSectionPassword"].ToString(), "nakshal");

                if ((User.IsSuperadmin) || (password == finalPass))
                {
                    FormHelper.OpenFrmStockSummary();
                }
                else if (password == "")
                {
                    MessageBox.Show("Stock openning is discarded by the user");
                }
                else
                {
                    MessageBox.Show("Wrong Password. Stock needs extra permission to open. Please provide correct password.");
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }             
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FormHelper.OpenHelperMaster();
        }
    }
}
