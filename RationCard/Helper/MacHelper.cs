using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using log4net;
using log4net.Config;
using RationCard.Model;

namespace RationCard.Helper
{
    public static class MacHelper
    {
        public static List<MacIdAssigned> OperateMacId(string distId, string mac, string macIdType, string startFormName, string remark, string operation, out bool isSuccess)
        {
            List<MacIdAssigned> mcs = new List<MacIdAssigned>();
            isSuccess = false;
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@distId", SqlDbType = SqlDbType.VarChar, Value = distId });
                sqlParams.Add(new SqlParameter { ParameterName = "@mac", SqlDbType = SqlDbType.VarChar, Value = mac });
                sqlParams.Add(new SqlParameter { ParameterName = "@remark", SqlDbType = SqlDbType.VarChar, Value = remark });
                sqlParams.Add(new SqlParameter { ParameterName = "@action", SqlDbType = SqlDbType.VarChar, Value = operation });
                DataSet ds = ConnectionManager.Exec("Sp_Add_Remove_Mac_Id", sqlParams);

                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    mcs.AddRange(ds.Tables[0].AsEnumerable().Select(i => new MacIdAssigned
                    {
                        Mac_Id_Identity = i["Mac_Id_Identity"].ToString(),
                        Mac_Id = i["Mac_Id"].ToString(),
                        Remarks = i["Remarks"].ToString(),
                        Created_Date = i["Created_Date"].ToString()
                    }));
                    isSuccess = true;
                }
                else
                    isSuccess = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return mcs;
        }
    }
}
