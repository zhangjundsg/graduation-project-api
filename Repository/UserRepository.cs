using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sys.Repository.DbHelper;
using Sys.IRepository;
using SqlSugar;
using Sys.Model.DBModels;
using Sys.Model;

namespace Sys.Repository
{
    public class UserRepository : BaseRepository<Sys_User>, IUserRepository
    {

        public async Task<List<Sys_User>> GetUserInfo(int userID)
        {
            var list = await base.Context.Queryable<Sys_User, Sys_Role, Sys_Department>((u, r, d)
                  => new JoinQueryInfos(
                      JoinType.Left, u.RoleID == r.RoleID,
                      JoinType.Left, u.DepartmentID == d.DepartmentID
                      )
            ).Where(u => u.UserID == userID)
            .Select((u, r, d) => new Sys_User
            {
                Name = u.Name,
                Email = u.Email,
                RegisterTime = u.RegisterTime,
                UserImg = u.UserImg,
                Role = r,
                Department = d
            }).ToListAsync();
            return list;
        }

        public List<Sys_User> IsSuccess(string UserName, string UserPwd)
        {
            return base.Context.Queryable<Sys_User>().Where(i => i.UserName == UserName && i.UserPassword == UserPwd).ToList();
        }
        public async Task<UserInfoAllPage> GetAll(int pageIndex,int pageSize)
        {
            RefAsync<int> total = 0;
            var list = await base.Context.Queryable<Sys_User, Sys_Role, Sys_Department>((u, r, d)
                       => new JoinQueryInfos(
                           JoinType.Left, u.RoleID == r.RoleID,
                           JoinType.Left, u.DepartmentID == d.DepartmentID
                           )
                 ).Select((u, r, d) => new UserAllInfo
                 {
                     UserID = u.UserID,
                     Name = u.Name,
                     RegisterTime = u.RegisterTime,
                     RoleName = r.RoleName,
                     DepartmentName = d.DepartmentName,
                     Email = u.Email
                 }).ToPageListAsync(pageIndex, pageSize, total);
            return new UserInfoAllPage { list = list, PageCount = total };
        }
        public async Task<UserInfoAllPage> GetAll(int pageIndex, int pageSize,string name)
        {
            RefAsync<int> total = 0;
            var list = await base.Context.Queryable<Sys_User, Sys_Role, Sys_Department>((u, r, d)
                       => new JoinQueryInfos(
                           JoinType.Left, u.RoleID == r.RoleID,
                           JoinType.Left, u.DepartmentID == d.DepartmentID
                           )
                 ).Where(u => u.Name.Contains(name))
                .Select((u, r, d) => new UserAllInfo
                {
                    UserID = u.UserID,
                    Name = u.Name,
                    RegisterTime = u.RegisterTime,
                    RoleName = r.RoleName,
                    DepartmentName = d.DepartmentName,
                    Email = u.Email
                }).ToPageListAsync(pageIndex, pageSize, total);
            return new UserInfoAllPage { list = list, PageCount = total };
        }
        public async Task<List<UserAllInfo>> GetAll()
        {
            var list = await base.Context.Queryable<Sys_User, Sys_Role, Sys_Department>((u, r, d)
                       => new JoinQueryInfos(
                           JoinType.Left, u.RoleID == r.RoleID,
                           JoinType.Left, u.DepartmentID == d.DepartmentID
                           )
                 )
                .Select((u, r, d) => new UserAllInfo
                {
                    UserID = u.UserID,
                    Name = u.Name,
                    RegisterTime = u.RegisterTime,
                    RoleName = r.RoleName,
                    DepartmentName = d.DepartmentName,
                    Email = u.Email
                }).ToListAsync();
            return list;
        }
    }
}
