using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{
    public class Employees
    {
        internal int employee_id;

        public int employee_Id { get; set; }
            public string name { get; set; }
            public string department { get; set; }
            public string email { get; set; }
            public string password { get; set; }
    }

}
