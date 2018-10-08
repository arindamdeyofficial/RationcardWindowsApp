using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using log4net;
using log4net.Config;
using RationCard.Model;

namespace RationCard.Helper
{
    public static class UserHelper
    {
        public static void RegisterNewUser(string name, string mobileNo, string address, string email, string profilePicPath
            , string login, string password, bool macChekRequired, string fpsCode, string fpsLiscenceNo, string mrShopNo
            , string mac, string remark, string code
            , out string successMsg)
        {
            List<MacIdAssigned> mcs = new List<MacIdAssigned>();
            successMsg = "";
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Name", SqlDbType = SqlDbType.VarChar, Value = name });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Mobile_No", SqlDbType = SqlDbType.VarChar, Value = mobileNo });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Address", SqlDbType = SqlDbType.VarChar, Value = address });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Email", SqlDbType = SqlDbType.VarChar, Value = email });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Profile_Pic_Path", SqlDbType = SqlDbType.VarChar, Value = profilePicPath });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Password", SqlDbType = SqlDbType.VarChar, Value = password });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Mac_Check", SqlDbType = SqlDbType.Bit, Value = macChekRequired ? 1 : 0 });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Fps_Code", SqlDbType = SqlDbType.VarChar, Value = fpsCode });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Fps_Liscence_No", SqlDbType = SqlDbType.VarChar, Value = fpsLiscenceNo });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Mr_Shop_No", SqlDbType = SqlDbType.VarChar, Value = mrShopNo });
                sqlParams.Add(new SqlParameter { ParameterName = "@mac", SqlDbType = SqlDbType.VarChar, Value = mac });
                sqlParams.Add(new SqlParameter { ParameterName = "@remark", SqlDbType = SqlDbType.VarChar, Value = remark });
                sqlParams.Add(new SqlParameter { ParameterName = "@code", SqlDbType = SqlDbType.VarChar, Value = code });
                sqlParams.Add(new SqlParameter { ParameterName = "@operation", SqlDbType = SqlDbType.VarChar, Value = "ADD" });

                DataSet ds = ConnectionManager.Exec("Sp_Distributor_Operate", sqlParams);

                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    if (ds.Tables[0].Rows[0][0].ToString().Equals("SUCCESS"))
                    {
                        successMsg = ds.Tables[0].Rows[0][1].ToString();
                    }
                    else if (ds.Tables[0].Rows[0][0].ToString().Equals("FAILURE"))
                    {
                        successMsg = ds.Tables[0].Rows[0][1].ToString();
                    }
                }
                else
                    successMsg = "Not able to register new user. Please contact admin.";
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public static void RemoveUser(string userId, out bool isSuccess)
        {
            List<MacIdAssigned> mcs = new List<MacIdAssigned>();
            isSuccess = true;
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Login", SqlDbType = SqlDbType.VarChar, Value = userId });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Name", SqlDbType = SqlDbType.VarChar, Value = string.Empty });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Mobile_No", SqlDbType = SqlDbType.VarChar, Value = string.Empty });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Address", SqlDbType = SqlDbType.VarChar, Value = string.Empty });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Email", SqlDbType = SqlDbType.VarChar, Value = string.Empty });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Profile_Pic_Path", SqlDbType = SqlDbType.VarChar, Value = string.Empty });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Password", SqlDbType = SqlDbType.VarChar, Value = string.Empty });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Mac_Check", SqlDbType = SqlDbType.VarChar, Value = string.Empty });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Fps_Code", SqlDbType = SqlDbType.VarChar, Value = string.Empty });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Fps_Liscence_No", SqlDbType = SqlDbType.VarChar, Value = string.Empty });
                sqlParams.Add(new SqlParameter { ParameterName = "@Dist_Mr_Shop_No", SqlDbType = SqlDbType.VarChar, Value = string.Empty });
                sqlParams.Add(new SqlParameter { ParameterName = "@mac", SqlDbType = SqlDbType.VarChar, Value = string.Empty });
                sqlParams.Add(new SqlParameter { ParameterName = "@remark", SqlDbType = SqlDbType.VarChar, Value = string.Empty });
                sqlParams.Add(new SqlParameter { ParameterName = "@code", SqlDbType = SqlDbType.VarChar, Value = string.Empty });
                sqlParams.Add(new SqlParameter { ParameterName = "@operation", SqlDbType = SqlDbType.VarChar, Value = "REMOVE" });

                DataSet ds = ConnectionManager.Exec("Sp_Distributor_Operate", sqlParams);

                if ((ds != null) && (ds.Tables.Count > 0))
                {

                    isSuccess = true;
                }
                else
                    isSuccess = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public static bool DoLogin(string userId, string password, string macId, out string msg)
        {
            bool isSuccess = false;
            msg = string.Empty;
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@userId", SqlDbType = SqlDbType.VarChar, Value = userId });
                sqlParams.Add(new SqlParameter { ParameterName = "@pass", SqlDbType = SqlDbType.VarChar, Value = password });
                sqlParams.Add(new SqlParameter { ParameterName = "@mac", SqlDbType = SqlDbType.VarChar, Value = macId });

                DataSet ds = ConnectionManager.Exec("Sp_Login", sqlParams);

                if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "SUCCESS")
                    {                        
                        Logger.LogInfo("Login successful.");
                        isSuccess = true;
                    }
                    else if (ds.Tables[0].Rows[0][0].ToString() == "FAILURE")
                    {
                        msg = ds.Tables[0].Rows[0][1].ToString();
                        Logger.LogError(msg);
                        isSuccess = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return isSuccess;
        }
    }
}
