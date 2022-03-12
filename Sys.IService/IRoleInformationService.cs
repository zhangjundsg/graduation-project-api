using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IService
{
    public interface IRoleInformationService
    {
        Task<List<Sys_Role>> GetRoleList();
        Task<bool> AddRoleInfo(Sys_Role role);
        Task<bool> DeleteRoleInfo(int roleID);
        Task<bool> UpdateRoleInfo(Sys_Role role);
        Task<bool> DeleteRoleInfoList(int[] list);
    }
}
