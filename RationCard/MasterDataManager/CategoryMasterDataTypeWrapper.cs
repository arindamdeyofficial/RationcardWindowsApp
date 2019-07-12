using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RationCard.MasterDataManager
{
    public class CategoryMasterDataTypeWrapper : IMasterDataTypeWrapper
    {
        public List<Category> Data { get; set; }
        public void Refresh()
        {
            MasterDataHelper.FetchCategoryData();
        }
        public void Assign(DataSet ds)
        {
            MasterDataHelper.AssignCategoryData(ds);
        }
    }
}
