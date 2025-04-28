using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.DAO
{
    public interface IMaintenanceDao<T>
    {
        T AddMaintenanceRecord(T maintenance);
        bool DeleteMaintenanceRecord(int maintenance_id);
        T UpdateMaintenanceRecord(T maintenance);
        T GetMaintenanceRecordById(int maintenance_id);
        List<T> GetAllMaintenanceRecords();
    }
}
