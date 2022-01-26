using Sys.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IRepository
{
    public interface IMenu:IBaseRepository
    {
       IEnumerable<MenuInformation> MenuList();
    }
}
