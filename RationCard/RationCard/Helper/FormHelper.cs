using RationCard.Model;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RationCard.Helper
{
    public class FormHelper
    {
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
                rationEntry.RefreshCatWiseCount();
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
        public static Form OpenFrmPrdQuantityInBill(string uomType)
        {
            Form frmObj = Application.OpenForms["FrmPrdQuantityInBill"];
            if (frmObj != null)
            {
                frmObj.Visible = true;
                frmObj.Focus();
                ((FrmPrdQuantityInBill)frmObj).UpdateUomList(uomType);
            }
            else
            {
                FrmPrdQuantityInBill prdQuantityInBill = new FrmPrdQuantityInBill(uomType);
                prdQuantityInBill.Show();
                frmObj = prdQuantityInBill;
            }
            return frmObj;
        }
    }
}
