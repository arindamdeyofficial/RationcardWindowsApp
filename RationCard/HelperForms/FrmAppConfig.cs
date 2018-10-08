using RationCard.Helper;
using RationCard.MasterDataManager;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RationCard.HelperForms
{
    public partial class FrmAppConfig : Form
    {
        public FrmAppConfig()
        {
            InitializeComponent();
        }

        private void FrmAppConfig_Load(object sender, EventArgs e)
        {            
            cmbUserList.DataSource = MasterData.Distributors.Data.FindAll(i=>true);
            cmbUserList.DisplayMember = "Dist_Name";
            cmbUserList.ValueMember = "Dist_Login";
            cmbUserList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbUserList.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbUserList.SelectedItem = MasterData.Distributors.Data.FirstOrDefault(i => i.Dist_Login == User.LoginId);

            cmbCloneFromUserList.DataSource = MasterData.Distributors.Data.FindAll(i => true);
            cmbCloneFromUserList.DisplayMember = "Dist_Name";
            cmbCloneFromUserList.ValueMember = "Dist_Login";
            cmbCloneFromUserList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCloneFromUserList.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCloneFromUserList.SelectedItem = MasterData.Distributors.Data.FirstOrDefault(i => i.Dist_Login == User.LoginId);

            BindGridData();
        }

        private void btnAddOrEditCofig_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                ConfigManager.AddOrEditConfig(((Distributor)cmbUserList.SelectedItem).Dist_Id, txtKeytext.Text, txtKeyValue.Text);
            }
            BindGridData();
        }
        private bool IsValid()
        {
            return !string.IsNullOrEmpty(txtKeytext.Text)
                && !string.IsNullOrEmpty(txtKeyValue.Text);
        }

        private void btnGetConfigs_Click(object sender, EventArgs e)
        {
            BindGridData();
        }

        private void btnRemoveConfig_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in drVwAppConfig.SelectedRows)
            {
                ConfigManager.DeleteConfig(((Distributor)cmbUserList.SelectedItem).Dist_Id, dr.Cells["KeyText"].Value.ToString());
            }
            BindGridData();
        }

        private void cmbUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridData();
        }
        
        private void BindGridData()
        {
           drVwAppConfig.DataSource = null;
           drVwAppConfig.DataSource = ConfigManager.GetConfig(((Distributor)cmbUserList.SelectedItem).Dist_Id);
        }

        private void btnCloneConfig_Click(object sender, EventArgs e)
        {
            ConfigManager.CloneConfig(((Distributor)cmbUserList.SelectedItem).Dist_Id, ((Distributor)cmbCloneFromUserList.SelectedItem).Dist_Id);
            BindGridData();
        }

        private void drVwAppConfig_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKeytext.Text = drVwAppConfig.Rows[e.RowIndex].Cells["KeyText"].Value.ToString();
            txtKeyValue.Text = drVwAppConfig.Rows[e.RowIndex].Cells["ValueText"].Value.ToString();
        }
    }
}
