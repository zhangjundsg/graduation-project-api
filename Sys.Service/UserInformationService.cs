using Sys.IRepository;
using Sys.IService;
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

        public async Task<Sys_User> GetUserInfo(int id)
        {
            return await _user.GetByIdAsync(id);
        }
    }
}
