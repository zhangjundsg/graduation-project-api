using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sys.Repository.DbHelper;
using Dapper;
using Sys.IRepository;

namespace Sys.Repository
{
    public class UserLogin : BaseRepository, IUserLogin
    {

        public IEnumerable<T> IsAuthenticated<T>(string UserName, string Pwd)
        {
            var sql = @"select ID from UserInformation where UserName=@UserName and UserPassword=@Pwd";
            using (IDbConnection conn = DbConnection.SqlConnection())
            {
                try
                {
                    return conn.Query<T>(sql, new { UserName = UserName, Pwd = Pwd });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
