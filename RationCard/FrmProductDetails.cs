using RationCard.Helper;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using RationCard.MasterDataManager;

namespace RationCard
{
    public partial class FrmProductDetails : Form
    {
        public Product _prd;
        private List<ProductStock> _lstStock = new List<ProductStock>();
        public FrmProductDetails()
        {
            InitializeComponent();
            _prd = new Product();
            _prd.PrdQuantityAllocated = new List<ProductQuantityMaster>();
            _prd.AllUom = new List<Uom>();
            _prd.StockInBaseUom = new List<ProductStock>();
            BindDropdowns();
            //action
            lblAction.Text = "ADD";

            SetInitialValueToFields();

            txtBarCode.Focus();
        }
        public FrmProductDetails(string prdId)
        {
            InitializeComponent();
            ResetForm();
            FromLoadActionOnEdit(MasterData.PrdData.Data.FirstOrDefault(i => i.Product_Master_Identity == prdId));
        }

        public FrmProductDetails(Product prd)
        {
            InitializeComponent();
            FromLoadActionOnEdit(prd);
        }
        private void FromLoadActionOnEdit(Product prd)
        {
            ResetForm();
            _prd = prd;
            BindDropdowns();
            OpenExistingProduct(_prd);
            if (((_prd != null) && (_prd.StockInBaseUom == null)) || (_prd == null))
            {
                btnStockDetails.Visible = false;
            }
            else
            {
                btnStockDetails.Visible = true;
            }            
            //action
            lblAction.Text = "EDIT";
            SetQuantityIndex();
            txtBarCode.Focus();
        }
        private void SetInitialValueToFields()
        {
            //Set zero all int fields
            txtQuantityInBaseUom.Text = "0";
            txtAllowedDamageQuantityPerUnit.Text = "0";
            txtTotalAllowedDamageQuantity.Text = "0";
            txtTotalDamageQuantityInReal.Text = "0";
            txtTotalStock.Text = "0";
            txtTotalAllowedDamageQuantityPerUnit.Text = "0";
            txtAllTotalAllowedDamageQuantity.Text = "0";
            txtAllTotalDamageQuantityInReal.Text = "0";            
        }
        public void OpenExistingProduct(Product prd)
        {            
            float convertedNum = 0;
            //General
            lblTxtId.Text = prd.Product_Master_Identity;
            txtBarCode.Text = prd.BarCode;
            txtArticleCode.Text = prd.ArticleCode;
            txtProdName.Text = prd.Name;
            txtProdDesc.Text = prd.ProdDescription;

            //Checkbox
            chkActive.Checked = prd.Active;
            chkDefaultToGiveRation.Checked = prd.IsDefaultGiveRation;
            chkDefaultProduct.Checked = prd.IsDefaultProduct;

            //Quantity
            //txtQuantity.Text = prd.Quantity.ToString();
            if(!string.IsNullOrEmpty(prd.UnitOfMeasure))
            {
                cmbQuantityUom.SelectedValue = MasterData.Uoms.Data.FirstOrDefault(i => i.UOMName == prd.UnitOfMeasure).UOM_Id_Identity;
            }

            //Rate
            if (!string.IsNullOrEmpty(prd.BaseUom.UOMType))
            {
                cmbUomType.SelectedValue = MasterData.UomType.Data.FirstOrDefault(i => i.UOMType == prd.BaseUom.UOMType).UOMTypeId;
            }
            if (!string.IsNullOrEmpty(prd.BaseUom.UOMName))
            {
                cmbBaseUom.SelectedValue = MasterData.Uoms.Data.FirstOrDefault(i => i.UOMName == prd.BaseUom.UOMName).UOM_Id_Identity;
            }
            txtBuyingRate.Text = prd.BuyingRateInBaseUom.ToString();
            txtMrpRate.Text = prd.MrpRateInBaseUom.ToString();
            txtSellingRate.Text = prd.SellingRateInBaseUom.ToString();

            //Hierarchy
            
            cmbDept.SelectedValue = prd.ProductDept.ProductDeptMasterId.ToString();
            cmbSubDept.SelectedValue = prd.ProductSubDept.ProductSubDeptMasterId.ToString();
            cmbClass.SelectedValue = prd.ProductClass.ProductClassMasterId.ToString();
            cmbSubClass.SelectedValue = prd.ProductSubClass.ProductSubClassMasterId.ToString();
            cmbMcDesc.SelectedValue = prd.ProductMc.ProductMcMasterId.ToString();
            cmbBrand.SelectedValue = prd.ProductBrand.ProductBrandMasterId.ToString();
            txtMcCode.Text = prd.ProductMc.ProductMcMasterCode;
            txtBrand.Text = prd.ProductBrand.ProductBrandMasterCompanyDesc;

            //Default Quantity
            lstQuantitySummary.DataSource = null;
            lstQuantitySummary.DataSource = prd.PrdQuantityAllocated;
            lstQuantitySummary.ValueMember = "DefaultQuantityInBaseUom";
            lstQuantitySummary.DisplayMember = "PrdQuantityListDisplay";

            //Uom
            lstUomSummary.DataSource = prd.AllUom;
            lstUomSummary.ValueMember = "UOMName";
            lstUomSummary.DisplayMember = "UomDisplay";

            List<ProductStock> inStock = prd.StockInBaseUom.FindAll(i => i.IsStockIn);
            List<ProductStock> outStock = prd.StockInBaseUom.FindAll(i => !i.IsStockIn);
            //Stock Summary
            txtTotalStock.Text = 
                (inStock.Sum(i=>i.ProdQuantity)
                - outStock.Sum(i => i.ProdQuantity)).ToString();
            txtTotalAllowedDamageQuantityPerUnit.Text =
                (inStock.Sum(i => i.AllowedDamageQuantityPerUnit)
                - outStock.Sum(i => i.AllowedDamageQuantityPerUnit)).ToString();
            txtAllTotalAllowedDamageQuantity.Text =
                 (inStock.Sum(i => i.TotalAllowedDamageQuantity)
                - outStock.Sum(i => i.TotalAllowedDamageQuantity)).ToString();
            txtAllTotalDamageQuantityInReal.Text =
                (inStock.Sum(i => i.TotalDamageQuantityInReal)
                - outStock.Sum(i => i.TotalDamageQuantityInReal)).ToString();
            
            _prd = prd;
            if (((_prd != null) && (_prd.StockInBaseUom == null)) || (_prd == null))
            {
                btnStockDetails.Visible = false;
            }
            else
            {
                btnStockDetails.Visible = true;
            }
            cmbCatStock.Enabled = prd.IsDefaultProduct;

            //action
            lblAction.Text = "EDIT";
            SetQuantityIndex();
            txtBarCode.Focus();
        }

