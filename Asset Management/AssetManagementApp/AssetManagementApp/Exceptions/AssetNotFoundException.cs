using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Exceptions
{
    public class AssetNotFoundException : Exception
    {
        public AssetNotFoundException() : base("The specified asset was not found.") { }

        public AssetNotFoundException(string message) : base(message) { }
    }
}
