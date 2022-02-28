using Sys.IRepository;
using Sys.IService;
using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Service
{
    public class UserInformationService : IUserInformationService
    {
        private readonly IUserRepository _user;
        public UserInformationService(IUserRepository user)
        {
            _user = user;
        }
        public List<Sys_User> GetUserInfo(int id)
        {
            return _user.GetAll(id);
        }
    }
}
