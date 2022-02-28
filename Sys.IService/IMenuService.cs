using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.IService
{
    public interface IMenuService
    {
        List<Sys_Menu> MenuList(int id);
    }
}
