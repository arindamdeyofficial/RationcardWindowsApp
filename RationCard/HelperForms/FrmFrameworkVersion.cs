using RationCard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RationCard.HelperForms
{
    public partial class FrmFrameworkVersion : Form
    {
        public FrmFrameworkVersion()
        {
            InitializeComponent();
        }

        private void FrmFrameworkVersion_Load(object sender, EventArgs e)
        {
            lblIsLatest.Text = DotNetrameworks.IsCompatible ? "System is up to date" : "System doesn't have latest .Net Framework";
            lblLatestVersion.Text = "Latest Version Installed: " + DotNetrameworks.LatestFrameworkVersionName;
            drVwDotNetVersions.DataSource = DotNetrameworks.AllFrameworkVersions;
            webBrowser1.Url = new Uri("https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determine-which-versions-are-installed");
        }

        private void btnCopylink_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(lblLink.Text);
        }
    }
}
