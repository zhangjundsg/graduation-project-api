using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IService
{
    public interface IMenuService
    {
        Task<List<Sys_Menu>> MenuListByID(int id);
        Task<List<Sys_Menu>> AllMenuList();
        Task<List<int>> MenuArrayByRoleID(int roleID);

        Task<bool> UpdateMenu(int roleID, List<int> MenuID);
    }
}
