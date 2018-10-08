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
        private DataSet OperateProductTables(string distId, string tableName, string id, string action)
        {
            DataSet ds = null;
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@distId", SqlDbType = SqlDbType.VarChar, Value = distId });
                sqlParams.Add(new SqlParameter { ParameterName = "@table", SqlDbType = SqlDbType.VarChar, Value = tableName });
                sqlParams.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = id });
                sqlParams.Add(new SqlParameter { ParameterName = "@action", SqlDbType = SqlDbType.VarChar, Value = action });

                ds = ConnectionManager.Exec("Sp_ProductTablesData", sqlParams);

                if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    MessageBox.Show(ds.Tables[ds.Tables.Count - 1].Rows[0][0].ToString() 
                                        + Environment.NewLine 
                                        + ds.Tables[ds.Tables.Count - 1].Rows[0][1].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return ds;
        }

        private void btnGetProduct_Input_Master_Click(object sender, EventArgs e)
        {
            if (cmbUserList.SelectedItem != null)
            {
                BinddrGrProduct_Input_Master(OperateProductTables(((Distributor)cmbUserList.SelectedItem).Dist_Id
                    , "Product_Input_Master", string.Empty, "GET"));
            }
        }
        private void BinddrGrProduct_Input_Master(DataSet tmpData)
        {
            drGrProduct_Input_Master.DataSource = null;
            drGrProduct_Input_Master.DataSource =
            tmpData.Tables[0].AsEnumerable().Select(item => new Product_Input_Master
            {
                Product_Input_Identity = item["Product_Input_Identity"].ToString(),
                Dist_Id = item["Dist_Id"].ToString(),
                Created_Date = item["Created_Date"].ToString(),
                Product_Xml = item["Product_Xml"].ToString()
            }).ToList();
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
