using Sys.IRepository;
using Sys.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Model.DBModel;

namespace Sys.Service
{
    public class MenuList : IMenuList
    {
        private readonly IMenu _iMenu;
        public MenuList(IMenu iMenu)
        {
            _iMenu = iMenu;
        }
        public List<MenuInformation> GetMenuList()
        {
            var List = _iMenu.MenuList().ToList();
            var MenuList= GetMenuTree(List, 0);
            return MenuList;
        }

        public List<MenuInformation> GetMenuTree(List<MenuInformation> list,int Pid)
        {
            List<MenuInformation> MenuList = new List<MenuInformation>();
            var menuValue = list.Where(i => i.ParentID == Pid).ToList();
            if (menuValue.Count > 0) 
            {
                for (int i = 0; i < menuValue.Count; i++)
                {
                    MenuInformation menu = new MenuInformation();
                    menu.ParentID = menuValue[i].ParentID;
                    menu.MenuUrl = menuValue[i].MenuUrl;
                    menu.MenuPath = menuValue[i].MenuPath;
                    menu.Component = menuValue[i].Component;
                    menu.MenuName = menuValue[i].MenuName;
                    menu.IconCls = menuValue[i].IconCls;
                    menu.MenuEnabled = menuValue[i].MenuEnabled;
                    menu.Remarks = menuValue[i].Remarks;
                    menu.Children = GetMenuTree(list, menuValue[i].MenuID);
                    MenuList.Add(menu);
                }
            }
            return MenuList;
        }
    }
}
