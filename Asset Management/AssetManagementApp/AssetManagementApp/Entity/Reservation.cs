using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{
    public class Reservation
    {
        public int reservation_id { get; set; }
        public int asset_id { get; set; }
        public int employee_id { get; set; }
        public DateTime reservation_date { get; set; }
        public DateTime start_Date { get; set; }
        public DateTime end_date { get; set; }
        public string status { get; set; }
    }
}
