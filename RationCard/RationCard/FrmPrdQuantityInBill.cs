using RationCard.Model;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RationCard
{
    public partial class FrmPrdQuantityInBill : Form
    {
        public FrmPrdQuantityInBill(string uomType)
        {
            InitializeComponent();
            UpdateUomList(uomType);
        }
        public void UpdateUomList(string uomType)
        {
            cmbUom.DataSource = MasterData.Uoms.Select(i => i).Where(i => i.UOMType.Equals(uomType)).ToList();
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
            frmRationBillDetails.AddProduct(new Product { Quantity = int.Parse(txtQuantity.Text), UnitOfMeasure = ((Uom)cmbUom.SelectedItem).UOMName});
            frmPrdQuantityInBill.Hide();
        }
    }
}
