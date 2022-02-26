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
    public class UserLogin : BaseRepository<Sys_User>, IUserLogin
    {
        public List<Sys_User> IsSuccess(string UserName, string UserPwd)
        {
            using var db = DbConnection.Instance;
            return db.Queryable<Sys_User>().Where(i => i.UserName == UserName && i.UserPassword == UserPwd).ToList();
        }
    }
}
