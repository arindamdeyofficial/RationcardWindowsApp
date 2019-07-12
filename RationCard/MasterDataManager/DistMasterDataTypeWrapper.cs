using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RationCard.MasterDataManager
{
    public class DistMasterDataTypeWrapper : IMasterDataTypeWrapper
    {
        public List<Distributor> Data { get; set; }
        public void Refresh()
        {
            MasterDataHelper.FetchDistributorData();
        }
        public void Assign(DataSet ds)
        {
            MasterDataHelper.AssignDistributorData(ds);
        }
    }
}
