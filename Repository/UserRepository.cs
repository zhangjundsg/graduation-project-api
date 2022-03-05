using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sys.Repository.DbHelper;
using Sys.IRepository;
using SqlSugar;
using Sys.Model.DBModels;

namespace Sys.Repository
{
    public class UserRepository : BaseRepository<Sys_User>, IUserRepository
    {
        public List<Sys_User> GetAll(int id)
        {
            using var db = DbConnection.Instance;
            return db.Queryable<Sys_User>().Where(i => i.UserID == id).ToList();
        }

        public List<Sys_User> IsSuccess(string UserName, string UserPwd)
        {
            using var db = DbConnection.Instance;
            return db.Queryable<Sys_User>().Where(i => i.UserName == UserName && i.UserPassword == UserPwd).ToList();
        }

        public int RelevancyRoleCount(int roleID)
        {
            using var db = DbConnection.Instance;
            return db.Queryable<Sys_User>().Where(i => i.RoleID == roleID).Count();
        }
    }
}
