using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.IService
{
    public interface IMenuList
    {
        List<Sys_Menu> MenuList(int id);
    }
}
