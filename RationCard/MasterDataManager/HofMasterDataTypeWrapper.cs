using RationCard.Model;
using System.Collections.Generic;
using System.Data;

namespace RationCard.MasterDataManager
{
    public class HofMasterDataTypeWrapper : IMasterDataTypeWrapper
    {
        public List<Hof> Data { get; set; }
        public void Refresh()
        {
            MasterDataHelper.FetchHofData();
        }
        public void Assign(DataSet ds)
        {
            MasterDataHelper.AssignHofData(ds);
        }
    }
}
