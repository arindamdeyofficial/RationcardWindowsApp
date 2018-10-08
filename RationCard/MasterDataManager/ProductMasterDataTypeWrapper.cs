using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RationCard.MasterDataManager
{
    public class ProductMasterDataTypeWrapper: IMasterDataTypeWrapper
    {
        public List<Product> Data { get; set; }
        public void Refresh()
        {
            MasterDataHelper.FetchProductData();
        }
        public void Assign(DataSet ds)
        {
            MasterDataHelper.AssignProductData(ds);
        }
    }
}
