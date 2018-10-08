using RationCard.Helper;
using RationCard.MasterDataManager;
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
    public partial class FrmUsers : Form
    {
        public FrmUsers()
        {
            InitializeComponent();
        }

        private void FemUsers_Load(object sender, EventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string successMsg = string.Empty;
            if (IsValid())
            {
                UserHelper.RegisterNewUser(txtName.Text.Trim(), txtMobileNo.Text.Trim(), txtAddress.Text.Trim(), txtEmail.Text.Trim()
                    , txtProfilePicPath.Text.Trim(), txtEmail.Text.Trim(), txtPassword.Text.Trim(), chkckhMacCheck.Checked
                    , txtfpsCode.Text.Trim(), txtFpsLiscenceNo.Text.Trim(), txtMrShopNo.Text.Trim(), txtMac.Text.Trim()
                    , txtMacRemark.Text.Trim(), "ADDUSERBYSUPERADMIN", out successMsg);
                MessageBox.Show(successMsg);
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
                && !string.IsNullOrEmpty(txtEmail.Text.Trim());
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                Distributor dss = MasterData.Distributors.Data.FirstOrDefault(i => i.Dist_Login == ((Distributor)cmbUsers.SelectedItem).Dist_Login);
                if (dss != null)
                {
                    UserHelper.RemoveUser( dss.Dist_Login, out isSuccess);
                }
                if(!isSuccess)
                {
                    MessageBox.Show("User couldn't be removed.");
                }
            }
            else
            {
                MessageBox.Show("Please input all the fields");
            }
        }
    }
}
