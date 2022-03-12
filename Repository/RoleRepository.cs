using Sys.IRepository;
using Sys.Model.DBModels;
using Sys.Repository.DbHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Repository
{
    internal class RoleRepository : BaseRepository<Sys_Role>, IRoleRepository
    {
      
        public async Task<bool> DeleteRoleListById(int[] list)
        {
            return await base.Context.Deleteable<Sys_Role>().In(list).ExecuteCommandAsync() > 0;
        }
    }
}
