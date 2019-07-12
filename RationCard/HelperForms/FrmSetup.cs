using RationCard.Helper;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RationCard.HelperForms
{
    public partial class FrmSetup : Form
    {
        public FrmSetup()
        {
            InitializeComponent();
        }

        private void FrmDiagonistics_Load(object sender, EventArgs e)
        {
            
        }

        private void btnFramework_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmFrameworkVersion();
        }

        private void btnMac_Click(object sender, EventArgs e)
        {
            FormHelper.OpenMacId();
        }

        private void btnRegisterMacId_Click(object sender, EventArgs e)
        {
            string successMsg = string.Empty;
            if (IsValid())
            {
                UserHelper.RegisterNewUser(txtName.Text.Trim(), txtMobileNo.Text.Trim(), txtAddress.Text.Trim(), txtEmail.Text.Trim()
                    , txtProfilePicPath.Text.Trim(), txtEmail.Text.Trim(), txtPassword.Text.Trim(), chkckhMacCheck.Checked
                    , txtfpsCode.Text.Trim(), txtFpsLiscenceNo.Text.Trim(), txtMrShopNo.Text.Trim(), txtMac.Text.Trim()
                    , txtMacRemark.Text.Trim(), txtCode.Text.Trim(), out successMsg);
                lblRegisterUserstatus.Text = successMsg;
            }
            else
            {
                MessageBox.Show("Please input all the fields");
            }
        }
        private bool IsValid()
        {
            return !string.IsNullOrEmpty(txtName.Text.Trim())
                && !string.IsNullOrEmpty(txtPassword.Text.Trim())
                && !string.IsNullOrEmpty(txtAddress.Text.Trim())
                && !string.IsNullOrEmpty(txtMobileNo.Text.Trim())
                && !string.IsNullOrEmpty(txtMac.Text.Trim())
                && !string.IsNullOrEmpty(txtMacRemark.Text.Trim())
                && !string.IsNullOrEmpty(txtfpsCode.Text.Trim())
                && !string.IsNullOrEmpty(txtFpsLiscenceNo.Text.Trim())
                && !string.IsNullOrEmpty(txtMrShopNo.Text.Trim())
                && !string.IsNullOrEmpty(txtProfilePicPath.Text.Trim())
                && !string.IsNullOrEmpty(txtCode.Text.Trim())
                && !string.IsNullOrEmpty(txtEmail.Text.Trim());
        }

        private void FrmSetup_Load(object sender, EventArgs e)
        {
            lblDotNetStatus.Text = DotNetrameworks.IsCompatible ? ".Net Framework in up to date" : "Please install .Net Framework 4.5 r later";
            txtMac.Text = Network.GetActiveMACAddress(); 
        }

        private void btnStartUsing_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmLogin();
        }
    }
}
