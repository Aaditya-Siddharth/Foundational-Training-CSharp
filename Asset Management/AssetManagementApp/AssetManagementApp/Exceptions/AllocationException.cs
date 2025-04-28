using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Exceptions
{
    public class AllocationException : Exception
    {
        public AllocationException() : base("An error occurred during asset allocation.") { }

        public AllocationException(string message) : base(message) { }
    }
}
