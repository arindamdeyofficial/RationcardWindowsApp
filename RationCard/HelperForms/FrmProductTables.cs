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
    public partial class FrmProductTables : Form
    {
        public FrmProductTables()
        {
            InitializeComponent();
        }

        private void FrmProductTables_Load(object sender, EventArgs e)
        {
            cmbUserList.DataSource = MasterData.Distributors.Data;
            cmbUserList.DisplayMember = "Dist_Name";
            cmbUserList.ValueMember = "Dist_Login";
            cmbUserList.SelectedItem = MasterData.Distributors.Data.FirstOrDefault(i => i.Dist_Login == User.LoginId);
            if(cmbUserList.SelectedItem != null)
            {
                OperateProductTables(((Distributor)cmbUserList.SelectedItem).Dist_Id, string.Empty, string.Empty, "GET");
            }
        }
        private List<Product_Input_Master> OperateProductTables(string distId, string tableName, string id, string action)
        {
            bool isSuccess;
            string statusMsg = string.Empty;
            List<Product_Input_Master> prdData = new List<Product_Input_Master>();

            try
            {
                prdData = DBSaveManager.OperateProductTablesAndReturnData(distId, tableName, id, action, out isSuccess, out statusMsg);
                if (isSuccess)
                {
                    MessageBox.Show(statusMsg);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return prdData;
        }

        private void btnGetProduct_Input_Master_Click(object sender, EventArgs e)
        {
            if (cmbUserList.SelectedItem != null)
            {
                BinddrGrProduct_Input_Master(OperateProductTables(((Distributor)cmbUserList.SelectedItem).Dist_Id
                    , "Product_Input_Master", string.Empty, "GET"));
            }
        }
        private void BinddrGrProduct_Input_Master(List<Product_Input_Master> tmpPrdData)
        {
            drGrProduct_Input_Master.DataSource = null;
            drGrProduct_Input_Master.DataSource = tmpPrdData;
        }

        private void btnDelProduct_Master_Click(object sender, EventArgs e)
        {
            if (cmbUserList.SelectedItem != null)
            {
                OperateProductTables(((Distributor)cmbUserList.SelectedItem).Dist_Id, "Product_Master", string.Empty, "DELETE");
            }
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            if (cmbUserList.SelectedItem != null)
            {
                OperateProductTables(((Distributor)cmbUserList.SelectedItem).Dist_Id, "", string.Empty, "DELETE");
            }
        }

        private void BtnRefreshAll_Click(object sender, EventArgs e)
        {

        }
    }
}
