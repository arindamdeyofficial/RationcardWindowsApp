using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Helper;
using RationCard.Model;
using System.Drawing;

namespace RationCard
{
    public partial class FrmCatwiseCount : Form
    {
        FrmRationEntry _frmSource = new FrmRationEntry();
        public FrmCatwiseCount(FrmRationEntry frm)
        {
            InitializeComponent();
            _frmSource = frm;
        }

        public void RefreshGrid(List<Category> catList)
        {
            try
            {
                grdCatwiseCount.DataSource = catList;
                grdCatwiseCount.Columns["Cat_Id"].Visible = false;
                grdCatwiseCount.Columns["Cat_Key"].Visible = false;
                grdCatwiseCount.Columns["Cat_Desc"].HeaderText = "Category";
                grdCatwiseCount.Columns["CardCount"].HeaderText = "Card Count";
                grdCatwiseCount.Columns["FamilyCount"].HeaderText = "Family Count";
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void FrmCatwiseCount_Load(object sender, EventArgs e)
        {
            grdCatwiseCount.DefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);
            RefreshGrid(_frmSource._catWiseCount);
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Hide();
            PrintHelper.PrintForm(this, printDocument1, "A4", "P");
            this.Close();
        }
    }
}
