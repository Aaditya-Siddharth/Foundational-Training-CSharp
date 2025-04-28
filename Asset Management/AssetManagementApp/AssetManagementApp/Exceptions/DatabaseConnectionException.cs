using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Exceptions
{
    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException() : base("Could not connect to the database.") { }

        public DatabaseConnectionException(string message) : base(message) { }
    }
}
