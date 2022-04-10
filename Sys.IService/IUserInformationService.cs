using Sys.Model;
using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IService
{
    public interface IUserInformationService
    {
        Task<Sys_User> GetUserInfo(int id);
        Task<List<Sys_User>> GetDetailInfo(int id);
        Task<List<UserEmail>> GetUserEmialAll();
        Task<UserInfoAllPage> GetAllInfo(int pageIndex, int pageSize);
        Task<UserInfoAllPage> GetAllInfo(int pageIndex, int pageSize,string where);
        Task<bool> AddUser(Sys_User user);
        Task<bool> DelUser(int id);
        Task<bool> DelUserList(dynamic[] list);
        Task<bool> UpdateUser(Sys_User user);

        Task<bool> UpdateUserRole(Sys_User user);
    }
}
