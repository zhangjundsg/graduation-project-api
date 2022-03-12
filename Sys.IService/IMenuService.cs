using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IService
{
    public interface IMenuService
    {
        Task<List<Sys_Menu>> MenuList(int id);
    }
}
