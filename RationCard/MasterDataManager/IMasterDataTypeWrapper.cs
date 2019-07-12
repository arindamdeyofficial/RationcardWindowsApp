using System.Data;

namespace RationCard.MasterDataManager
{
    public interface IMasterDataTypeWrapper
    {
        void Refresh();
        void Assign(DataSet ds);
    }
}
