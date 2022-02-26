using Sys.IRepository;
using Sys.Model.DBModels;
using Sys.Repository.DbHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SqlSugar;

namespace Sys.Repository
{
    public class Menu : BaseRepository<Sys_Menu>, IMenu
    {
        public dynamic MenuInfo(int UserID)
        {
            using var db = DbConnection.Instance;
            var list = db.Queryable<Sys_User, Sys_UserRole, Sys_Role, Sys_RoleMenu, Sys_Menu>((User, UserRole, Role, RoleMenu, Menu)
                  => User.UserID == UserRole.UserID
                  && UserRole.RoleID == Role.RoleID
                  && Role.RoleID == RoleMenu.RoleID
                  && RoleMenu.MenuID == Menu.MenuID
                ).Where(User => User.UserID==UserID).ToList();
            return list;
        }
    }
}
