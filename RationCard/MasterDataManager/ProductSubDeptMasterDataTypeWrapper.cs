using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RationCard.MasterDataManager
{
    public class ProductSubDeptMasterDataTypeWrapper : IMasterDataTypeWrapper
    {
        public List<ProductSubDeptMaster> Data { get; set; }
        public void Refresh()
        {
            MasterDataHelper.FetchSubDeptData();
        }
        public void Assign(DataSet ds)
        {
            MasterDataHelper.AssignProductSubDeptData(ds);
        }
    }
}
