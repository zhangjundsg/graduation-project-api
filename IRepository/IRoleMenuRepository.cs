using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IRepository
{
    public interface IRoleMenuRepository:IBaseRepository<Sys_RoleMenu>
    {
        Task<bool> UpdateMenu(int RoleID, List<int> MenuID);
    }
}
