using RationCard.Helper;
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
    public partial class FrmCleanAuditTables : Form
    {
        public FrmCleanAuditTables()
        {
            InitializeComponent();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            DeleteRecord("ALL");
        }

        private void DeleteRecord(string tableName)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter { ParameterName = "@tableName", SqlDbType = SqlDbType.VarChar, Value = tableName });
            sqlParams.Add(new SqlParameter
            {
                ParameterName = "@dtFrom",
                SqlDbType = SqlDbType.VarChar,
                Value = dtFrom.Value.ToString("MM-dd-yyyy HH:mm:ss")
            });
            sqlParams.Add(new SqlParameter
            {
                ParameterName = "@dtTo",
                SqlDbType = SqlDbType.VarChar,
                Value = dtTo.Value.ToString("MM-dd-yyyy HH:mm:ss")
            });
            DataSet ds = ConnectionManager.Exec("Sp_Clean_Audit_Tables", sqlParams);

            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
            {
                if(ds.Tables[0].Rows[0][0].ToString().Equals("SUCCESS"))
                {
                    MessageBox.Show("Records cleaned successfully");
                }
                else
                {
                    MessageBox.Show("Records cleaning failed");
                }
            }
        }

        private void FrmCleanAuditTables_Load(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Parse("01-01-1900");
            dtTo.Value = DateTime.Now;
        }

        private void btnCard_Search_Input_Click(object sender, EventArgs e)
        {
            DeleteRecord("Card_Search_Input");
        }

        private void btnLogger_Click(object sender, EventArgs e)
        {
            DeleteRecord("Logger");
        }

        private void btnProduct_Search_Input_Click(object sender, EventArgs e)
        {
            DeleteRecord("Product_Search_Input");
        }

        private void btnProduct_Input_Click(object sender, EventArgs e)
        {
            DeleteRecord("Product_Input");
        }

        private void btnBill_Input_Click(object sender, EventArgs e)
        {
            DeleteRecord("Bill_Input");
        }

        private void btnTxn_Card_Input_Data_Click(object sender, EventArgs e)
        {
            DeleteRecord("Txn_Card_Input_Data");
        }

        private void btnApp_Start_His_Click(object sender, EventArgs e)
        {
            DeleteRecord("App_Start_His");
        }

        private void btnLogin_His_Click(object sender, EventArgs e)
        {
            DeleteRecord("Login_His");
        }
    }
}
