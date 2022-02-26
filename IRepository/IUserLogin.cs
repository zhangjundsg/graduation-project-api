using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IRepository
{
    public interface IUserLogin:IBaseRepository<Sys_User>
    {
        List<Sys_User> IsSuccess(string UserName,string UserPwd);
    }
}
