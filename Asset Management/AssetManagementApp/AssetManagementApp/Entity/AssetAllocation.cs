using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{
    public class AssetAllocation
    {
        public int allocation_id { get; set; }
        public int asset_id { get; set; }
        public int employee_id { get; set; }
        public DateTime allocation_date { get; set; }
        public DateTime? return_date { get; set; }
    }
}
