using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RationCard.MasterDataManager
{
    public class UomMasterDataTypeWrapper : IMasterDataTypeWrapper
    {
        public List<Uom> Data { get; set; }
        public void Refresh()
        {
            MasterDataHelper.FetchUomData();
        }
        public void Assign(DataSet ds)
        {
            MasterDataHelper.AssignUomData(ds);
        }
    }
}
