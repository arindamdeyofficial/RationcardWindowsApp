﻿using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RationCard.MasterDataManager
{
    public class ProductDeptMasterDataTypeWrapper : IMasterDataTypeWrapper
    {
        public List<ProductDeptMaster> Data { get; set; }
        public void Refresh()
        {
            MasterDataHelper.FetchDeptData();
        }
        public void Assign(DataSet ds)
        {
            MasterDataHelper.AssignProductDeptData(ds);
        }
    }
}
