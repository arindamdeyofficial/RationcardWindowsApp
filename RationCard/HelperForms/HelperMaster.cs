using RationCard.Helper;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RationCard
{
    public partial class HelperMaster : Form
    {
        public HelperMaster()
        {
            InitializeComponent();
        }
        private void HelperMaster_Load(object sender, EventArgs e)
        {

        }

        private void btnMac_Click(object sender, EventArgs e)
        {
            FormHelper.OpenMacId();
        }

        private void btnConnectionString_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmConnectionString();
        }

        private void btnOrphanRecord_Click(object sender, EventArgs e)
        {
            FormHelper.OpenOrphanRecord();
        }

        private void btnFramework_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmFrameworkVersion();
        }

        private void FrmSetup_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmSetup();
        }

        private void btnSecurityCode_Click(object sender, EventArgs e)
        {
            FormHelper.OpenSecurityCodeMail();
        }

        private void btnProductTable_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmProductTables();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmAppConfig();
        }

        private void btnCleanAuditTables_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmCleanAuditTables();
        }
    }
}
