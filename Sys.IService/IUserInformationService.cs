using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.IService
{
    public interface IUserInformationService
    {
        List<Sys_User> GetUserInfo(int id);
    }
}
