using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TechShopApp.Util
{
    public static class DBPropertyUtil
    {
        public static string GetConnectionString(string filePath)
        {
            // Create a ConfigurationBuilder instance and load the JSON file
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(filePath);
            var congig = builder.Build();
            var connectionString = congig.GetConnectionString("DefaultConnection");
            return connectionString;
        }
    }
}
