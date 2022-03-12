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
    }
}
