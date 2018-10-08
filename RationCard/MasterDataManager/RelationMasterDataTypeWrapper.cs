using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RationCard.MasterDataManager
{
    public class RelationMasterDataTypeWrapper : IMasterDataTypeWrapper
    {
        public List<RelationMaster> Data { get; set; }
        public void Refresh()
        {
            MasterDataHelper.FetchRelationData();
        }
        public void Assign(DataSet ds)
        {
            MasterDataHelper.AssignRelationData(ds);
        }
    }
}
