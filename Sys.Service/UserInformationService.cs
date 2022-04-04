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
    }
}
