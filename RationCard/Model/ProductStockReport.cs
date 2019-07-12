using RationCard.MasterDataManager;
using System;
using System.Xml.Serialization;

namespace RationCard.Model
{
    [Serializable]
    public class ProductStockReport
    {
        [XmlAttribute]
        public string Product_Stock_Report_Identity { get; set; }
        [XmlAttribute]
        public string Prod_Id { get; set; }
        [XmlIgnore]
        public string ProdName
        {
            get

            {
                string prodSearched = "";
                if (!String.IsNullOrEmpty(Prod_Id.Trim()))
                {
                    Product prod = MasterData.PrdData.Data.Find(i => i.Product_Master_Identity == Prod_Id);
                    if (prod != null)
                    {
                        prodSearched = prod.Name;
                    }
                }

                return prodSearched;
            }
        }
        [XmlAttribute]
        public string Dist_Id { get; set; }
        [XmlAttribute]
        public string Cat_Id { get; set; }
        [XmlIgnore]
        public string Cat_Desc { get

            {
                string catSearched = "";
                if (!String.IsNullOrEmpty(Cat_Id.Trim()))
                {
                    Category cat = MasterData.Categories.Data.Find(i => i.Cat_Id == Cat_Id);
                    if(cat != null)
                    {
                        catSearched = cat.Cat_Desc;
                    }
                }

                return catSearched;
            } }
        [XmlAttribute]
        public string UOM_Id { get; set; }
        [XmlAttribute]
        public string OpenningBalance { get; set; }
        [XmlAttribute]
        public string StockRecieved { get; set; }
        [XmlAttribute]
        public string TotalStock { get; set; }
        [XmlAttribute]
        public string StockSold { get; set; }
        [XmlIgnore]
        public string HandlingLoss { get; set; }
        [XmlAttribute]
        public string ClosingBalance { get; set; }
        [XmlAttribute]
        public string Created_Date { get; set; }
    }
}
