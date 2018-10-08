using Helper;
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
                grdVwSearchResult.Columns["ActiveCard"].Visible = false;

                grdVwSearchResult.Columns["Number"].Visible = chkRationCardNo.Checked;
                grdVwSearchResult.Columns["Adhar_No"].Visible = chkAdhar.Checked;
                grdVwSearchResult.Columns["Mobile_No"].Visible = chkMobileNo.Checked;
                grdVwSearchResult.Columns["Hof_Name"].Visible = chkHof.Checked;
                grdVwSearchResult.Columns["FamilyCount"].Visible = chkNoOfCard.Checked;
                grdVwSearchResult.Columns["Name"].Visible = chkCardHolderName.Checked;
                grdVwSearchResult.Columns["Age"].Visible = chkAge.Checked;
                grdVwSearchResult.Columns["Address"].Visible = chkAddress.Checked;
                grdVwSearchResult.Columns["Card_Created_Date"].Visible = chkActiveSince.Checked;
                grdVwSearchResult.Columns["Relation_With_Hof"].Visible = chkRelWithHof.Checked;
                grdVwSearchResult.Columns["Gaurdian_Name"].Visible = chkGaurdianName.Checked;
                grdVwSearchResult.Columns["Remarks"].Visible = chkRemarks.Checked;

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
                string pageType = (chkCount < 8) ? "P" : "L";
                ClsPrint.PrintForm(grdVwSearchResult, _rptHeader, _rptCriteria, _rptDate, _rptSignature, pageType, pageSize, "Rationcard Summary");

                grdVwSearchResult.Columns["Number"].Visible = true;
                grdVwSearchResult.Columns["Adhar_No"].Visible = true;
                grdVwSearchResult.Columns["Mobile_No"].Visible = true;
                grdVwSearchResult.Columns["Hof_Name"].Visible = true;
                grdVwSearchResult.Columns["FamilyCount"].Visible = true;
                grdVwSearchResult.Columns["Name"].Visible = true;
                grdVwSearchResult.Columns["Age"].Visible = true;
                grdVwSearchResult.Columns["Address"].Visible = true;
                grdVwSearchResult.Columns["Card_Created_Date"].Visible = true;
                grdVwSearchResult.Columns["Relation_With_Hof"].Visible = true;
                grdVwSearchResult.Columns["Gaurdian_Name"].Visible = true;
                grdVwSearchResult.Columns["Remarks"].Visible = true;
                grdVwSearchResult.Columns["ActiveCard"].Visible = true;

                this.Visible = false;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
