using Sys.Model;
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
        Task<List<Sys_User>> GetUserInfo(int userID);
        Task<UserInfoAllPage> GetAll(int pageIndex, int pageSize);
        Task<UserInfoAllPage> GetAll(int pageIndex, int pageSize,string name);
        Task<List<UserAllInfo>> GetAll();
    }
}
