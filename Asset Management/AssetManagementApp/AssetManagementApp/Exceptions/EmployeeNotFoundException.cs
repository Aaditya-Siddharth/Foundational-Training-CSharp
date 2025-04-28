using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException() : base("The specified employee was not found.") { }

        public EmployeeNotFoundException(string message) : base(message) { }
    }
}
