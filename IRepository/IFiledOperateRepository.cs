using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sys.Model;
using Sys.Model.DBModels;

namespace Sys.IRepository
{
    public interface IFiledOperateRepository:IBaseRepository<Sys_FiledList>
    {
        Task<FiledList> GetFileds(int pageIndex, int pageSize);
        Task<FiledStats> Getstats();
    }
}
