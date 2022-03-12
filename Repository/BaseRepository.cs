using SqlSugar;
using Sys.IRepository;
using Sys.Repository.DbHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Repository
{
    public class BaseRepository<T> : SimpleClient<T>, IBaseRepository<T> where T : class, new()
    {
        public BaseRepository(ISqlSugarClient context = null) : base(context)
        {
            base.Context = DbConnection.Instance;
        }
    }
}
