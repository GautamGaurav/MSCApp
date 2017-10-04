using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MSCDAL
{
    class ConnectionDAL
    {
        static readonly ConnectionDAL _userDAL = new ConnectionDAL();

        private ConnectionDAL() { }

        public static ConnectionDAL GetInstance { get { return _userDAL; } }

        public static string GetConnectionString() {
            string connectionString = "";

            connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            return connectionString;
        }

    }
}
