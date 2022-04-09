using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sys.Model.DBModels;

namespace Sys.IService
{
    public interface IFiledOperateService
    {
        Task<bool> AddFiled(Sys_FiledList filed);
        Task<List<Sys_FiledList>> GetFiledById(int id);
    }
}
