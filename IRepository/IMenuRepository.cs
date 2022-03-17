using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IRepository
{
    public interface IMenuRepository: IBaseRepository<Sys_Menu>
    {
        Task<List<Sys_Menu>> MenuInfo(int UserID);
        Task<List<Sys_Menu>> MenuInfoByRoleID(int RoleID);
       
    }
}
