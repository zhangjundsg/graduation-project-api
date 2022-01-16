using Sys.Common;
using System.Data.SqlClient;

namespace Sys.Repository.DbHelper
{
    public class DbConnection
    {
        static string sqlconnectionString = AppConfigurtaion.GetSectionValue("SqlServer");
        public static SqlConnection SqlConnection()
        {
            var connection = new SqlConnection(sqlconnectionString);
            connection.Open();
            return connection;
        }
    }
}
