using RationCard.MasterDataManager;
using RationCard.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RationCard
{
    public partial class FrmPrdQuantityInBill : Form
    {
        private List<Uom>_allUom = new List<Uom>();
        private Product _prd;
        public FrmPrdQuantityInBill(Product prd)
        {
            InitializeComponent();
            UpdateUomList(prd);
        }
        public void UpdateUomList(Product prd)
        {
            _prd = prd;
            _allUom = prd.AllUom;
            cmbUom.DataSource = _allUom;
            cmbUom.DisplayMember = "UOMName";
            cmbUom.ValueMember = "UOM_Id_Identity";
            cmbUom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbUom.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnAddProduct_Click(object sender, System.EventArgs e)
        {
            if(string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                lblMsg.Text = "Please enter quantity";
            }
            else
            {
                UpdateQuantity();
            }
        }

        private void txtQuantity_TextChanged(object sender, System.EventArgs e)
        {
            if (lblMsg.Text == "Please enter quantity")
                lblMsg.Text = "";
            int convertedNumber = 0;
            txtQuantity.Text = (int.TryParse(txtQuantity.Text, out convertedNumber) ? convertedNumber : 0).ToString();
        }

        private void FrmPrdQuantityInBill_Load(object sender, System.EventArgs e)
        {
            txtQuantity.Text = "1";
        }

        private void FrmPrdQuantityInBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                UpdateQuantity();
            }
        }       

        private void cmbUom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                UpdateQuantity();
            }
        }
        public void UpdateQuantity()
        {
            Form frmPrdQuantityInBill = Application.OpenForms["FrmPrdQuantityInBill"];
            FrmRationBillDetails frmRationBillDetails = (FrmRationBillDetails)Application.OpenForms["FrmRationBillDetails"];
            _prd.ConsumptionQuantity = int.Parse(txtQuantity.Text);
            _prd.UnitOfMeasure = ((Uom)cmbUom.SelectedItem).UOMName;
            _prd.UnitOfMeasureDetail = _allUom.FirstOrDefault(i => i.UOMName == ((Uom)cmbUom.SelectedItem).UOMName);
            frmRationBillDetails.AddProduct(_prd);
            frmPrdQuantityInBill.Hide();
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnAddProduct_Click(sender, (System.EventArgs) e);
            }
        }
    }
}
