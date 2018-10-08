using RationCard.Helper;
using RationCard.MasterDataManager;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RationCard
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();            
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            Logger.LogErrorIntoDb();
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            MasterDataHelper.FetchMasterData();
            lblName.Text = User.Name;
            lblMobileNo.Text = User.MobileNo;
            lblEmail.Text = User.EmailId;
            lblLoginId.Text = User.LoginId;
            Logger.LogInfo((Directory.GetCurrentDirectory() + User.ProfilePicPath).Replace(@"\bin\Debug", "") + Environment.NewLine);
            picProfile.Image = Image.FromFile((Directory.GetCurrentDirectory() + User.ProfilePicPath).Replace(@"\bin\Debug", ""));

#if DEBUG
            //Automatic login
            if (User.IsSuperadmin)
            {
                txtPass.Text = User.Password;
                //this.Visible = false;
                this.Opacity = 0;
                this.ShowInTaskbar = false;
                DoLogin(lblLoginId.Text, txtPass.Text);
            }
#endif
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DoLogin(lblLoginId.Text, txtPass.Text);
        }

        private void DoLogin(string userId, string password)
        {
            string msg = string.Empty;
            if(UserHelper.DoLogin(userId, password, User.MacId, out msg))
            {
                FormHelper.OpenFrmRationcardHome();
                this.Visible = false;
            }
            else
            {
                txtMsg.Text = msg;
            }            
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13)
            {
                DoLogin(lblLoginId.Text, txtPass.Text);
            }
        }
    }
}
