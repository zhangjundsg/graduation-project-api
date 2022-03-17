using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Common
{
    public class Tree
    {
        public static List<Sys_Menu> GetMenuTree(List<Sys_Menu> list, int Pid)
        {
            List<Sys_Menu> MenuList = new List<Sys_Menu>();
            var menuValue = list.Where(i => i.ParentID == Pid).ToList();
            if (menuValue.Count > 0)
            {
                for (int i = 0; i < menuValue.Count; i++)
                {
                    Sys_Menu menu = new Sys_Menu();
                    menu.MenuID = menuValue[i].MenuID;
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
