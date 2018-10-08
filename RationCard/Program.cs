using RationCard.Helper;
using RationCard.HelperForms;
using RationCard.MasterDataManager;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RationCard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationStart();
        }

        private static void ApplicationStart()
        {
            if (!Network.IsInternetConnected)
            {
                DialogConfirm.ShowInformationDialog("Internet is not there. Please connect to internet, then open again.", "Stone Age !!");
                Application.ExitThread();
                Application.Exit();
            }
            else
            {
                try
                {
                    string macAddr = Network.GetActiveMACAddress();
                    string ipAddrInternal = Network.GetActiveIP();
                    string ipAddrPublic = Network.GetPublicIpAddress();
                    string gateWay = Network.GetActiveGateway();

                    Logger.LogInfo("Mac id: " + macAddr + " ipAddr: " + ipAddrInternal + " Gateway: " + gateWay + "Public Ip: " + ipAddrPublic);
                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter { ParameterName = "@mac", SqlDbType = SqlDbType.VarChar, Value = macAddr });
                    sqlParams.Add(new SqlParameter { ParameterName = "@Internal_Ip", SqlDbType = SqlDbType.VarChar, Value = ipAddrInternal });
                    sqlParams.Add(new SqlParameter { ParameterName = "@Public_Ip", SqlDbType = SqlDbType.VarChar, Value = ipAddrPublic });
                    sqlParams.Add(new SqlParameter { ParameterName = "@Gateway_Addr", SqlDbType = SqlDbType.VarChar, Value = gateWay });

                    DataSet ds = ConnectionManager.Exec("SP_App_Start", sqlParams);

                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["Status"].ToString() == "SUCCESS"))
                    {
                        DataSet tmpDs = new DataSet();
                        tmpDs.Tables.Add(ds.Tables[1].Copy());
                        MasterDataHelper.AssignRoleData(tmpDs);
                        tmpDs.Reset();
                        
                        User.LoginId = ds.Tables[0].Rows[0]["Dist_Login"].ToString();
                        User.EmailId = ds.Tables[0].Rows[0]["Dist_Email"].ToString();
                        User.MacId = Network.GetActiveMACAddress();
                        User.AllowedMacId = ds.Tables[0].Rows[0]["Dist_Mac_Id"].ToString();
                        User.Name = ds.Tables[0].Rows[0]["Dist_Name"].ToString();
                        User.MobileNo = ds.Tables[0].Rows[0]["Dist_Mobile_No"].ToString();
                        User.DistId = ds.Tables[0].Rows[0]["Dist_Id"].ToString();
                        User.Address = ds.Tables[0].Rows[0]["Dist_Address"].ToString();
                        User.ProfilePicPath = ds.Tables[0].Rows[0]["Dist_Profile_Pic_Path"].ToString();
                        User.Roles = MasterData.Roles.Data;
                        User.LiscenceNo = ds.Tables[0].Rows[0]["Dist_Fps_Liscence_No"].ToString();
                        User.MrShopNo = ds.Tables[0].Rows[0]["Dist_Mr_Shop_No"].ToString();
                        User.FpsCode = ds.Tables[0].Rows[0]["Dist_Fps_Code"].ToString();
                        User.IsSuperadmin = ds.Tables[0].Rows[0]["IsSuperAdmin"].ToString() == "True";
                        User.Password = ds.Tables[0].Rows[0]["Dist_Password"].ToString();
                        User.MobileNoToNotifyViaSms = ((ds.Tables[0].Rows[0]["MobileNoToNotifyViaSms"].ToString() != "0") ? ds.Tables[0].Rows[0]["MobileNoToNotifyViaSms"].ToString() : "");
                        User.EmailToNotify = ds.Tables[0].Rows[0]["EmailToNotify"].ToString();

                        Logger.LogInfo("LoginId: " + User.LoginId + " EmailId: " + User.EmailId + " MacId: " + User.MacId + " AllowedMacId: " + User.AllowedMacId + " Name: " + User.Name
                            + " MobileNo: " + User.MobileNo + " DistId: " + User.DistId + " Address: " + User.Address + " ProfilePicPath: " + User.ProfilePicPath + " Role Count: " + User.Roles.Count
                            + " LiscenceNo: " + User.LiscenceNo + " MrShopNo: " + User.MrShopNo + " FpsCode: " + User.FpsCode);
                        
                        if (User.IsSuperadmin)
                        {
                            Application.Run(new FrmUserSelector());
                        }
                        else
                        {
                            Application.Run(new FrmLogin());
                        }
                    }
                    else
                    {
                        Application.Run(new FrmSetup());
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }

                //Thread mstDataThread = new Thread(new ThreadStart(FetchMasterData));
                //mstDataThread.Start();
            }
        }
    }    
}
