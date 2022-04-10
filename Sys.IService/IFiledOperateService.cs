using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sys.Model;
using Sys.Model.DBModels;

namespace Sys.IService
{
    public interface IFiledOperateService
    {
        Task<bool> AddFiled(Sys_FiledList filed);
        Task<bool> UpdataFiled(Sys_FiledList filed);
        Task<List<Sys_FiledList>> GetFiledById(int id);
        Task<FiledList> GetAllFiled(int pageIndex, int pageSize);
        Task<FiledStats> Getstats();
    }
}
