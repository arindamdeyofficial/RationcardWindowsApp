using RationCard.Helper;
using RationCard.MasterDataManager;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace RationCard
{
    public partial class FrmStockSummary : Form
    {
        public FrmStockSummary()
        {
            InitializeComponent();
        }

        private void btnAddPrdToInventory_Click(object sender, EventArgs e)
        {
            FormHelper.OpenFrmAddProductToInventory();
            this.Refresh();
        }

        private void FrmStockSummary_Load(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Parse("01-01-1900");
            dtTo.Value = DateTime.Now;
            BindCmbDept();
            ShowProductsToGrid(MasterData.PrdData.Data);            
        }        

        public void ShowProductsToGrid(List<Product> prd)
        {
            try
            {
                grdVwPrds.DataSource = null;
                grdVwPrds.DataSource = prd;

                //make unneccesary fileds hidden
                grdVwPrds.Columns["UnitOfMeasureDetail"].Visible = false;
                grdVwPrds.Columns["UnitOfMeasure"].Visible = false;
                grdVwPrds.Columns["ConsumptionQuantity"].Visible = false;
                grdVwPrds.Columns["ConsumptionQuantityToDisplay"].Visible = false;
                //grdVwPrds.Columns["SellingRateInBaseUom"].Visible = false;
                grdVwPrds.Columns["BuyingRateInBaseUom"].Visible = false;
                grdVwPrds.Columns["MrpRateInBaseUom"].Visible = false;
                grdVwPrds.Columns["SellingRateInCurrentUom"].Visible = false;
                grdVwPrds.Columns["SellingRateInCurrentUomDisplay"].Visible = false;
                grdVwPrds.Columns["BuyingRateInCurrentUom"].Visible = false;
                grdVwPrds.Columns["BuyingRateInCurrentUomDisplay"].Visible = false;
                grdVwPrds.Columns["MrpRateInCurrentUom"].Visible = false;
                grdVwPrds.Columns["MrpRateInCurrentUomDisplay"].Visible = false;
                grdVwPrds.Columns["Discount"].Visible = false;
                grdVwPrds.Columns["DiscountToDisplay"].Visible = false;
                grdVwPrds.Columns["Total"].Visible = false;
                grdVwPrds.Columns["TotalToDisplay"].Visible = false;
                grdVwPrds.Columns["Price"].Visible = false;
                grdVwPrds.Columns["PriceToDisplay"].Visible = false;
                grdVwPrds.Columns["IsDefaultGiveRation"].Visible = false;
                grdVwPrds.Columns["Product_Master_Identity"].Visible = false;
                grdVwPrds.Columns["BarCode"].Visible = false;
                grdVwPrds.Columns["BaseUom"].Visible = false;
                grdVwPrds.Columns["ProdDescription"].Visible = false;
                grdVwPrds.Columns["Active"].Visible = false;

                grdVwPrds.Columns["ProductDept"].Visible = false;
                grdVwPrds.Columns["ProductSubDept"].Visible = false;
                grdVwPrds.Columns["ProductClass"].Visible = false;
                grdVwPrds.Columns["ProductSubClass"].Visible = false;
                grdVwPrds.Columns["ProductMc"].Visible = false;
                grdVwPrds.Columns["ProductBrand"].Visible = false;

                grdVwPrds.Columns["Name"].HeaderText = "Name";
                grdVwPrds.Columns["Name"].DisplayIndex = 1;
                grdVwPrds.Columns["Name"].Width = 200;
                grdVwPrds.Columns["Name"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.ColumnHeader, true);

                grdVwPrds.Columns["ArticleCode"].HeaderText = "ArticleCode";
                grdVwPrds.Columns["ArticleCode"].DisplayIndex = 2;
                grdVwPrds.Columns["ArticleCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                grdVwPrds.Columns["ArticleCode"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.ColumnHeader, true);
                grdVwPrds.Columns["ArticleCode"].ReadOnly = true;

                grdVwPrds.Columns["IsDefaultProduct"].HeaderText = "IsDefaultProduct";
                grdVwPrds.Columns["IsDefaultProduct"].DisplayIndex = 3;
                grdVwPrds.Columns["IsDefaultProduct"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                grdVwPrds.Columns["IsDefaultProduct"].ReadOnly = true;
                grdVwPrds.Columns["IsDefaultProduct"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.ColumnHeader, true);

                grdVwPrds.Columns["SellingRateInBaseUom"].HeaderText = "SellingRateInBaseUom";
                grdVwPrds.Columns["SellingRateInBaseUom"].DisplayIndex = 4;
                grdVwPrds.Columns["SellingRateInBaseUom"].ReadOnly = true;
                grdVwPrds.Columns["SellingRateInBaseUom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                grdVwPrds.Columns["SellingRateInBaseUom"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.ColumnHeader, true);
                grdVwPrds.Refresh();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void grdVwPrds_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Product prd = MasterData.PrdData.Data.FirstOrDefault(i => i.Name == grdVwPrds.Rows[e.RowIndex].Cells["Name"].Value.ToString());
            FormHelper.OpenFrmProductDetails(prd);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@distId", SqlDbType = SqlDbType.VarChar, Value = User.DistId });
                sqlParams.Add(new SqlParameter { ParameterName = "@barCode", SqlDbType = SqlDbType.VarChar, Value = txtBarCode.Text.Trim() });
                sqlParams.Add(new SqlParameter { ParameterName = "@articleCode", SqlDbType = SqlDbType.VarChar, Value = txtArticleCode.Text.Trim() });
                sqlParams.Add(new SqlParameter { ParameterName = "@prdName", SqlDbType = SqlDbType.VarChar, Value = txtPrdName.Text.Trim() });
                sqlParams.Add(new SqlParameter { ParameterName = "@description", SqlDbType = SqlDbType.VarChar, Value = txtProdDesc.Text.Trim() });
                sqlParams.Add(new SqlParameter { ParameterName = "@isActive", SqlDbType = SqlDbType.Bit, Value = chkActive.Checked });
                sqlParams.Add(new SqlParameter { ParameterName = "@isDefaultToGiveRation", SqlDbType = SqlDbType.Bit, Value = chkDefaultToGiveRation.Checked });
                sqlParams.Add(new SqlParameter { ParameterName = "@isDefaultPrd", SqlDbType = SqlDbType.Bit, Value = chkDefaultProduct.Checked });
                sqlParams.Add(new SqlParameter { ParameterName = "@dept", SqlDbType = SqlDbType.VarChar, Value = ((cmbDept.SelectedItem == null) ? string.Empty : ((ProductDeptMaster)cmbDept.SelectedItem).ProductDeptMasterId) });
                sqlParams.Add(new SqlParameter { ParameterName = "@subDept", SqlDbType = SqlDbType.VarChar, Value = ((cmbSubDept.SelectedItem == null) ? string.Empty : ((ProductSubDeptMaster)cmbSubDept.SelectedItem).ProductSubDeptMasterId) });
                sqlParams.Add(new SqlParameter { ParameterName = "@class", SqlDbType = SqlDbType.VarChar, Value = ((cmbClass.SelectedItem == null) ? string.Empty : ((ProductClassMaster)cmbClass.SelectedItem).ProductClassMasterId) });
                sqlParams.Add(new SqlParameter { ParameterName = "@subClass", SqlDbType = SqlDbType.VarChar, Value = ((cmbSubClass.SelectedItem == null) ? string.Empty : ((ProductSubClassMaster)cmbSubClass.SelectedItem).ProductSubClassMasterId) });
                sqlParams.Add(new SqlParameter { ParameterName = "@mc", SqlDbType = SqlDbType.VarChar, Value = ((cmbMcDesc.SelectedItem == null) ? string.Empty : ((ProductMcMaster)cmbMcDesc.SelectedItem).ProductMcMasterId) });
                sqlParams.Add(new SqlParameter { ParameterName = "@mcCode", SqlDbType = SqlDbType.VarChar, Value = txtMcCode.Text.Trim() });
                sqlParams.Add(new SqlParameter { ParameterName = "@brand", SqlDbType = SqlDbType.VarChar, Value = ((cmbBrand.SelectedItem == null) ? string.Empty : ((ProductBrandMaster)cmbBrand.SelectedItem).ProductBrandMasterId) });
                sqlParams.Add(new SqlParameter { ParameterName = "@brandCompany", SqlDbType = SqlDbType.VarChar, Value = txtBrandCompany.Text.Trim() });
                sqlParams.Add(new SqlParameter { ParameterName = "@dtFrom", SqlDbType = SqlDbType.DateTime, Value = dtFrom.Text });
                sqlParams.Add(new SqlParameter { ParameterName = "@dtTo", SqlDbType = SqlDbType.DateTime, Value = dtTo.Text });

                DataSet ds = ConnectionManager.Exec("Sp_Product_Search", sqlParams);
                if ((ds != null) && (ds.Tables.Count > 1) && (ds.Tables[0].Rows.Count > 0))
                {
                    DataSet tmpDs = new DataSet();
                    tmpDs.Tables.Add(ds.Tables[0].Copy());
                    tmpDs.Tables.Add(ds.Tables[1].Copy());
                    tmpDs.Tables.Add(ds.Tables[2].Copy());
                    tmpDs.Tables.Add(ds.Tables[3].Copy());
                    ShowProductsToGrid(MasterDataHelper.ExtractProductFromDataset(tmpDs));
                    tmpDs.Reset();
                }
                else
                {
                    ShowProductsToGrid(new List<Product>());
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubDept();
        }

        private void cmbSubDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbClassBind();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSubClassBind();
        }

        private void cmbSubClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMcDescBind();
        }

        private void cmbMcDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBrandBind();
        }

        private void BindCmbDept()
        {
            List<ProductDeptMaster> dataSource = MasterData.ProductDepts.Data.FindAll(i => true);
            var allDept = new ProductDeptMaster { ProductDeptMasterId = "0", ProductDeptMasterDesc = "All Dept" };
            dataSource.Add(allDept);
            cmbDept.DataSource = null;
            cmbDept.DataSource = dataSource;
            cmbDept.DisplayMember = "ProductDeptMasterDesc";
            cmbDept.ValueMember = "ProductDeptMasterId";
            cmbDept.SelectedItem = allDept;
        }
        private void BindSubDept()
        {
            List<ProductSubDeptMaster> dataSource = MasterData.ProductSubDepts.Data.FindAll(i => i.ProductDeptMasterId == cmbDept.SelectedValue.ToString());
            var allSubDept = new ProductSubDeptMaster { ProductSubDeptMasterId = "0", ProductSubDeptMasterDesc = "All SubDept" };
            dataSource.Add(allSubDept);
            cmbSubDept.DataSource = null;
            cmbSubDept.DataSource = dataSource;
            cmbSubDept.DisplayMember = "ProductSubDeptMasterDesc";
            cmbSubDept.ValueMember = "ProductSubDeptMasterId";
            //cmbSubDept.SelectedItem = allSubDept;
        }
        private void cmbClassBind()
        {
            List<ProductClassMaster> dataSource = MasterData.ProductClasses.Data.FindAll(i => i.ProductSubDeptMasterId 
                                                                == ((cmbSubDept.SelectedValue != null) ? cmbSubDept.SelectedValue .ToString(): ""));
            var allClass = new ProductClassMaster { ProductClassMasterId = "0", ProductClassMasterDesc = "All Class" };
            dataSource.Add(allClass);
            cmbClass.DataSource = null;
            cmbClass.DataSource = dataSource;
            cmbClass.DisplayMember = "ProductClassMasterDesc";
            cmbClass.ValueMember = "ProductClassMasterId";
            //cmbClass.SelectedItem = allClass;
        }

        private void cmbSubClassBind()
        {
            List<ProductSubClassMaster> dataSource = MasterData.ProductSubClasses.Data.FindAll(i => i.ProductClassMasterId 
                                                               == ((cmbClass.SelectedValue != null) ? cmbClass.SelectedValue.ToString() : ""));
            var allSubClass = new ProductSubClassMaster { ProductSubClassMasterId = "0", ProductSubClassMasterDesc = "All SubClass" };
            dataSource.Add(allSubClass);
            cmbClass.DataSource = null;
            cmbSubClass.DataSource = dataSource;
            cmbSubClass.DisplayMember = "ProductSubClassMasterDesc";
            cmbSubClass.ValueMember = "ProductSubClassMasterId";
            //cmbSubClass.SelectedItem = allSubClass;
        }
        private void cmbMcDescBind()
        {
            List<ProductMcMaster> dataSource = MasterData.ProductMcs.Data.FindAll(i => i.ProductSubClassMasterId 
                                                               == ((cmbSubClass.SelectedValue != null) ? cmbSubClass.SelectedValue.ToString() : ""));
            var allMcs = new ProductMcMaster { ProductMcMasterId = "0", ProductMcMasterDesc = "All Mc" };
            dataSource.Add(allMcs);
            cmbClass.DataSource = null;
            cmbMcDesc.DataSource = dataSource;
            cmbMcDesc.DisplayMember = "ProductMcMasterDesc";
            cmbMcDesc.ValueMember = "ProductMcMasterId";
            //cmbSubClass.SelectedItem = allMcs;
        }
        private void cmbBrandBind()
        {
            List<ProductBrandMaster> dataSource = MasterData.ProductBrands.Data.FindAll(i => i.ProductMcMasterId 
                                                                == ((cmbMcDesc.SelectedValue != null) ? cmbMcDesc.SelectedValue.ToString() : ""));
            var allBrands = new ProductBrandMaster { ProductBrandMasterId = "0", ProductBrandMasterDesc = "All Brand" };
            dataSource.Add(allBrands);
            cmbClass.DataSource = null;
            cmbBrand.DataSource = dataSource;
            cmbBrand.DisplayMember = "ProductBrandMasterDesc";
            cmbBrand.ValueMember = "ProductBrandMasterId";
            //cmbBrand.SelectedItem = allBrands;
            if (cmbMcDesc.SelectedItem != null)
            {
                txtMcCode.Text = ((ProductMcMaster)cmbMcDesc.SelectedItem).ProductMcMasterCode;
            }
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBrandCompany.Text = ((ProductBrandMaster)cmbBrand.SelectedItem).ProductBrandMasterCompanyDesc;
        }

        private void btnRefreshProduct_Click(object sender, EventArgs e)
        {
            ShowProductsToGrid(MasterData.PrdData.Data);
        }

        private void btnDelPrd_Click(object sender, EventArgs e)
        {
            if (grdVwPrds.CurrentRow != null)
            {
                string password = DialogConfirm.ShowInputDialog("Please provide password to continue.", "Confirm with Password");
                string finalPass = SecurityEncrypt.Decrypt(ConfigManager.GetConfigValue("ActionConfirmPassword"), "nakshal");

                if (password == finalPass)
                {
                    DeleteProduct();
                }
                else if (password == "")
                {
                    MessageBox.Show("Delete has been canceled by user.");
                }
                else
                {
                    MessageBox.Show("Wrong Password.");
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete");
            }
        }

        private void DeleteProduct()
        {
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@distId", SqlDbType = SqlDbType.VarChar, Value = User.DistId });
                sqlParams.Add(new SqlParameter { ParameterName = "@table", SqlDbType = SqlDbType.VarChar, Value = "Product_Master" });
                sqlParams.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = grdVwPrds.CurrentRow.Cells["Product_Master_Identity"].Value.ToString() });
                sqlParams.Add(new SqlParameter { ParameterName = "@action", SqlDbType = SqlDbType.VarChar, Value = "DELETE" });

                DataSet ds = ConnectionManager.Exec("Sp_ProductTablesData", sqlParams);
                if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    MessageBox.Show("Product successfuly deleted");
                    MasterData.PrdData.Refresh();
                    ShowProductsToGrid(MasterData.PrdData.Data);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnPrintStockReport_Click(object sender, EventArgs e)
        {
            try
            {
                string rptHeader = "Dealer Name\t\t : " + User.Name + Environment.NewLine
                   + "Liscence Number\t : " + User.LiscenceNo + Environment.NewLine
                   + "MR Shop Number\t : "
                   + User.MrShopNo + Environment.NewLine + Environment.NewLine + Environment.NewLine;

                string rptCriteria = "From " + dtFrom.Value + "To " + dtTo.Value;

                string rptDate = Environment.NewLine + "Date : " + DateTime.Now.ToLongDateString();
                string rptSignature = "____________________" + Environment.NewLine + "\t Signature";
                StockPrint.PrintForm(
                        (List<Product>)grdVwPrds.DataSource
                        , rptHeader
                        , rptCriteria
                        , rptDate
                        , rptSignature
                        , "L"
                        , "A3"
                        , "Daily Stock Register"
                    );
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnStckReportForDefaultProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string rptHeader = "Dealer Name\t\t : " + User.Name + Environment.NewLine
                   + "Liscence Number\t : " + User.LiscenceNo + Environment.NewLine
                   + "MR Shop Number\t : "
                   + User.MrShopNo + Environment.NewLine + Environment.NewLine + Environment.NewLine;

                string rptCriteria = "From " + dtFrom.Value + "To " + dtTo.Value;

                string rptDate = Environment.NewLine + "Date : " + DateTime.Now.ToLongDateString();
                string rptSignature = "____________________" + Environment.NewLine + "\t Signature";
                StockPrint.PrintForm(
                        MasterData.PrdData.Data.FindAll(i=>i.IsDefaultProduct)
                        , rptHeader
                        , rptCriteria
                        , rptDate
                        , rptSignature
                        , "L"
                        , "A3"
                        , "Daily Stock Register"
                    );
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
