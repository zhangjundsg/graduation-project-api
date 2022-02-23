using System.Data.SqlClient;
using System.Data;
using Sys.Common;

namespace Sys.Repository.DbHelper
{

    public class DbConnection
    {
        private static IDbConnection _dbConnection;
        static string sqlconnectionString = AppConfigurtaion.GetSectionValue("SqlServer");
        private DbConnection() { }
        public static IDbConnection SqlConnection()
        {
            _dbConnection = new SqlConnection(sqlconnectionString);
            _dbConnection.Open();
            return _dbConnection;
        }
    }
}
