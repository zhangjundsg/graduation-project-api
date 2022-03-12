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
        public MenuService(IMenuRepository iMenu)
        {
            _iMenu = iMenu;
        }
        public async Task<List<Sys_Menu>> MenuList(int id)
        {
            var list = await _iMenu.MenuInfo(id);
            var menu = Tree.GetMenuTree(list, 0);
            return menu;
        }

    }
}
