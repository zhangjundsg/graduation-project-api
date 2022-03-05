using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.IService
{
    public interface IRoleInformationService
    {
        List<Sys_Role> GetRoleList();
        bool AddRoleInfo(Sys_Role role);
        bool DeleteRoleInfo(int roleID);
        bool UpdayeRoleInfo(Sys_Role role);
        bool DeleteRoleInfoList(int[] list);
    }
}
