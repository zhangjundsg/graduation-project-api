using Sys.IRepository;
using Sys.Model.DBModel;
using Sys.Repository.DbHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace Sys.Repository
{
    public class Menu : IMenu
    {
        public Task<T> DeleteById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Insert<T>(T model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MenuInformation> MenuList()
        {
            using (IDbConnection conn = DbConnection.SqlConnection())
            {
                return conn.QueryAsync<MenuInformation>("getMenuList", commandType: CommandType.StoredProcedure).Result.ToList();
            }
        }

        public Task<T> QueryById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update<T>(T model)
        {
            throw new NotImplementedException();
        }
    }
}
