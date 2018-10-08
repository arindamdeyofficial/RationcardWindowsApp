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

namespace RationCard
{
    public partial class FrmUserSelector : Form
    {
        public FrmUserSelector()
        {
            InitializeComponent();
        }

        private void FrmUserSelector_Load(object sender, EventArgs e)
        {
            MasterData.Distributors = new DistMasterDataTypeWrapper();
            MasterData.Distributors.Refresh();
            cmbUsers.DataSource = MasterData.Distributors.Data;
            cmbUsers.DisplayMember = "Dist_Name";
            cmbUsers.ValueMember = "Dist_Id";
        }

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string msg = string.Empty;
            string userId = "";
            string password = "";
            string macId = "";
            var selectedUserItem = cmbUsers.SelectedItem;
            if(selectedUserItem != null)
            {
                Distributor dist = (Distributor)selectedUserItem;
                if(dist != null)
                {
                    Distributor distObj = MasterData.Distributors.Data.Find(i=>i.Dist_Id == dist.Dist_Id);

                    User.LoginId = distObj.Dist_Login;
                    User.EmailId = distObj.Dist_Email;
                    User.MacId = Network.GetActiveMACAddress();
                    User.AllowedMacId = distObj.Dist_Allowed_Mac_Id;
                    User.Name = distObj.Dist_Name;
                    User.MobileNo = distObj.Dist_Mobile_No;
                    User.DistId = distObj.Dist_Id;
                    User.Address = distObj.Dist_Address;
                    User.ProfilePicPath = distObj.Dist_Profile_Pic_Path;
                    User.Roles = MasterData.Roles.Data;
                    User.LiscenceNo = distObj.Dist_Fps_Liscence_No;
                    User.MrShopNo = distObj.Dist_Mr_Shop_No;
                    User.FpsCode = distObj.Dist_Fps_Code;
                    User.IsSuperadmin = distObj.IsSuperAdmin;
                    User.Password = distObj.Dist_Password;
                    Logger.LogInfo("LoginId: " + User.LoginId + " EmailId: " + User.EmailId + " MacId: " + User.MacId + " AllowedMacId: " + User.AllowedMacId + " Name: " + User.Name
                        + " MobileNo: " + User.MobileNo + " DistId: " + User.DistId + " Address: " + User.Address + " ProfilePicPath: " + User.ProfilePicPath + " Role Count: " + User.Roles.Count
                        + " LiscenceNo: " + User.LiscenceNo + " MrShopNo: " + User.MrShopNo + " FpsCode: " + User.FpsCode);


                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MasterDataHelper.FetchMasterData();
            string msg = string.Empty;
            if (UserHelper.DoLogin(User.LoginId, User.Password, User.AllowedMacId.Split(',').FirstOrDefault(), out msg))
            {
                Logger.LogInfo("Logged in disguise as user \"" + User.LoginId + "\"");
                FormHelper.OpenFrmRationcardHome();
                this.Visible = false;
                try
                {
                    throw new Exception();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
            else
            {
                Logger.LogInfo("unsuccessful Loging in disguise as user \"" + User.LoginId + "\"" + Environment.NewLine + msg);
                DialogConfirm.ShowInformationDialog("Couldnot login.", "Autologin");
            }
        }
    }
}
