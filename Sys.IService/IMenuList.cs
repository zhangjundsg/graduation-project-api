using Sys.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.IService
{
    public interface IMenuList
    {
        List<MenuInformation> GetMenuList();
        List<MenuInformation> GetMenuTree(List<MenuInformation> list, int Pid);
    }
}
