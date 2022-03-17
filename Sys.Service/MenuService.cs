using Sys.IRepository;
using Sys.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Model.DBModels;
using Sys.Common;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _iMenu;
        private readonly IRoleMenuRepository _iroleMenu;
        public MenuService(IMenuRepository iMenu,IRoleMenuRepository iroleMenu)
        {
            _iMenu = iMenu;
            _iroleMenu = iroleMenu;
        }

        public async Task<List<Sys_Menu>> AllMenuList()
        {
            var list= await _iMenu.GetListAsync();
            var menu = Tree.GetMenuTree(list, 0);
            return menu;
        }

        public async Task<List<Sys_Menu>> MenuListByID(int id)
        {
            var list = await _iMenu.MenuInfo(id);
            var menu = Tree.GetMenuTree(list, 0);
            return menu;
        }

        public async Task<List<int>> MenuArrayByRoleID(int roleID)
        {
            var list = await _iMenu.MenuInfoByRoleID(roleID);
            List<int> menuArray = new List<int>();
            list.ForEach(item => menuArray.Add(item.MenuID));
            return menuArray;
        }

        public async Task<bool> UpdateMenu(int roleID, List<int> MenuID)
        {
            return await _iroleMenu.UpdateMenu(roleID, MenuID);
        }
    }
}
