using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IRepository
{
    public interface IRoleRepository: IBaseRepository<Sys_Role>
    {
        Task<bool> DeleteRoleListById(int[] list);
    }
}
