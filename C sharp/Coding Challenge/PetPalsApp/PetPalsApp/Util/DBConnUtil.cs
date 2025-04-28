using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.Util
{
    public static class DBConnUtil
    {
        public static SqlConnection GetConnection(string configfile)
        {
            SqlConnection sqlConnection;
            string connstr = DBPropertyUtil.GetConnectionString(configfile);
            return new SqlConnection(connstr);
        }
    }
}
