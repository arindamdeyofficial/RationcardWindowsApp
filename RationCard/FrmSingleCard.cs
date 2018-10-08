using RationCard.Helper;
using RationCard.Model;
using System;
using System.Windows.Forms;

namespace RationCard
{
    public partial class FrmSingleCard : Form
    {
        public FrmSingleCard()
        {
            InitializeComponent();           
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Hide();
            PrintHelper.PrintForm(this, printDocument1, "A4", "L");
            this.Close();
        }

        private void FrmSingleCard_Load(object sender, EventArgs e)
        {
            lblDealerName.Text = User.Name;
            lblLiscenceNo.Text = User.LiscenceNo;
            lblMRShopNo.Text = User.MrShopNo;
            lblDtToday.Text = DateTime.Now.ToLongDateString();
        }
    }
}
