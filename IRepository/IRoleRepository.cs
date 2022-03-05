using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.IRepository
{
    public interface IRoleRepository: IBaseRepository<Sys_Role>
    {
        List<Sys_Role> GetAll();

        bool DeleteRoleById(int roleID);

        bool DeleteRoleListById(int[] list);
    }
}
