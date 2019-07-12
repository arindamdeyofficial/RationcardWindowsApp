using RationCard.Helper;
using RationCard.Model;
using System;
using System.Windows.Forms;

namespace RationCard
{
    public partial class FrmLableSelectForPrint : Form
    {
        FrmSearchResult _frmObj = null;
        string _rptDate = "";
        string _rptSignature = "";
        string _rptHeader = "";
        string _rptCriteria = "";
        public FrmLableSelectForPrint(FrmSearchResult frmObj)
        {
            InitializeComponent();
            try
            {
                _frmObj = frmObj;
                var panel = _frmObj.Controls["pnlRptHeader"];
                panel.Controls["lblDealerName"].Text = User.Name;
                panel.Controls["lblLiscenceNo"].Text = User.LiscenceNo;
                panel.Controls["lblMRShopNo"].Text = User.MrShopNo;
                panel.Controls["lblDtToday"].Text = DateTime.Now.ToLongDateString();
                _rptHeader = panel.Controls["lblHdrDealerName"].Text + "\t\t"
                    + panel.Controls["lblColDealerName"].Text
                    + panel.Controls["lblDealerName"].Text + Environment.NewLine

                    + panel.Controls["lblHdrLiscenceNo"].Text + "\t"
                    + panel.Controls["lblColLiscenceNo"].Text
                    + panel.Controls["lblLiscenceNo"].Text + Environment.NewLine

                    + panel.Controls["lblHdrMrShopNo"].Text + "\t"
                    + panel.Controls["lblColMrShopNo"].Text
                    + panel.Controls["lblMRShopNo"].Text + Environment.NewLine + Environment.NewLine + Environment.NewLine;

                _rptDate = Environment.NewLine + panel.Controls["lblDt"].Text + panel.Controls["lblDtToday"].Text;
                _rptSignature = panel.Controls["lblLine"].Text + Environment.NewLine + "\t" + panel.Controls["lblSignature"].Text;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Control grpBox = _frmObj.Controls["grpBoxSearchCriteria"];
                _rptCriteria = grpBox.Controls["lblSearchResult"].Text + Environment.NewLine +
                    grpBox.Controls["lblCriteria"].Text;

                DataGridView grdVwSearchResult = (DataGridView)_frmObj.Controls["grdVwSearchResult"];
                DataGridView dataGrid = CloneDataGrid(grdVwSearchResult);
                dataGrid.Columns["ActiveCard"].Visible = false;

                dataGrid.Columns["Number"].Visible = chkRationCardNo.Checked;
                dataGrid.Columns["Adhar_No"].Visible = chkAdhar.Checked;
                dataGrid.Columns["Mobile_No"].Visible = chkMobileNo.Checked;
                dataGrid.Columns["Hof_Name"].Visible = chkHof.Checked;
                dataGrid.Columns["FamilyCount"].Visible = chkNoOfCard.Checked;
                dataGrid.Columns["Name"].Visible = chkCardHolderName.Checked;
                dataGrid.Columns["Age"].Visible = chkAge.Checked;
                dataGrid.Columns["Address"].Visible = chkAddress.Checked;
                dataGrid.Columns["Card_Created_Date"].Visible = chkActiveSince.Checked;
                dataGrid.Columns["Relation_With_Hof"].Visible = chkRelWithHof.Checked;
                dataGrid.Columns["Gaurdian_Name"].Visible = chkGaurdianName.Checked;
                dataGrid.Columns["Remarks"].Visible = chkRemarks.Checked;

                int chkCount = 0;
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(CheckBox))
                    {
                        CheckBox chk = (CheckBox)c;
                        if (chk.Checked)
                        {
                            chkCount++;
                        }
                    }
                }
                //string pageSize = (chkCount < 8) ? "A4" : "A3";
                string pageSize = "A3";
                string pageType = "";
                pageType = (chkPrintNonDrawal.Checked) ? "L" : ((chkCount < 8) ? "P" : "L");
                
                ClsPrint.PrintForm(dataGrid, _rptHeader, _rptCriteria, _rptDate, _rptSignature, pageType, pageSize, (chkPrintNonDrawal.Checked) ? "Nondrawal Report" : "Rationcard Summary", chkPrintNonDrawal.Checked);

                //grdVwSearchResult.Columns["Number"].Visible = true;
                //grdVwSearchResult.Columns["Adhar_No"].Visible = true;
                //grdVwSearchResult.Columns["Mobile_No"].Visible = true;
                //grdVwSearchResult.Columns["Hof_Name"].Visible = true;
                //grdVwSearchResult.Columns["FamilyCount"].Visible = true;
                //grdVwSearchResult.Columns["Name"].Visible = true;
                //grdVwSearchResult.Columns["Age"].Visible = true;
                //grdVwSearchResult.Columns["Address"].Visible = true;
                //grdVwSearchResult.Columns["Card_Created_Date"].Visible = true;
                //grdVwSearchResult.Columns["Relation_With_Hof"].Visible = true;
                //grdVwSearchResult.Columns["Gaurdian_Name"].Visible = true;
                //grdVwSearchResult.Columns["Remarks"].Visible = true;
                //grdVwSearchResult.Columns["ActiveCard"].Visible = true;

                this.Visible = false;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public DataGridView CloneDataGrid(DataGridView mainDataGridView)
        {
            DataGridView cloneDataGridView = new DataGridView();

            if (cloneDataGridView.Columns.Count == 0)
            {
                foreach (DataGridViewColumn datagrid in mainDataGridView.Columns)
                {
                    var dr = datagrid.Clone() as DataGridViewColumn;
                    dr.DisplayIndex = datagrid.DisplayIndex;
                    cloneDataGridView.Columns.Add(dr);
                }
            }

            DataGridViewRow dataRow = new DataGridViewRow();

            for (int i = 0; i < mainDataGridView.Rows.Count; i++)
            {
                dataRow = (DataGridViewRow)mainDataGridView.Rows[i].Clone();
                int Index = 0;
                foreach (DataGridViewCell cell in mainDataGridView.Rows[i].Cells)
                {
                    dataRow.Cells[Index].Value = cell.Value;
                    Index++;
                }
                cloneDataGridView.Rows.Add(dataRow);
            }
            cloneDataGridView.AllowUserToAddRows = false;
            cloneDataGridView.Refresh();


            return cloneDataGridView;
        }

        private void chkPrintNonDrawal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrintNonDrawal.Checked)
            {
                chkRationCardNo.Checked = true;
                chkAdhar.Checked = true;
                chkMobileNo.Checked = true;
                chkHof.Checked = false;
                chkNoOfCard.Checked = false;
                chkCardHolderName.Checked = false;
                chkAge.Checked = false;
                chkAddress.Checked = false;
                chkActiveSince.Checked = false;
                chkRelWithHof.Checked = false;
                chkGaurdianName.Checked = false;
                chkRemarks.Checked = false;
            }
            else
            {
                chkRationCardNo.Checked = true;
                chkAdhar.Checked = true;
                chkMobileNo.Checked = true;
                chkHof.Checked = true;
                chkNoOfCard.Checked = true;
                chkCardHolderName.Checked = true;
                chkAge.Checked = true;
                chkAddress.Checked = true;
                chkActiveSince.Checked = true;
                chkRelWithHof.Checked = true;
                chkGaurdianName.Checked = true;
                chkRemarks.Checked = true;
            }
        }
    }
}
