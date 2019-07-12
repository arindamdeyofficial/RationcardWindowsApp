using RationCard.HelperForms;
using RationCard.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RationCard.Helper
{
    public class FormHelper
    {
        public static void ResetAllControls(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }

                if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.ClearSelected();
                }
            }
        }
        public static Form OpenFrmLogin()
        {
            Form frmObj = Application.OpenForms["FrmLogin"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
                frmObj = frmLogin;
            }
            return frmObj;
        }
        public static Form OpenFrmFrontDeskEntry()
        {
            Form frmObj = Application.OpenForms["FrmFrontDeskEntry"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmFrontDeskEntry frontDesk = new FrmFrontDeskEntry();
                frontDesk.Show();
                frmObj = frontDesk;
            }
            return frmObj;
        }
        public static Form OpenFrmSearchResult()
        {
            Form frmObj = Application.OpenForms["FrmSearchResult"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmSearchResult searchResult = new FrmSearchResult((FrmRationEntry)OpenFrmRationEntry());
                searchResult.Show();
                frmObj = searchResult;
            }
            return frmObj;
        }

        public static Form OpenFrmRationEntry()
        {
            Form frmObj = Application.OpenForms["FrmRationEntry"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmRationEntry rationEntry = new FrmRationEntry();
                rationEntry.Show();
                rationEntry.RefreshCatWiseCountInUi();
                frmObj = rationEntry;
            }
            return frmObj;
        }

        public static Form OpenFrmCatwiseCount()
        {
            Form frmObj = Application.OpenForms["FrmCatwiseCount"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmCatwiseCount catwiseCount = new FrmCatwiseCount((FrmRationEntry)OpenFrmRationEntry());
                catwiseCount.Show();
                frmObj = catwiseCount;
            }
            return frmObj;
        }

        public static Form OpenFrmRationcardHome()
        {
            Form frmObj = Application.OpenForms["FrmRationcardHome"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmRationcardHome rationcardHome = new FrmRationcardHome();
                rationcardHome.Show();
                frmObj = rationcardHome;
            }
            return frmObj;
        }

        public static Form OpenRationBillDetails(List<RationCardDetailExtended> membersToGiveRation)
        {
            Form frmObj = Application.OpenForms["FrmRationBillDetails"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmRationBillDetails rationBillDetails = new FrmRationBillDetails(membersToGiveRation);
                rationBillDetails.Show();
                frmObj = rationBillDetails;
            }
            return frmObj;
        }

        public static void CloseRationBillDetails()
        {
            Form frmObj = Application.OpenForms["FrmRationBillDetails"];
            if (frmObj != null)
            {
                frmObj.Close();
            }
        }
        public static void CloseFrmPrdQuantityInBill()
        {
            Form frmObj = Application.OpenForms["FrmPrdQuantityInBill"];
            if (frmObj != null)
            {
                frmObj.Close();
            }
        }
        public static Form OpenFrmPrdQuantityInBill(Product prd)
        {
            Form frmObj = Application.OpenForms["FrmPrdQuantityInBill"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
                ((FrmPrdQuantityInBill)frmObj).UpdateUomList(prd);
            }
            else
            {
                FrmPrdQuantityInBill prdQuantityInBill = new FrmPrdQuantityInBill(prd);
                prdQuantityInBill.Show();
                frmObj = prdQuantityInBill;
            }
            return frmObj;
        }
        public static Form OpenFrmStockSummary()
        {
            Form frmObj = Application.OpenForms["FrmStockSummary"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmStockSummary stck = new FrmStockSummary();
                stck.Show();
                frmObj = stck;
            }
            return frmObj;
        }
        public static Form OpenFrmAddProductToInventory()
        {
            Form frmObj = Application.OpenForms["FrmAddProductToInventory"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmProductDetails frmAddProductToInventory = new FrmProductDetails();
                frmAddProductToInventory.Show();
                frmObj = frmAddProductToInventory;
            }
            return frmObj;
        }

        public static Form OpenFrmProductDetails(Product prd)
        {
            FrmProductDetails frmObj = (FrmProductDetails)Application.OpenForms["FrmProductDetails"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
                frmObj.OpenExistingProduct(prd);
            }
            else
            {
                FrmProductDetails frmProductDetails = new FrmProductDetails(prd);
                frmProductDetails.Show();
                frmObj = frmProductDetails;
            }
            return (Form)frmObj;
        }

        public static Form OpenHelperMaster()
        {
            Form frmObj = Application.OpenForms["HelperMaster"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                HelperMaster helperMaster = new HelperMaster();
                helperMaster.Show();
                frmObj = helperMaster;
            }
            return frmObj;
        }

        public static Form OpenMacId()
        {
            Form frmObj = Application.OpenForms["MacId"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                MacId macId = new MacId();
                macId.Show();
                frmObj = macId;
            }
            return frmObj;
        }

        public static Form OpenFrmConnectionString()
        {
            Form frmObj = Application.OpenForms["FrmConnectionString"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmConnectionString frmConnectionString = new FrmConnectionString();
                frmConnectionString.Show();
                frmObj = frmConnectionString;
            }
            return frmObj;
        }

        public static Form OpenOrphanRecord()
        {
            Form frmObj = Application.OpenForms["OrphanRecord"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                OrphanRecord orphanRecord = new OrphanRecord();
                orphanRecord.Show();
                frmObj = orphanRecord;
            }
            return frmObj;
        }

        public static Form OpenFrmFrameworkVersion()
        {
            Form frmObj = Application.OpenForms["FrmFrameworkVersion"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmFrameworkVersion frameworkVersion = new FrmFrameworkVersion();
                frameworkVersion.Show();
                frmObj = frameworkVersion;
            }
            return frmObj;
        }

        public static Form OpenFrmSetup()
        {
            Form frmObj = Application.OpenForms["FrmSetup"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmSetup frmSetup = new FrmSetup();
                frmSetup.Show();
                frmObj = frmSetup;
            }
            return frmObj;
        }

        public static Form OpenSecurityCodeMail()
        {
            Form frmObj = Application.OpenForms["SecurityCodeMail"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                SecurityCodeMail securityCodeMail = new SecurityCodeMail();
                securityCodeMail.Show();
                frmObj = securityCodeMail;
            }
            return frmObj;
        }

        public static Form OpenFrmUsers()
        {
            Form frmObj = Application.OpenForms["FrmUsers"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmUsers frmUsers = new FrmUsers();
                frmUsers.Show();
                frmObj = frmUsers;
            }
            return frmObj;
        }        
        public static Form OpenFrmUserSelector()
        {
            Form frmObj = Application.OpenForms["FrmUserSelector"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmUserSelector frmUsers = new FrmUserSelector();
                frmUsers.Show();
                frmObj = frmUsers;
            }
            return frmObj;
        }

        public static Form OpenFrmProductTables()
        {
            Form frmObj = Application.OpenForms["FrmProductTables"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmProductTables frmProductTables = new FrmProductTables();
                frmProductTables.Show();
                frmObj = frmProductTables;
            }
            return frmObj;
        }

        public static Form OpenFrmAppConfig()
        {
            Form frmObj = Application.OpenForms["FrmAppConfig"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmAppConfig frmAppConfig = new FrmAppConfig();
                frmAppConfig.Show();
                frmObj = frmAppConfig;
            }
            return frmObj;
        }

        public static Form OpenFrmCleanAuditTables()
        {
            Form frmObj = Application.OpenForms["FrmCleanAuditTables"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmCleanAuditTables frmCleanAuditTables = new FrmCleanAuditTables();
                frmCleanAuditTables.Show();
                frmObj = frmCleanAuditTables;
            }
            return frmObj;
        }

        public static Form OpenFrmStockDetails(FrmProductDetails prd)
        {
            Form frmObj = Application.OpenForms["FrmStockDetails"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
            }
            else
            {
                FrmStockDetails frmStockDetails = new FrmStockDetails(prd);
                frmStockDetails.Show();
                frmObj = frmStockDetails;
            }
            return frmObj;
        }
    }
}
