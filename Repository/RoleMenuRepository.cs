using Sys.IRepository;
using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Repository
{
    public class RoleMenuRepository:BaseRepository<Sys_RoleMenu>, IRoleMenuRepository
    {
        public async Task<bool> UpdateMenu(int RoleID, List<int> MenuID)
        {
            await base.DeleteAsync(i => i.RoleID == RoleID);
            List<Sys_RoleMenu> rm = new List<Sys_RoleMenu>();
            MenuID.ForEach(i => {
                rm.Add(new Sys_RoleMenu { RoleID = RoleID, MenuID = i });
            });
            return await base.Context.Insertable(rm).ExecuteCommandAsync() > 0;
        }
    }
}
