using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace RationCard.Helper
{
    public static class ExcelOperations
    {
        public static DataTable ReadSheet(string fileName, string sheetName)
        {
            DataTable dt = new DataTable();
            try
            {
                string excelConnectionString = ConfigManager.GetConfigValue("OleDbConnection").Replace("{FileName}", fileName);
                OleDbConnection con = new OleDbConnection(excelConnectionString);
                OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + sheetName + "$]", con);

                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return dt;
        }
        public static DataSet ReadExcel(string fileName)
        {
            DataSet ds = new DataSet();
            try
            {
                string excelConnectionString = ConfigManager.GetConfigValue("OleDbConnection").Replace("{FileName}", fileName);
                OleDbConnection con = new OleDbConnection(excelConnectionString);
                DataTable sheets = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow r in sheets.Rows)
                {
                    string query = "SELECT * FROM [" + r[0].ToString() + "]";
                    ds.Clear();
                    OleDbDataAdapter data = new OleDbDataAdapter(query, excelConnectionString);
                    data.Fill(ds);

                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
            return ds;
        }
    }
}
