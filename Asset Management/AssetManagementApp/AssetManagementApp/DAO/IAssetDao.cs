using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.DAO
{
    public interface IAssetDao<T>
    {
        T AddAsset(T asset);
        bool DeleteAsset(int asset_id);
        T UpdateAsset(T asset);
        T GetAssetById(int asset_id);
        List<T> GetAllAssets();
    }
}
