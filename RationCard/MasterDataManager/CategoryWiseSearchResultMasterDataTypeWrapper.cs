using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RationCard.MasterDataManager
{
    public class CategoryWiseSearchResultMasterDataTypeWrapper : IMasterDataTypeWrapper
    {
        public List<CategoryWiseSearchResult> Data { get; set; }
        public void Refresh()
        {
            MasterDataHelper.FetchCategoryWiseSearchResult();
        }
        public void Assign(DataSet ds)
        {
            MasterDataHelper.FetchCategoryWiseSearchResult();
        }
    }
}
