using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IRepository
{
    public interface IBaseRepository<T> where T : class, new()
    {
        bool Insert(T model);
        bool Delete(T model);
        bool Update(T model);
        T Query(int id);
    }
}
