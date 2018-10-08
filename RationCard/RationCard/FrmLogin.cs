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
using Helper;
using RationCard.Model;
using System.Configuration;
using RationCard.Helper;
using System.Threading;

namespace RationCard
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string macAddr = ConnectionManager.GetMACAddress();
                Logger.LogInfo(macAddr);
                lblSupportMsg.Text = ConfigurationManager.AppSettings["SupportMsg"].ToString();
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@mac", SqlDbType = SqlDbType.VarChar, Value = macAddr });
                DataSet ds = ConnectionManager.Exec("SP_App_Start", sqlParams);

                if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["Status"].ToString() == "SUCCESS"))
                {
                    User.LoginId = ds.Tables[0].Rows[0]["Dist_Login"].ToString();
                    User.EmailId = ds.Tables[0].Rows[0]["Dist_Email"].ToString();
                    User.MacId = ConnectionManager.GetMACAddress();
                    User.AllowedMacId = ds.Tables[0].Rows[0]["Dist_Mac_Id"].ToString();
                    User.Name = ds.Tables[0].Rows[0]["Dist_Name"].ToString();
                    User.MobileNo = ds.Tables[0].Rows[0]["Dist_Mobile_No"].ToString();
                    User.DistId = ds.Tables[0].Rows[0]["Dist_Id"].ToString();
                    User.Address = ds.Tables[0].Rows[0]["Dist_Address"].ToString();
                    User.ProfilePicPath = ds.Tables[0].Rows[0]["Dist_Profile_Pic_Path"].ToString();
                    User.RoleId = ds.Tables[0].Rows[0]["Dist_Role_Id"].ToString();
                    User.LiscenceNo = ds.Tables[0].Rows[0]["Dist_Fps_Liscence_No"].ToString();
                    User.MrShopNo = ds.Tables[0].Rows[0]["Dist_Mr_Shop_No"].ToString();
                    User.FpsCode = ds.Tables[0].Rows[0]["Dist_Fps_Code"].ToString();

                    Logger.LogInfo("LoginId: " + User.LoginId + " EmailId: " + User.EmailId + " MacId: " + User.MacId + " AllowedMacId: " + User.AllowedMacId + " Name: " + User.Name
                        + " MobileNo: " + User.MobileNo + " DistId: " + User.DistId + " Address: " + User.Address + " ProfilePicPath: " + User.ProfilePicPath + " RoleId: " + User.RoleId
                        + " LiscenceNo: " + User.LiscenceNo + " MrShopNo: " + User.MrShopNo + " FpsCode: " + User.FpsCode);

                    lblName.Text = User.Name;
                    lblMobileNo.Text = User.MobileNo;
                    lblEmail.Text = User.EmailId;
                    lblLoginId.Text = User.LoginId;

                    FetchMasterData();

                    //Thread mstDataThread = new Thread(new ThreadStart(FetchMasterData));
                    //mstDataThread.Start();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void FetchMasterData()
        {
            MasterData.CategoryWiseSearchResult = new List<CategoryWiseSearchResult>();
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@UserId", SqlDbType = SqlDbType.VarChar, Value = User.LoginId });
                DataSet ds = ConnectionManager.Exec("Sp_GetMasterData", sqlParams);

                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    //fetch Masterdata
                    //HofMasterData
                    MasterData.Hofs = ds.Tables[0].AsEnumerable().Select(i => new Hof
                    {
                        Hof_Id = i["Customer_Id"].ToString(),
                        Customer_Id = i["Customer_Id"].ToString(),
                        Name = i["Name"].ToString(),
                        CardNo = i["Number"].ToString(),
                        Mobile_No = i["Mobile_No"].ToString(),
                        Address = i["Address"].ToString(),
                        TotalCardCount = Int32.Parse(i["Total_Count"].ToString()),
                        TotalActiveCardCount = Int32.Parse(i["Active_Count"].ToString()),
                        ShowVal = i["Name"].ToString() + " || " + i["Number"].ToString() + " || " + i["Mobile_No"].ToString(),
                        Hof_Flag = "1",
                    }).ToList();

                    //Total Hof Count
                    MasterData.TotalHofCount = Int32.Parse(ds.Tables[1].Rows[0][0].ToString());

                    //Active Hof Count
                    MasterData.ActiveHofCount = Int32.Parse(ds.Tables[2].Rows[0][0].ToString());

                    //Master Category
                    MasterData.Categories = ds.Tables[3].AsEnumerable().Select(i => new Category
                    {
                        Cat_Id = i["Cat_Id"].ToString(),
                        Cat_Desc = i["Cat_Desc"].ToString()
                    }).ToList();

                    //Master Relation
                    MasterData.Relations = ds.Tables[4].AsEnumerable().Select(i => new RelationMaster
                    {
                        Mst_Rel_With_Hof_Id = i["Mst_Rel_With_Hof_Id"].ToString(),
                        Relation = i["Relation"].ToString()
                    }).ToList();

                    //product Master
                    MasterData.PrdData = ds.Tables[5].AsEnumerable().Select(i => new Product
                    {
                        Product_Master_Identity = i["Product_Master_Identity"].ToString(),
                        Name = i["Name"].ToString(),
                        ProdDescription = i["ProdDescription"].ToString(),
                        UOMType = i["UOMType"].ToString(),
                        Active = i["Active"].ToString()
                    }).ToList();

                    //UomMasterData
                    MasterData.Uoms = ds.Tables[6].AsEnumerable().Select(i => new Uom
                    {
                        UOM_Id_Identity = i["UOM_Id_Identity"].ToString(),
                        UOMName = i["UOMName"].ToString(),
                        UOMType = i["UOMType"].ToString(),
                        Active = i["Active"].ToString()
                    }).ToList();

                    //DataFetchTime
                    MasterData.DataFetchTime = DateTime.Now;

                    //CategoryWiseSearchResult
                    if ((MasterData.Categories != null))
                    {
                        foreach(Category cat in MasterData.Categories)
                        {                            
                            Thread thread = new Thread(() => FetchCatData(cat.Cat_Id, (cat.Cat_Id == MasterData.Categories.Last().Cat_Id)));
                            thread.Start();
                        }
                    }                    
                }
                Logger.LogInfo(Environment.NewLine + "masterdata fetch completed on " + DateTime.Now);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void FetchCatData(string cat, bool isLastCatId)
        {
            MasterData.CategoryWiseSearchResult.Add(MasterDataHelper.SearchCard("", "", cat));
            if (isLastCatId)
            {
                MasterData.MasterDataFetchComplete = true;
            }
            Logger.LogInfo(Environment.NewLine + "Search result for catid " + cat + " fetch complete on " + DateTime.Now);
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
            try
            {
                txtMsg.Text = "";
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@userId", SqlDbType = SqlDbType.VarChar, Value = userId });
                sqlParams.Add(new SqlParameter { ParameterName = "@pass", SqlDbType = SqlDbType.VarChar, Value = password });
                sqlParams.Add(new SqlParameter { ParameterName = "@mac", SqlDbType = SqlDbType.VarChar, Value = User.MacId });

                DataSet ds = ConnectionManager.Exec("Sp_Login", sqlParams);
            
                if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "SUCCESS")
                    {                        
                        FormHelper.OpenFrmRationcardHome();
                        this.Visible = false;
                    }
                    else if (ds.Tables[0].Rows[0][0].ToString() == "FAILURE")
                    {
                        Logger.LogError(ds.Tables[0].Rows[0][1].ToString());
                        txtMsg.Text = ds.Tables[0].Rows[0][1].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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
