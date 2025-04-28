using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{
    public class MaintenanceRecord
    {
        public int maintenance_id { get; set; }
        public int asset_id { get; set; }
        public DateTime maintenance_date { get; set; }
        public string description { get; set; }
        public decimal cost { get; set; }
    }
}
