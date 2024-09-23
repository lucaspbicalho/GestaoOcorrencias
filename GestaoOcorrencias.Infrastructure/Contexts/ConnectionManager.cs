using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Infrastructure.Contexts
{
    public class ConnectionManager
    {
        private static string _connectionString = "";

        public ConnectionManager(string connectionString)
        {
            _connectionString = connectionString;
        }
        public SqlConnection GetConnection()
        {
            SqlConnection conection = null;

            if (conection == null)
            {
                conection = new SqlConnection(_connectionString);
            }

            return conection;
        }
    }
}
