using Sys.Common;
using System.Data.SqlClient;
using System.Data;

namespace Sys.Repository.DbHelper
{
   
    public class DbConnection
    {
        private static IDbConnection _dbConnection;
        private static readonly object locker=new object();
        private DbConnection() { }
        public static IDbConnection SqlConnection(string ConnectionStr)
        {
            if (_dbConnection == null)
            {
                lock (locker)
                {
                    if (_dbConnection == null)
                    {
                        _dbConnection = new SqlConnection(ConnectionStr);
                    }
                }
            }
            return _dbConnection;
        }
    }
}
