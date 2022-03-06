using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IRepository
{
    public interface IUserRepository:IBaseRepository<Sys_User>
    {
        List<Sys_User> IsSuccess(string UserName,string UserPwd);
        List<Sys_User> GetAll(int id);
        int RelevancyRoleCount(int roleID);
        List<Sys_User> GetUserInfo(int userID);
    }
}
