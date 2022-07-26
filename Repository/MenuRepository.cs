﻿using Sys.IRepository;
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
    public class MenuRepository : BaseRepository<Sys_Menu>, IMenuRepository
    {
       

        public async Task<List<Sys_Menu>> MenuInfo(int UserID)
        {
            var list = await base.Context.Queryable<Sys_User, Sys_Role, Sys_RoleMenu, Sys_Menu>((u, r, rm, m)
                  => u.RoleID == r.RoleID
                  && r.RoleID == rm.RoleID
                  && rm.MenuID == m.MenuID)
                .Where(u => u.UserID == UserID)
                .Select((u, r, rm, m) => new Sys_Menu
                {
                    MenuID = m.MenuID,
                    MenuPath = m.MenuPath,
                    Component = m.Component,
                    MenuName = m.MenuName,
                    IconCls = m.IconCls,
                    ParentID = m.ParentID,
                    MenuEnabled = m.MenuEnabled,
                    Remarks = m.Remarks
                }).ToListAsync();
            return list;
        }
        public async Task<List<Sys_Menu>> MenuInfoByRoleID(int RoleID)
        {
            var list = await base.Context.Queryable<Sys_Role, Sys_RoleMenu, Sys_Menu>((r, rm, m)
                 => new JoinQueryInfos(
                     JoinType.Left, r.RoleID == rm.RoleID,
                     JoinType.Left, rm.MenuID == m.MenuID
                     )
           ).Where(r => r.RoleID == RoleID)
           .Where((r, rm, m) => m.MenuID > 1000)
           .Select((r, rm, m) => new Sys_Menu
           {
               MenuID = m.MenuID
           }).ToListAsync();

            return list;
        }

    }
}
