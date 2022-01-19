using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IRepository
{
    public interface IBaseRepository
    {
        Task<T> Insert<T>(T model);
        Task<T> DeleteById<T>(int id);
        Task<T> Update<T>(T model);
        Task<T> QueryById<T>(int id);
        
    }
}
