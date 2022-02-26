using SqlSugar;
using Sys.IRepository;
using Sys.Repository.DbHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        public bool Delete(T model)
        {
            using var db = DbConnection.Instance;
            return db.Deleteable<T>(model).ExecuteCommand() > 0;
        }

        public bool Insert(T model)
        {
            using var db = DbConnection.Instance;
            return db.Insertable<T>(model).ExecuteCommand() > 0;
        }

        public T Query(int id)
        {
            using var db = DbConnection.Instance;
            return db.Queryable<T>().InSingle(id);
        }

        public bool Update(T model)
        {
            using var db = DbConnection.Instance;
            return db.Updateable<T>(model).ExecuteCommand() > 0;
        }
    }
}
