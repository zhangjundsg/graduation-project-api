using Sys.IRepository;
using Sys.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Model.DBModels;
using Sys.Common;

namespace Sys.Service
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _iMenu;
        public MenuService(IMenuRepository iMenu)
        {
            _iMenu = iMenu;
        }
        List<Sys_Menu> IMenuService.MenuList(int id)
        {
            var list = _iMenu.MenuInfo(id);
            var menu = Tree.GetMenuTree(list, 0);
            return menu;
        }

    }
}
