using RationCard.Helper;
using RationCard.MasterDataManager;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace RationCard
{
    public partial class MacId : Form
    {
        public MacId()
        {
            InitializeComponent();
        }


        private void btnAddMacId_Click(object sender, EventArgs e)
        {
            OperateMacId("ADD");
        }

        private void btnRemoveMacId_Click(object sender, EventArgs e)
        {
            OperateMacId("REMOVE");
        }

        private void txtUserLogin_Leave(object sender, EventArgs e)
        {
            OperateMacId("READ");
        }

        private void btnGetMacIds_Click(object sender, EventArgs e)
        {
            OperateMacId("READ");
        }
        private void OperateMacId(string operation)
        {
            lblDbOperationSTatus.Text = "";
            bool isSuccess;
            drVwMacIdAssigned.DataSource = MacHelper.OperateMacId(((Distributor)cmbUserList.SelectedItem).Dist_Id, txtAddMacId.Text, txtMacIdType.Text, txtStartFormName.Text, txtRemarks.Text, operation, out isSuccess);
            lblDbOperationSTatus.Text = isSuccess ? "DB Operation Successful" : "DB Operation Failed";            
        }

        private void MacId_Load(object sender, EventArgs e)
        {
            cmbUserList.DataSource = MasterData.Distributors.Data;
            cmbUserList.DisplayMember = "Dist_Name";
            cmbUserList.ValueMember = "Dist_Login";
            cmbUserList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbUserList.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbUserList.SelectedItem = MasterData.Distributors.Data.FirstOrDefault(i=>i.Dist_Login == User.LoginId);

            lblActiveGateway.Text = Network.GetActiveGateway();
            lblActiveIp.Text = Network.GetActiveIP();
            lblActiveMacId.Text = Network.GetActiveMACAddress();
            lblActivePublicIp.Text = Network.GetPublicIpAddress();
            OperateMacId("READ");
            LoadAppStartHis();
            LoadCmpMac();            
        }

        private void LoadAppStartHis()
        {
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                DataSet ds = ConnectionManager.Exec("Sp_AppStart_Details", sqlParams);

                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    grdVwAppStart.DataSource = ds.Tables[0].AsEnumerable().Select(i => new AppStart
                    {
                        App_Start_His_Id = i.Field<int>("App_Start_His_Id").ToString(),
                        Mac_Id = i["Mac_Id"].ToString(),
                        Ip = i["Internal_Ip"].ToString(),
                        PublicIp = i["Public_Ip"].ToString(),
                        Gateway = i["Gateway_Addr"].ToString(),
                        Created_Date = i["Created_Date"].ToString(),
                        Last_Updated_Date = i["Last_Updated_Date"].ToString(),
                        Updated_by = i["Updated_by"].ToString()
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        private void FlushAppHistory()
        {
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                DataSet ds = ConnectionManager.Exec("Sp_AppStart_Flush", sqlParams);

                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    LoadAppStartHis();
                    MessageBox.Show(ds.Tables[0].Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void LoadCmpMac()
        {
            grViewCompMacs.DataSource = ConnectionManager.GetMACAddresses();
        }

        private void btnAppHistoryFlush_Click(object sender, EventArgs e)
        {
            FlushAppHistory();
        }

        private void btnGetAppHistory_Click(object sender, EventArgs e)
        {
            LoadAppStartHis();
        }

        private void btnGetMacId_Click(object sender, EventArgs e)
        {
            LoadCmpMac();
        }

        private void cmbUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OperateMacId("READ");
        }
    }
}
