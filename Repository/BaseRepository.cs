using Dapper;
using Sys.IRepository;
using Sys.Repository.DbHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Repository
{
    public class BaseRepository : IBaseRepository
    {
        public Task<T> DeleteById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Insert<T>(T model)
        {
            throw new NotImplementedException();
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
