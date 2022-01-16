using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sys.IRepository
{
    public interface IBaseRepository
    {
        void QueryById(int id);
    }
}