        private void FrmAddProductToInventory_Load(object sender, EventArgs e)
        {
            Network.CheckForInternet(InternetStatusChange);
        }
        private void InternetStatusChange(bool isconnected)
        {
            try
            {
                if ((!picNetwork.IsDisposed) && (picNetwork.InvokeRequired))
                {
                    Invoke(new Action(() =>
                    {
                        picNetwork.Visible = isconnected;
                    }));
                }
                else
                {
                    picNetwork.Visible = isconnected;
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex);
            }
        }

        public void EditStock()
        {

        }

        private void SetQuantityIndex()
        {
            int count = 0;
            foreach(ProductQuantityMaster qtn in _prd.PrdQuantityAllocated)
            {
                qtn.ProductQuantityIdentityUi = count;
                count++;
            }
        }

        private bool IsValidProductInput(out string errMsg)
        {
            errMsg = "";
            bool isValid = true;

            if(string.IsNullOrEmpty(txtBarCode.Text.Trim()))
            {
                isValid = false;
                errMsg += "BarCode not valid" + Environment.NewLine + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtProdName.Text.Trim()))
            {
                isValid = false;
                errMsg += "Product Name not valid" + Environment.NewLine + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtArticleCode.Text.Trim()))
            {
                isValid = false;
                errMsg += "ArticleCode not valid" + Environment.NewLine + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtSellingRate.Text.Trim()))
            {
                isValid = false;
                errMsg += "SellingRate not valid" + Environment.NewLine + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtBuyingRate.Text.Trim()))
            {
                isValid = false;
                errMsg += "BuyingRate not valid" + Environment.NewLine + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtMrpRate.Text.Trim()))
            {
                isValid = false;
                errMsg += "MrpRate not valid" + Environment.NewLine + Environment.NewLine;
            }
            //if (string.IsNullOrEmpty(txtQuantity.Text.Trim()))
            //{
            //    isValid = false;
            //    errMsg += "Quantity not valid" + Environment.NewLine + Environment.NewLine;
            //}
            if (string.IsNullOrEmpty(txtQuantityInBaseUom.Text.Trim()))
            {
                isValid = false;
                errMsg += "Quantity In BaseUom not valid" + Environment.NewLine + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtAllowedDamageQuantityPerUnit.Text.Trim()))
            {
                isValid = false;
                errMsg += "AllowedDamageQuantityPerUnit not valid" + Environment.NewLine + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtTotalAllowedDamageQuantity.Text.Trim()))
            {
                isValid = false;
                errMsg += "TotalAllowedDamageQuantity not valid" + Environment.NewLine + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtTotalDamageQuantityInReal.Text.Trim()))
            {
                isValid = false;
                errMsg += "TotalDamageQuantityInReal not valid" + Environment.NewLine + Environment.NewLine;
            }
            if ((chkDefaultProduct.Checked) ? (lstQuantitySummary.Items.Count == 0) : false)
            {
                isValid = false;
                errMsg += "Please add some default quantity categorywise for this product" + Environment.NewLine + Environment.NewLine;
            }
            if (lstUomSummary.Items.Count == 0)
            {
                isValid = false;
                errMsg += "Please add some Uom for this product" + Environment.NewLine + Environment.NewLine;
            }

            return isValid;
        }

        private void btnSaveproduct_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            bool prdObjGetSuccessful = true;
            Product prd = new Product();
            if (IsValidProductInput(out errMsg))
            {
                try
                {           
                    float convertedFloatNum = 0;

                    //General
                    prd.BarCode = txtBarCode.Text;
                    prd.ArticleCode = txtArticleCode.Text;
                    prd.Name = txtProdName.Text;
                    prd.ProdDescription = txtProdDesc.Text;

                    //Quantity
                    object uomQuantity = cmbQuantityUom.SelectedItem ?? new Uom { UOMName = cmbQuantityUom.Text };
                    if (uomQuantity != null)
                    {
                        prd.UnitOfMeasure = ((Uom)uomQuantity).UOMName;
                        if (string.IsNullOrEmpty(prd.UnitOfMeasure))
                        {
                            prdObjGetSuccessful = false;
                            MessageBox.Show("Unit of messuare for Quantity is not valid");
                            return;
                        }
                        //prd.Quantity = float.TryParse(txtQuantity.Text, out convertedFloatNum) ? convertedFloatNum : 0;
                    }
                    else
                    {
                        prdObjGetSuccessful = false;
                        MessageBox.Show("Unit of messuare for Quantity is not valid");
                        return;
                    }

                    //Chekbox
                    prd.Active = chkActive.Checked;
                    prd.IsDefaultGiveRation = chkDefaultToGiveRation.Checked;
                    prd.IsDefaultProduct = chkDefaultProduct.Checked;

                    //Hierarchy
                    object dept = cmbDept.SelectedItem ?? new ProductDeptMaster { ProductDeptMasterDesc  = cmbDept.Text};
                    if (dept != null)
                    {
                        ProductDeptMaster dpt = MasterData.ProductDepts.Data.Find(i => i.ProductDeptMasterDesc == ((ProductDeptMaster)dept).ProductDeptMasterDesc);
                        if (dpt == null)
                        {
                            prd.ProductDept = (ProductDeptMaster)dept;
                        }
                        else
                        {
                            prd.ProductDept = dpt;
                        }
                    }
                    else
                    {
                        prdObjGetSuccessful = false;
                        MessageBox.Show("Department is not valid");
                        return;
                    }

                    object subdept = cmbSubDept.SelectedItem ?? new ProductSubDeptMaster { ProductSubDeptMasterDesc = cmbSubDept.Text };
                    if (subdept != null)
                    {
                        ProductSubDeptMaster subDpt = MasterData.ProductSubDepts.Data.Find(i => i.ProductSubDeptMasterDesc == (((ProductSubDeptMaster)subdept).ProductSubDeptMasterDesc)
                                                    && (i.ProductDeptMasterId == prd.ProductDept.ProductDeptMasterId));
                        if (subDpt == null)
                        {
                            prd.ProductSubDept = (ProductSubDeptMaster)subdept;
                        }
                        else
                        {
                            prd.ProductSubDept = subDpt;
                        }
                    }
                    else
                    {
                        prdObjGetSuccessful = false;
                        MessageBox.Show("SubDepartment is not valid for this Department");
                        return;
                    }

                    object prdClass = cmbClass.SelectedItem ?? new ProductClassMaster { ProductClassMasterDesc = cmbClass.Text };
                    if (prdClass != null)
                    {
                        ProductClassMaster selectedClass = MasterData.ProductClasses.Data.Find(i => i.ProductClassMasterDesc == (((ProductClassMaster)prdClass).ProductClassMasterDesc)
                                                    && (i.ProductDeptMasterId == prd.ProductDept.ProductDeptMasterId)
                                                    && (i.ProductSubDeptMasterId == prd.ProductSubDept.ProductSubDeptMasterId));
                        if (selectedClass == null)
                        {
                            prd.ProductClass = (ProductClassMaster)prdClass;
                        }
                        else
                        {
                            prd.ProductClass = selectedClass;
                        }
                    }
                    else
                    {
                        prdObjGetSuccessful = false;
                        MessageBox.Show("Class is not valid for this Department and SubDepartment");
                        return;
                    }

                    object prdSubClass = cmbSubClass.SelectedItem ?? new ProductSubClassMaster { ProductSubClassMasterDesc = cmbSubClass.Text };
                    if (prdSubClass != null)
                    {
                        ProductSubClassMaster selectedSubClass = MasterData.ProductSubClasses.Data.Find(i => i.ProductSubClassMasterDesc == (((ProductSubClassMaster)prdSubClass).ProductSubClassMasterDesc)
                                                    && (i.ProductDeptMasterId == prd.ProductDept.ProductDeptMasterId)
                                                    && (i.ProductSubDeptMasterId == prd.ProductSubDept.ProductSubDeptMasterId)
                                                    && (i.ProductClassMasterId == prd.ProductClass.ProductClassMasterId));
                        if (selectedSubClass == null)
                        {
                            prd.ProductSubClass = (ProductSubClassMaster)prdSubClass;
                        }
                        else
                        {
                            prd.ProductSubClass = selectedSubClass;
                        }
                    }
                    else
                    {
                        prdObjGetSuccessful = false;
                        MessageBox.Show("SubClass is not valid for this Department, SubDepartment and Class combination");
                        return;
                    }

                    object mc = cmbMcDesc.SelectedItem ?? new ProductMcMaster { ProductMcMasterDesc = cmbMcDesc.Text };
                    if (mc != null)
                    {
                        ProductMcMaster selectedMc = MasterData.ProductMcs.Data.Find(i => i.ProductMcMasterDesc == (((ProductMcMaster)mc).ProductMcMasterDesc)
                                                    && (i.ProductDeptMasterId == prd.ProductDept.ProductDeptMasterId)
                                                    && (i.ProductSubDeptMasterId == prd.ProductSubDept.ProductSubDeptMasterId)
                                                    && (i.ProductClassMasterId == prd.ProductClass.ProductClassMasterId)
                                                    && (i.ProductSubClassMasterId == prd.ProductSubClass.ProductSubClassMasterId));
                        if (selectedMc == null)
                        {
                            prd.ProductMc = (ProductMcMaster)mc;
                            prd.ProductMc.ProductMcMasterCode = txtMcCode.Text;
                        }
                        else
                        {
                            prd.ProductMc = selectedMc;
                        }
                    }
                    else
                    {
                        prdObjGetSuccessful = false;
                        MessageBox.Show("Mc is not valid for this Department, SubDepartment, Class and SubClass combination");
                        return;
                    }

                    object brand = cmbBrand.SelectedItem ?? new ProductBrandMaster { ProductBrandMasterDesc = cmbBrand.Text };
                    if (brand != null)
                    {
                        ProductBrandMaster selectedBrand = MasterData.ProductBrands.Data.Find(i => i.ProductBrandMasterDesc == (((ProductBrandMaster)brand).ProductBrandMasterDesc)
                                                    && (i.ProductDeptMasterId == prd.ProductDept.ProductDeptMasterId)
                                                    && (i.ProductSubDeptMasterId == prd.ProductSubDept.ProductSubDeptMasterId)
                                                    && (i.ProductClassMasterId == prd.ProductClass.ProductClassMasterId)
                                                    && (i.ProductSubClassMasterId == prd.ProductSubClass.ProductSubClassMasterId)
                                                    && (i.ProductMcMasterId == prd.ProductMc.ProductMcMasterId));
                        if (selectedBrand == null)
                        {
                            prd.ProductBrand = (ProductBrandMaster)brand;
                            prd.ProductBrand.ProductBrandMasterCompanyDesc = txtBrand.Text;
                        }
                        else
                        {
                            prd.ProductBrand = selectedBrand;
                        }
                    }
                    else
                    {
                        prdObjGetSuccessful = false;
                        MessageBox.Show("Brand is not valid for this Department, SubDepartment, Class, SubClass and Mc combination");
                        return;
                    }

                    //Default Quantity
                    prd.PrdQuantityAllocated = lstQuantitySummary.Items.Cast<ProductQuantityMaster>().ToList();

                    //Uom
                    prd.AllUom = lstUomSummary.Items.Cast<Uom>().ToList();
                                        
                    //Stock
                    prd.StockInBaseUom = _lstStock;
                    //new ProductStock
                    //{
                    //    ProdQuantity = float.TryParse(txtQuantityInBaseUom.Text, out convertedFloatNum) ? convertedFloatNum : 0,
                    //    AllowedDamageQuantityPerUnit = float.TryParse(txtAllowedDamageQuantityPerUnit.Text, out convertedFloatNum) ? convertedFloatNum : 0,
                    //    TotalAllowedDamageQuantity = float.TryParse(txtTotalAllowedDamageQuantity.Text, out convertedFloatNum) ? convertedFloatNum : 0,
                    //    TotalDamageQuantityInReal = float.TryParse(txtTotalAllowedDamageQuantity.Text, out convertedFloatNum) ? convertedFloatNum : 0,
                    //    StockUom = prd.BaseUom
                    //};

                    //Rate
                    object uomType = cmbUomType.SelectedItem;
                    object baseUom = cmbBaseUom.SelectedItem;
                    if ((uomType != null) && (baseUom != null) && ((UomType)cmbUomType.SelectedItem != null) && ((Uom)cmbBaseUom.SelectedItem != null))
                    {
                        prd.BaseUom = ((Uom)cmbBaseUom.SelectedItem);
                        if (prd.BaseUom == null)
                        {
                            prdObjGetSuccessful = false;
                            MessageBox.Show("BaseUom or UomType not Valid");
                            return;
                        }
                        prd.SellingRateInBaseUom = float.TryParse(txtSellingRate.Text, out convertedFloatNum) ? convertedFloatNum : 0;
                        prd.BuyingRateInBaseUom = float.TryParse(txtBuyingRate.Text, out convertedFloatNum) ? convertedFloatNum : 0;
                        prd.MrpRateInBaseUom = float.TryParse(txtMrpRate.Text, out convertedFloatNum) ? convertedFloatNum : 0;
                    }
                    else
                    {
                        prdObjGetSuccessful = false;
                        MessageBox.Show("BaseUom or UomType not Valid");
                        return;
                    }

                    //Base Uom Correction
                    if ((prd.AllUom != null) && (prd.AllUom.Count > 0))
                    {
                        if (prd.AllUom.Any(i => i.IsBaseUom))
                        {
                            if (prd.BaseUom.UOMName != prd.AllUom.Find(i => i.IsBaseUom).UOMName)
                            {
                                prdObjGetSuccessful = false;
                                MessageBox.Show("Base Uom doesNot match with Uom list");
                                return;
                            }
                        }
                        else
                        {
                            prdObjGetSuccessful = false;
                            MessageBox.Show("Please add an Base Uom");
                        }
                    }
                }
                catch (Exception ex)
                {
                    prdObjGetSuccessful = false;
                    MessageBox.Show(lblAction.Text + " was not successful. Some input is the problem.");
                    Logger.LogError(ex);
                }

                if (prdObjGetSuccessful)
                {
                    _prd = prd;
                    try
                    {
                        string prdXml = _prd.SerializeXml<Product>();
                        List<SqlParameter> sqlParams = new List<SqlParameter>();
                        sqlParams.Add(new SqlParameter { ParameterName = "@distId", SqlDbType = SqlDbType.VarChar, Value = User.DistId });
                        sqlParams.Add(new SqlParameter { ParameterName = "@prdData", SqlDbType = SqlDbType.Xml, Value = prdXml });
                        sqlParams.Add(new SqlParameter { ParameterName = "@action", SqlDbType = SqlDbType.VarChar, Value = lblAction.Text });

                        DataSet ds = ConnectionManager.Exec("Sp_SavePrdToInventory", sqlParams);
                        if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                        {
                            MessageBox.Show("Status: " + ds.Tables[0].Rows[0]["Status"]
                                + Environment.NewLine + "Message: " + ds.Tables[0].Rows[0]["StatusMsg"]
                                + Environment.NewLine + "Name: " + ds.Tables[0].Rows[0]["Name"]);
                        }

                        ResetForm();

                        //Refresh gridview in product search page
                        FrmStockSummary frm = (FrmStockSummary)Application.OpenForms["FrmStockSummary"];
                        frm.ShowProductsToGrid(MasterData.PrdData.Data);
                        _prd = new Product();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(lblAction.Text + " was not successful");
                        Logger.LogError(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please input all the required fields." + Environment.NewLine + errMsg);
            }
        }

        private void ResetForm()
        {
            //Reset all controls
            FormHelper.ResetAllControls(this);
            FormHelper.ResetAllControls(grpbxRate);
            FormHelper.ResetAllControls(grpQuantity);
            FormHelper.ResetAllControls(grpHerarchy);
            FormHelper.ResetAllControls(grpUom);
            FormHelper.ResetAllControls(grpStock);
            chkActive.Checked = true;
            chkDefaultToGiveRation.Checked = true;
            lstQuantitySummary.DataSource = null;
            lstUomSummary.DataSource = null;
            lstStockByCategory.DataSource = null;
            _lstStock = new List<ProductStock>();

            //UomTypeDrpBind();
            //UnitUomTypeBind();
            //DeptBind();
            //CategoryBind();
            //SetQuantityIndex();
            btnStockDetails.Visible = false;
            SetInitialValueToFields();

            //Fetch all masterdata again
            MasterData.ProductDepts.Refresh();
            MasterData.ProductSubDepts.Refresh();
            MasterData.ProductClasses.Refresh();
            MasterData.ProductSubClasses.Refresh();
            MasterData.ProductMcs.Refresh();
            MasterData.ProductBrands.Refresh();
            MasterData.PrdData.Refresh();
        }

        private void cmbUomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UomBindOverUomType();
        }
        private void UomBindOverUomType()
        {
            List<Uom> filteredUom = new List<Uom>();
            var selectedUomType = cmbUomType.SelectedItem;
            if (selectedUomType != null)
            {
                UomType uomType = (UomType)selectedUomType;
                if (uomType != null)
                {
                    filteredUom = MasterData.Uoms.Data.FindAll(i => i.UOMType.Equals(uomType.UOMType)).ToList();

                    cmbBaseUom.DataSource = null;
                    cmbBaseUom.DataSource = filteredUom;
                    cmbBaseUom.DisplayMember = "UOMName";
                    cmbBaseUom.ValueMember = "UOM_Id_Identity";
                    cmbBaseUom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbBaseUom.AutoCompleteSource = AutoCompleteSource.ListItems;

                    //Need to clear Um list for that product if Uom type changes
                    //txtUomSummary.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Please select an valid Uom");
            }

            lblUom.Visible = true;
            lblUom.Text = "All rates are in Rs./" + cmbBaseUom.SelectedText;

            cmbQuantityUom.DataSource = null;
            cmbQuantityUom.DataSource = filteredUom;
            cmbQuantityUom.DisplayMember = "UOMName";
            cmbQuantityUom.ValueMember = "UOM_Id_Identity";
            cmbQuantityUom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbQuantityUom.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void txtBuyingRate_TextChanged(object sender, EventArgs e)
        {
            CalculateRateProfit();
        }

        private void CalculateRateProfit()
        {
            float convertedRate = 0;
            try
            {
                float buyingRate = float.TryParse(txtBuyingRate.Text, out convertedRate) ? convertedRate : 0;
                float sellingRate = float.TryParse(txtSellingRate.Text, out convertedRate) ? convertedRate : 0;
                float mrpRate = float.TryParse(txtMrpRate.Text, out convertedRate) ? convertedRate : 0;
                txtRateProfit.Text = (sellingRate - buyingRate).ToString("0.00");
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtSellingRate_TextChanged(object sender, EventArgs e)
        {
            CalculateRateProfit();
        }

        private void txtMrpRate_TextChanged(object sender, EventArgs e)
        {
            CalculateRateProfit();
        }

        private void btnAddQuantity_Click(object sender, EventArgs e)
        {
            float convertedNum = 0;
            var selectItem = cmbCat.SelectedItem;
            if (selectItem != null)
            {
                string cat = ((Category)selectItem).Cat_Desc;
                if ((_prd.PrdQuantityAllocated.Count > 0) && _prd.PrdQuantityAllocated.Any(i => i.CategoryDetails.Cat_Desc == cat))
                {
                    MessageBox.Show("Default quantity for category " + cat + " already added");
                }
                else
                {
                    float quantity = float.TryParse(txtDefaultRationQuantity.Text.Trim(), out convertedNum) ? convertedNum : 0;
                    bool isFamilyQuantity = chkQuantityForFamily.Checked;
                    if (quantity != 0)
                    {
                        int recCount = 0;
                        if (_prd.PrdQuantityAllocated.Count > 0)
                        {
                            recCount = (_prd.PrdQuantityAllocated.OrderBy(i => i.ProductQuantityIdentityUi).LastOrDefault()).ProductQuantityIdentityUi + 1;
                        }
                        _prd.PrdQuantityAllocated.Add(new ProductQuantityMaster
                        {
                            ProductQuantityIdentityUi = recCount,
                            DefaultQuantityInBaseUom = quantity,
                            CategoryDetails = MasterData.Categories.Data.FirstOrDefault(i => i.Cat_Desc == cat),
                            IsQuantityForFamily = isFamilyQuantity
                        });
                        lstQuantitySummary.DataSource = null;
                        lstQuantitySummary.DataSource = _prd.PrdQuantityAllocated;
                        lstQuantitySummary.ValueMember = "DefaultQuantityInBaseUom";
                        lstQuantitySummary.DisplayMember = "PrdQuantityListDisplay";
                    }
                    else
                    {
                        MessageBox.Show("Please give valid quantity");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a ctaegory to add");
            }
        }

        private void btnAddUom_Click(object sender, EventArgs e)
        {
            float convertedNum = 0;
            var selectUomType = cmbUnitUomType.SelectedItem;
            var selectUomUom = cmbUnitUom.SelectedItem;
            if ((selectUomType == null) || (selectUomUom == null))
            {
                MessageBox.Show("Please select a Uom and UomType to add");
            }
            else
            {
                string uomType = ((UomType)selectUomType).UOMType;
                string uom = ((Uom)selectUomUom).UOMName;
                if ((_prd.AllUom.Count > 0) && _prd.AllUom.Any(i => (i.UOMName == uom) && (i.UOMType == uomType)))
                {
                    MessageBox.Show("Uom " + uom + " of type " + uomType + " already added");
                }
                else
                {
                    float conversionFactor = float.TryParse(txtConversionFactor.Text.Trim(), out convertedNum) ? convertedNum : 0;
                    if (conversionFactor != 0)
                    {
                        Uom uomToBeAdded = MasterData.Uoms.Data.Find(i => (i.UOMName == uom) && (i.UOMType == uomType));
                        uomToBeAdded.ConversionFactorWithBaseUom = conversionFactor;
                        uomToBeAdded.IsBaseUom = chkIsBaseUom.Checked;

                        bool duplicateBaseUom = false;
                        foreach (object item in lstUomSummary.Items)
                        {
                            if (uomToBeAdded.IsBaseUom && (((Uom)item).IsBaseUom))
                            {
                                duplicateBaseUom = true;
                                MessageBox.Show("One BaseUom already added");
                            }
                        }
                        if (!duplicateBaseUom)
                        {
                            _prd.AllUom.Add(uomToBeAdded);
                            lstUomSummary.DataSource = null;
                            lstUomSummary.DataSource = _prd.AllUom;
                            lstUomSummary.ValueMember = "UOMName";
                            lstUomSummary.DisplayMember = "UomDisplay";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please give valid conversion factor");
                    }
                }
            }            
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubDeptBindOverDept();
        }

        private void SubDeptBindOverDept()
        {
            var selected = cmbDept.SelectedItem;
            if (selected != null)
            {
                ProductDeptMaster selectedval = (ProductDeptMaster)selected;

                cmbSubDept.DataSource = null;
                cmbSubDept.DataSource = MasterData.ProductSubDepts.Data.FindAll(i => i.ProductDeptMasterId == selectedval.ProductDeptMasterId);
                cmbSubDept.DisplayMember = "ProductSubDeptMasterDesc";
                cmbSubDept.ValueMember = "ProductSubDeptMasterId";
                cmbSubDept.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbSubDept.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        private void cmbSubDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassBindOverSubDept();
        }

        private void ClassBindOverSubDept()
        {
            var selected = cmbSubDept.SelectedItem;
            if (selected != null)
            {
                ProductSubDeptMaster selectedval = (ProductSubDeptMaster)selected;

                cmbClass.DataSource = null;
                cmbClass.DataSource = MasterData.ProductClasses.Data.FindAll(i => i.ProductSubDeptMasterId == selectedval.ProductSubDeptMasterId);
                cmbClass.DisplayMember = "ProductClassMasterDesc";
                cmbClass.ValueMember = "ProductClassMasterId";
                cmbClass.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbClass.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubClassBindOverClass();
        }

        private void SubClassBindOverClass()
        {
            var selected = cmbClass.SelectedItem;
            if (selected != null)
            {
                ProductClassMaster selectedval = (ProductClassMaster)selected;

                cmbSubClass.DataSource = null;
                cmbSubClass.DataSource = MasterData.ProductSubClasses.Data.FindAll(i => i.ProductClassMasterId == selectedval.ProductClassMasterId);
                cmbSubClass.DisplayMember = "ProductSubClassMasterDesc";
                cmbSubClass.ValueMember = "ProductSubClassMasterId";
                cmbSubClass.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbSubClass.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        private void cmbSubClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            McBindOverSubCLass();
        }

        private void McBindOverSubCLass()
        {
            var selected = cmbSubClass.SelectedItem;
            if (selected != null)
            {
                ProductSubClassMaster selectedval = (ProductSubClassMaster)selected;

                cmbMcDesc.DataSource = null;
                cmbMcDesc.DataSource = MasterData.ProductMcs.Data.FindAll(i => i.ProductSubClassMasterId == selectedval.ProductSubClassMasterId);
                cmbMcDesc.DisplayMember = "ProductMcMasterDesc";
                cmbMcDesc.ValueMember = "ProductMcMasterId";
                cmbMcDesc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbMcDesc.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        private void cmbMcDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            BrandBindOverMc();
        }

        private void BrandBindOverMc()
        {
            var selected = cmbMcDesc.SelectedItem;
            if (selected != null)
            {
                ProductMcMaster selectedval = (ProductMcMaster)selected;

                cmbBrand.DataSource = null;
                cmbBrand.DataSource = MasterData.ProductBrands.Data.FindAll(i => i.ProductMcMasterId == selectedval.ProductMcMasterId);
                cmbBrand.DisplayMember = "ProductBrandMasterDesc";
                cmbBrand.ValueMember = "ProductBrandMasterId";
                cmbBrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbBrand.AutoCompleteSource = AutoCompleteSource.ListItems;

                txtMcCode.Text = ((ProductMcMaster)cmbMcDesc.SelectedItem).ProductMcMasterCode;
            }
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cmbBrand.SelectedItem;
            if (selected != null)
            {
                ProductBrandMaster selectedval = (ProductBrandMaster)selected;

                txtBrand.Text = selectedval.ProductBrandMasterCompanyDesc;
            }
        }

        private void cmbUnitUomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnitUomBindOverUomType();
        }

        private void UnitUomBindOverUomType()
        {
            List<Uom> filteredUom = new List<Uom>();
            var selectedUomType = cmbUnitUomType.SelectedItem;
            if (selectedUomType != null)
            {
                UomType uomType = (UomType)selectedUomType;
                if (uomType != null)
                {
                    filteredUom = MasterData.Uoms.Data.FindAll(i => i.UOMType.Equals(uomType.UOMType)).ToList();

                    cmbUnitUom.DataSource = null;
                    cmbUnitUom.DataSource = filteredUom;
                    cmbUnitUom.DisplayMember = "UOMName";
                    cmbUnitUom.ValueMember = "UOM_Id_Identity";
                    cmbUnitUom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbUnitUom.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
            else
            {
                MessageBox.Show("Please select an valid Uom");
            }
        }
        
        private void UomTypeDrpBind()
        {
            cmbUomType.DataSource = null;
            cmbUomType.DataSource = MasterData.UomType.Data;
            cmbUomType.DisplayMember = "UOMType";
            cmbUomType.ValueMember = "UOMTypeId";
            cmbUomType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbUomType.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void UnitUomTypeBind()
        {
            cmbUnitUomType.DataSource = null;
            cmbUnitUomType.DataSource = MasterData.UomType.Data;
            cmbUnitUomType.DisplayMember = "UOMType";
            cmbUnitUomType.ValueMember = "UOMTypeId";
            cmbUnitUomType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbUnitUomType.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void DeptBind()
        {
            cmbDept.DataSource = null;
            cmbDept.DataSource = MasterData.ProductDepts.Data;
            cmbDept.DisplayMember = "ProductDeptMasterDesc";
            cmbDept.ValueMember = "ProductDeptMasterId";
            cmbDept.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbDept.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void CategoryBind()
        {
            cmbCat.DataSource = null;
            cmbCat.DataSource = MasterData.Categories.Data.FindAll(i=>true);
            cmbCat.DisplayMember = "Cat_desc";
            cmbCat.ValueMember = "Cat_Id";
            cmbCat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCat.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbCatStock.DataSource = null;
            cmbCatStock.DataSource = MasterData.Categories.Data.FindAll(i => true);
            cmbCatStock.DisplayMember = "Cat_desc";
            cmbCatStock.ValueMember = "Cat_Id";
            //cmbCatStock.SelectedIndex = 0;
            cmbCatStock.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCatStock.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void txtProdName_Leave(object sender, EventArgs e)
        {
            DuplicateProductCheck(txtProdName.Text, "");
        }
        private void txtBarCode_Leave(object sender, EventArgs e)
        {
            DuplicateProductCheck("", txtBarCode.Text);
        }

        private void DuplicateProductCheck(string prdName, string barCode)
        {
            List<Product> matchedPrds = MasterData.PrdData.Data.FindAll(i =>
                   ( //barcode
                    (string.IsNullOrEmpty(barCode.Trim()) ? 
                        false : 
                            ((lblAction.Text == "ADD") ? (i.BarCode == barCode) : ((i.BarCode == barCode) && (i.BarCode != _prd.BarCode)))
                    )
                   )
                   ||
                   ( //name
                    (string.IsNullOrEmpty(prdName.Trim()) ?
                        false :
                            ((lblAction.Text == "ADD") ? (i.Name == prdName) : ((i.Name == prdName) && (i.Name != _prd.Name)))
                    )
                   )
            ).ToList();

            if (matchedPrds.Count > 0)
            {
                MessageBox.Show("Product already exists." + Environment.NewLine + Environment.NewLine
                    + string.Join(Environment.NewLine, matchedPrds.Select(i => 
                    "Name : " + i.Name + Environment.NewLine
                    + "Description : " + i.ProdDescription + Environment.NewLine
                    + "ArticleCode : " + i.ArticleCode + Environment.NewLine
                    + "Brand : " + i.ProductBrand + Environment.NewLine
                    + "BarCode : " + i.BarCode).ToList()));

                txtProdName.Text = (lblAction.Text == "ADD") ? string.Empty : _prd.Name;
                txtBarCode.Text = (lblAction.Text == "ADD") ? string.Empty : _prd.BarCode;
            }
        }

        private void txtQuantityInBaseUom_KeyDown(object sender, KeyEventArgs e)
        {
            if(ValidationHelper.ValidateDecimal(sender, e))
            {
                CalculateTotalAllowedDamage();
            }
        }

        private void txtAllowedDamageQuantityPerUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if(ValidationHelper.ValidateDecimal(sender, e))
            {
                CalculateTotalAllowedDamage();
            }
        }

        private void txtTotalAllowedDamageQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            ValidationHelper.ValidateDecimal(sender, e);
        }

        private void txtTotalDamageQuantityInReal_KeyDown(object sender, KeyEventArgs e)
        {
            ValidationHelper.ValidateDecimal(sender, e);
        }

        private void txtDefaultRationQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            ValidationHelper.ValidateDecimal(sender, e);
        }

        private void txtConversionFactor_KeyDown(object sender, KeyEventArgs e)
        {
            ValidationHelper.ValidateDecimal(sender, e);
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            ValidationHelper.ValidateDecimal(sender, e);
        }

        private void txtBuyingRate_KeyDown(object sender, KeyEventArgs e)
        {
            ValidationHelper.ValidateDecimal(sender, e);
        }

        private void txtSellingRate_KeyDown(object sender, KeyEventArgs e)
        {
            ValidationHelper.ValidateDecimal(sender, e);
        }

        private void txtMrpRate_KeyDown(object sender, KeyEventArgs e)
        {
            ValidationHelper.ValidateDecimal(sender, e);
        }

        private void btnDelUom_Click(object sender, EventArgs e)
        {
            var selectUom = lstUomSummary.SelectedItem;
            if (selectUom == null)
            {
                MessageBox.Show("Please select a Uom to delete");
            }
            else
            {
                Uom uom= (Uom)selectUom;
                int indexOfUomToBeDeleted = _prd.AllUom.FindIndex(i => (i.UOMName==uom.UOMName) && (i.UOMType == uom.UOMType));
                _prd.AllUom.RemoveAt(indexOfUomToBeDeleted);

                lstUomSummary.DataSource = null;
                lstUomSummary.DataSource = _prd.AllUom;
                lstUomSummary.ValueMember = "UOMName";
                lstUomSummary.DisplayMember = "UomDisplay";
            }
        }

        private void btnDelQuantity_Click(object sender, EventArgs e)
        {
            var selectQuantity = lstQuantitySummary.SelectedItem;
            if (selectQuantity == null)
            {
                MessageBox.Show("Please select a Quantity to delete");
            }
            else
            {
                ProductQuantityMaster quantityObj = (ProductQuantityMaster)selectQuantity;
                int indexOfQuantityToBeDeleted = _prd.PrdQuantityAllocated.FindIndex(i => (i.ProductQuantityIdentityUi == quantityObj.ProductQuantityIdentityUi));
                _prd.PrdQuantityAllocated.RemoveAt(indexOfQuantityToBeDeleted);
                SetQuantityIndex();

                lstQuantitySummary.DataSource = null;
                lstQuantitySummary.DataSource = _prd.PrdQuantityAllocated;
                lstQuantitySummary.ValueMember = "DefaultQuantityInBaseUom";
                lstQuantitySummary.DisplayMember = "PrdQuantityListDisplay";
            }
        }

        private void chkQuantityForFamily_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                chkQuantityForFamily.Checked = !chkQuantityForFamily.Checked;
            }
        }

        private void chkIsBaseUom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                chkIsBaseUom.Checked = !chkIsBaseUom.Checked;
            }
        }

        private void chkActive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                chkActive.Checked = !chkActive.Checked;
            }
        }

        private void chkDefaultToGiveRation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                chkDefaultToGiveRation.Checked = !chkDefaultToGiveRation.Checked;
            }
        }

        private void chkDefaultProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                chkDefaultProduct.Checked = !chkDefaultProduct.Checked;
            }
        }
        private void BindDropdowns()
        {
            UomTypeDrpBind();
            UomBindOverUomType();
            UnitUomTypeBind();
            UnitUomBindOverUomType();

            DeptBind();
            SubDeptBindOverDept();
            ClassBindOverSubDept();
            SubClassBindOverClass();
            McBindOverSubCLass();
            BrandBindOverMc();

            CategoryBind();
        }

        private void txtProdName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtProdDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            int Product_Stock_Id_Ui_Last = 1;
            string validMsg = "";
            if (IsStockEntryValid(out validMsg))
            {
                try
                { 
                    float convertedNum = 0;
                    string catDesc = ((Category)cmbCatStock.SelectedItem).Cat_Desc;
                    //Duplicate Category check
                    if ((chkDefaultProduct.Checked) && (_lstStock.Any(i => i.CategoryDetails.Cat_Desc.Equals(catDesc))))
                    {
                        MessageBox.Show("Stock for category " + catDesc + " already added");
                    }
                    else
                    {
                        var stockToAdd = new ProductStock();
                        stockToAdd = new ProductStock
                        {
                            EntryMode = StockEntryMode.ADDSTOCK,
                            Prod_Id = _prd.Product_Master_Identity,
                            StockEntryTimeInDateFormat = DateTime.Now,
                            StockEntryTime = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss"),
                            ProdQuantity = float.TryParse(txtQuantityInBaseUom.Text, out convertedNum) ? convertedNum : 0,
                            AllowedDamageQuantityPerUnit = float.TryParse(txtAllowedDamageQuantityPerUnit.Text, out convertedNum) ? convertedNum : 0,
                            TotalAllowedDamageQuantity = float.TryParse(txtTotalAllowedDamageQuantity.Text, out convertedNum) ? convertedNum : 0,
                            TotalDamageQuantityInReal = float.TryParse(txtTotalDamageQuantityInReal.Text, out convertedNum) ? convertedNum : 0,
                            CategoryDetails = (chkDefaultProduct.Checked) 
                                                ? MasterData.Categories.Data.Find(i => i.Cat_Desc.Equals(catDesc))
                                                : null,
                            StockUom = MasterData.Uoms.Data.Find(i => i.UOMName.Equals(((Uom)cmbQuantityUom.SelectedItem).UOMName))
                        };
                        _prd.StockInBaseUom.Add(stockToAdd);
                        _prd.StockInBaseUom = _prd.StockInBaseUom.Select(i => 
                                                {
                                                    i.Product_Stock_Id_Ui = Product_Stock_Id_Ui_Last;
                                                    Product_Stock_Id_Ui_Last++;
                                                    return i;
                                                }).ToList();
                        _lstStock = _prd.StockInBaseUom.FindAll(i => i.EntryMode == StockEntryMode.ADDSTOCK);

                        lstStockByCategory.DataSource = null;
                        lstStockByCategory.DataSource = _lstStock;
                        lstStockByCategory.ValueMember = "Product_Stock_Id_Ui";
                        lstStockByCategory.DisplayMember = "StockToShow";
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show(validMsg);
            }
        }
        private bool IsStockEntryValid(out string msg)
        {
            bool isValid = true;
            msg = "Please enter valid ";
            if (txtQuantityInBaseUom.Text == "0")
            {
                isValid = false;
                msg += "Stock, ";
            }
            if (cmbQuantityUom.SelectedItem == null)
            {
                isValid = false;
                msg += "Uom, ";
            }
            if ((chkDefaultProduct.Checked) && (cmbCatStock.SelectedItem == null))
            {
                isValid = false;
                msg += "Category";
            }
            msg = isValid ? "" : msg + " before continue";
            return isValid;
        }

        private void btnDeleteStock_Click(object sender, EventArgs e)
        {
            int Product_Stock_Id_Ui_Last = 1;
            var selectStock = lstStockByCategory.SelectedItem;
            if (selectStock == null)
            {
                MessageBox.Show("Please Entry some stock to delete");
            }
            else
            {
                ProductStock stock = (ProductStock)selectStock;
                int indexOfStockToBeDeleted = _prd.StockInBaseUom.FindIndex(i => (i.Product_Stock_Id_Ui == stock.Product_Stock_Id_Ui));
                _prd.StockInBaseUom.RemoveAt(indexOfStockToBeDeleted);
                _prd.StockInBaseUom.Select(i => { i.Product_Stock_Id_Ui = Product_Stock_Id_Ui_Last; Product_Stock_Id_Ui_Last++; return i; });

                _lstStock = _prd.StockInBaseUom.FindAll(i => i.EntryMode == StockEntryMode.ADDSTOCK);

                lstStockByCategory.DataSource = null;
                lstStockByCategory.DataSource = _lstStock;
                lstStockByCategory.ValueMember = "Product_Stock_Id_Ui";
                lstStockByCategory.DisplayMember = "StockToShow";
            }
        }

        private void btnStockDetails_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmStockDetails(this);
        }

        private void chkDefaultProduct_CheckedChanged(object sender, EventArgs e)
        {
            cmbCatStock.Enabled = chkDefaultProduct.Checked;
        }

        private void CalculateTotalAllowedDamage()
        {
            float convertedNum;
            float stock = float.TryParse(txtQuantityInBaseUom.Text, out convertedNum) ? convertedNum : 0;
            float damageAllowedRate = float.TryParse(txtAllowedDamageQuantityPerUnit.Text, out convertedNum) ? convertedNum : 0;
            txtTotalAllowedDamageQuantity.Text = (damageAllowedRate * stock).ToString();
        }

        private void chkIsBaseUom_CheckedChanged(object sender, EventArgs e)
        {
            if(chkIsBaseUom.Checked)
            {
                txtConversionFactor.Text = "1";
            }
            else
            {
                txtConversionFactor.Text = "";
            }
        }
    }
}
