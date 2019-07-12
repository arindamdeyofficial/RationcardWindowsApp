using RationCard.Helper;
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
    public partial class FrmConnectionString : Form
    {
        public FrmConnectionString()
        {
            InitializeComponent();
        }

        private void FrmConnectionString_Load(object sender, EventArgs e)
        {

        }
        private void txtSimpleConStr_TextChanged(object sender, EventArgs e)
        {
            txtEncryptedConStr.Text = SecurityEncrypt.Encrypt(txtSimpleConStr.Text, "nakshal");
        }

        private void txtEncryptedConStr_TextChanged(object sender, EventArgs e)
        {
            txtSimpleConStr.Text = SecurityEncrypt.Decrypt(txtEncryptedConStr.Text, "nakshal");
        }
    }
}
