using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RationCard.MasterDataManager
{
    public class CardsOfThisFortnightWrapper : IMasterDataTypeWrapper
    {
        public List<string> Data { get; set; }
        public void Refresh()
        {
            MasterDataHelper.FetchCardsOfThisFortnight();
        }
        public void Assign(DataSet ds)
        {
            MasterDataHelper.AssignCardsOfThisFortnight(ds);
        }
    }
}
