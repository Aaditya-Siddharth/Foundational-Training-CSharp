using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.DAO
{
    public interface IAssetAllocationDao<T>
    {
        T AllocateAsset(T allocation);
        //bool DeallocateAsset(int allocation_id);
        T UpdateAllocation(T allocation);
        T GetAllocationById(int allocation_id);

        bool DeleteAllocation(int allocation_id);
        List<T> GetAllAllocations();
    }
}
