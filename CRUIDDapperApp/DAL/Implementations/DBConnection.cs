using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace CRUIDDapperApp.DAL.Implementations
{
    public class DBConnection
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["postgres"].ConnectionString;
        public static NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
