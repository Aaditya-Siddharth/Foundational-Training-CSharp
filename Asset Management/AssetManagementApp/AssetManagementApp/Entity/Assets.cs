using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{
    public class Assets
    {
            public int asset_id { get; set; }
            public string name { get; set; }
            public string Type { get; set; }
            public int serial_number { get; set; }
            public DateTime purchasedate { get; set; }
            public string location { get; set; }
            public string status { get; set; }
            public int owner_id { get; set; }
    }
}
