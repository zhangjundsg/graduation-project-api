using Sys.Common;
using Sys.IRepository;
using Sys.IService;
using Sys.Model;
using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class UserInformationService : IUserInformationService
    {
        private readonly IUserRepository _user;
        public UserInformationService(IUserRepository user)
        {
            _user = user;
        }

        public async Task<List<Sys_User>> GetDetailInfo(int id)
        {
            return await _user.GetUserInfo(id);  
        }
        public async Task<List<UserEmail>> GetUserEmialAll()
        {
            var list = await _user.GetListAsync();
            List<UserEmail> ue = new List<UserEmail>();
            list.ForEach(i =>
            {
                UserEmail userEmail = new UserEmail();
                userEmail.Name = i.Name;
                userEmail.Email = i.Email;
                ue.Add(userEmail);
            });
            return ue;
        }

        public async Task<Sys_User> GetUserInfo(int id)
        {
            return await _user.GetByIdAsync(id);
        }
        public async Task<UserInfoAllPage> GetAllInfo(int pageIndex, int pageSize)
        {
            var list = await _user.GetAll(pageIndex,pageSize);
            return list;
        }
        public async Task<UserInfoAllPage> GetAllInfo(int pageIndex, int pageSize, string where)
        {
            var list= await _user.GetAll(pageIndex, pageSize, where);
            return list;
        }
        public async Task<bool> AddUser(Sys_User user)
        {
            user.UserPassword = Md5Encrypt.Md5Enc(user.UserPassword);
            return await _user.InsertAsync(user);
        }
        public async Task<bool> DelUser(int id)
        {
            return await _user.DeleteAsync(i => i.UserID == id);
        }
        public async Task<bool> UpdateUser(Sys_User user)
        {
            return await _user.UpdateAsync(user);
        }
        public async Task<bool> DelUserList(dynamic[] list)
        {
            return await _user.DeleteByIdsAsync(list);
        }
        public async Task<bool> UpdateUserPassword(Sys_User user)
        {
            user.UserPassword = Md5Encrypt.Md5Enc(user.UserPassword);
            return await _user.AsUpdateable(user).UpdateColumns(i => new { i.UserPassword }).Where(o => o.UserID == user.UserID).ExecuteCommandAsync() > 0;
        }
        public async Task<bool> UpdateUserRole(Sys_User user)
        {
            return await _user.AsUpdateable(user).UpdateColumns(i => new { i.RoleID }).Where(o => o.UserID == user.UserID).ExecuteCommandAsync() > 0;
        }
        public async Task<bool> UpdateUserDepart(Sys_User user)
        {
            return await _user.AsUpdateable(user).UpdateColumns(i => new { i.DepartmentID }).Where(o => o.UserID == user.UserID).ExecuteCommandAsync() > 0;
        }
        public async Task<List<DepartUserDto>> GetOtherUser(int id)
        {
            var list = await _user.GetAllOtherUser(id);
            return list;
        }
        public async Task<RoleDepartListDto> GetRoleDepratList()
        {
            var list = await _user.GetRoleDepratList();
            return list;
        }
    }
}
