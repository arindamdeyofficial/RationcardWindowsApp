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
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@distId", SqlDbType = SqlDbType.VarChar, Value = ((Distributor)cmbUserList.SelectedItem).Dist_Id });
                sqlParams.Add(new SqlParameter { ParameterName = "@action", SqlDbType = SqlDbType.VarChar, Value = action });
                DataSet ds = ConnectionManager.Exec("Sp_OrphanCardAndCustomer", sqlParams);

                if ((ds != null) && (ds.Tables.Count > 1))
                {
                    grdVwOrphanCards.DataSource = ds.Tables[0].AsEnumerable().Select(i => new RationCardDetail
                    {
                        RationCard_Id = i.Field<int>("RationCard_Id").ToString(),
                        Number = i.Field<string>("Number"),
                        Card_Category_Id = i.Field<int>("Card_Category_Id").ToString(),
                        Customer_Id = i.Field<int>("Customer_Id").ToString(),
                        Dist_Id = i.Field<int>("Dist_Id").ToString(),
                        Remarks = i.Field<string>("Remarks"),
                        ActiveCard = i.Field<bool>("Active"),
                        Card_Created_Date = i.Field<DateTime>("Created_Date").ToString()
                    }).ToList();

                    grVwOrphanCustomers.DataSource = ds.Tables[1].AsEnumerable().Select(i => new Customer
                    {
                        Customer_Id = i.Field<int>("Customer_Id").ToString(),
                        Name = i.Field<string>("Name"),
                        Hof_Flag = i.Field<bool>("Hof_Flag").ToString(),
                        Age = i.Field<int>("Age").ToString(),
                        Address = i.Field<string>("Address"),
                        RationCard_Id = i.Field<string>("RationCard_Id").ToString(),
                        Hof_Id = i.Field<int>("Hof_Id").ToString(),
                        Dist_Id = i.Field<int>("Dist_Id").ToString(),
                        Adhar_No = i.Field<string>("Adhar_No"),
                        Relation_With_Hof = i.Field<string>("Relation_With_Hof"),
                        Gaurdian_Name = i.Field<string>("Gaurdian_Name"),
                        Mobile_No = i.Field<string>("Mobile_No"),
                        ActiveCustomer = i.Field<bool>("Active"),
                        Customer_Created_Date = i.Field<DateTime>("Created_Date").ToString()
                    }).ToList();
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
