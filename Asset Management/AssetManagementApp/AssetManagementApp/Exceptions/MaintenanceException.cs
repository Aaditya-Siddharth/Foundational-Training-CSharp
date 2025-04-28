using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Exceptions
{
    public class MaintenanceException : Exception
    {
        public MaintenanceException() : base("An error occurred while recording maintenance.") { }

        public MaintenanceException(string message) : base(message) { }
    }
}
