using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RationCard.MasterDataManager
{
    public class ProductBrandMasterDataTypeWrapper : IMasterDataTypeWrapper
    {
        public List<ProductBrandMaster> Data { get; set; }
        public void Refresh()
        {
            MasterDataHelper.FetchBrandData();
        }
        public void Assign(DataSet ds)
        {
            MasterDataHelper.AssignProductBrandData(ds);
        }
    }
}
