using Sys.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.IRepository
{
    public interface IMenu: IBaseRepository
    {
       IEnumerable<MenuInformation> MenuList();
    }
}
