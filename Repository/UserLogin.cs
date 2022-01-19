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
    public class UserLogin:BaseRepository,IUserLogin
    {
        public async Task<T> QueryUser<T>(T model)
        {
            string sql = "select ID from UserInformation where UserName=@UserName and UserPassword=@Password";
            using (IDbConnection conn= DbConnection.SqlConnection())
            {
                return await conn.QuerySingleAsync<T>(sql, model).ConfigureAwait(false);
            }
        }
    }
}
