using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace Sys.IRepository
{
    public interface IBaseRepository<T>:ISimpleClient<T> where T : class, new() 
    {

    }
}
