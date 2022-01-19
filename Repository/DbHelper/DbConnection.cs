using Sys.Common;
using System.Data.SqlClient;
using System.Data;

namespace Sys.Repository.DbHelper
{
   
    public class DbConnection
    {
        private static readonly string sqlConnectionStr = AppConfigurtaion.GetSectionValue("SqlServer");
        private static IDbConnection _dbConnection;
        private static readonly object locker=new object();
        private DbConnection() { }
        public static IDbConnection SqlConnection()
        {
            if (_dbConnection == null)
            {
                lock (locker)
                {
                    if (_dbConnection == null)
                    {
                        _dbConnection = new SqlConnection(sqlConnectionStr);
                    }
                }
            }
            return _dbConnection;
        }
    }
}
