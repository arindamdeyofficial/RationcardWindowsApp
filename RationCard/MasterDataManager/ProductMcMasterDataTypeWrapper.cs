using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RationCard.MasterDataManager
{
    public class ProductMcMasterDataTypeWrapper : IMasterDataTypeWrapper
    {
        public List<ProductMcMaster> Data { get; set; }
        public void Refresh()
        {
            MasterDataHelper.FetchMcData();
        }
        public void Assign(DataSet ds)
        {
            MasterDataHelper.AssignProductMcData(ds);
        }
    }
}
