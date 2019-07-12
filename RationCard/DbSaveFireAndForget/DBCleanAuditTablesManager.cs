using RationCard.Helper;
using RationCard.MasterDataManager;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RationCard.DbSaveFireAndForget
{
    public static partial class DBSaveManager
    {
        public static void DeleteAuditRecords(string tableName, string fromDate, string toDate, out bool isSuccess)
        {
            ErrorEnum errType = ErrorEnum.Other;
            string errMsg = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter { ParameterName = "@tableName", SqlDbType = SqlDbType.VarChar, Value = tableName });
            sqlParams.Add(new SqlParameter
            {
                ParameterName = "@dtFrom",
                SqlDbType = SqlDbType.VarChar,
                Value = fromDate
            });
            sqlParams.Add(new SqlParameter
            {
                ParameterName = "@dtTo",
                SqlDbType = SqlDbType.VarChar,
                Value = toDate
            });
            DataSet ds = ConnectionManager.Exec("Sp_Clean_Audit_Tables", sqlParams, out errType, out errMsg, out isSuccess);

            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
            {
                isSuccess = ds.Tables[0].Rows[0][0].ToString().Equals("SUCCESS");
            }
        }
    }
}
