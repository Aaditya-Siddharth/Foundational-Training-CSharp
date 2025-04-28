using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Util
{
    public static class DBPropertyUtil
    {
        public static string GetConnectionString(string filePath)
        {
            // Searching current working directory
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(filePath);

            //building the builder var --> Loading
            var congig = builder.Build();

            //getting the connection string from the json file

            var connectionString = congig.GetConnectionString("DefaultConnection");
            return connectionString;
        }
    }
}
