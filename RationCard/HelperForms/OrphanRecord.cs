using RationCard.DbSaveFireAndForget;
using RationCard.Helper;
using RationCard.MasterDataManager;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RationCard.HelperForms
{
    public partial class OrphanRecord : Form
    {
        public OrphanRecord()
        {
            InitializeComponent();
        }

        private void OrphanRecord_Load(object sender, EventArgs e)
        {
            cmbUserList.DataSource = MasterData.Distributors.Data;
            cmbUserList.DisplayMember = "Dist_Name";
            cmbUserList.ValueMember = "Dist_Login";
            cmbUserList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbUserList.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbUserList.SelectedItem = MasterData.Distributors.Data.FirstOrDefault(i => i.Dist_Login == User.LoginId);
        }
        public void OperateOrphanRecords(string action)
        {
            bool isSuccess = false;
            var rationCards = new List<RationCardDetail>();
            var customers = new List<Customer>();

            try
            {
                string distId = ((Distributor)cmbUserList.SelectedItem).Dist_Id;
                DBSaveManager.OperateOrphanRecords(distId, action, out isSuccess, out rationCards, out customers);

                if (isSuccess)
                {
                    grdVwOrphanCards.DataSource = rationCards;
                    grVwOrphanCustomers.DataSource = customers;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtFetchOrphanRecords_Click(object sender, EventArgs e)
        {
            OperateOrphanRecords("VIEW");
        }

        private void txtLoginId_Leave(object sender, EventArgs e)
        {
            OperateOrphanRecords("VIEW");
        }

        private void cmbUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OperateOrphanRecords("VIEW");
        }

        private void btnOrphanRecord_Click(object sender, EventArgs e)
        {
            OperateOrphanRecords("DELETE");
        }
    }
}
