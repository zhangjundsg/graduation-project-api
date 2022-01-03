using System;
using System.Collections.Generic;
using System.Text;
using Sys.IService;

namespace Sys.Service
{
    public class UserInfoService : IUserInfoService
    {
        public string GetUserName()
        {
            return "哈哈";
        }
    }
}
