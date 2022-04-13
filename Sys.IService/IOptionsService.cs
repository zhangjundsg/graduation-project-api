using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IService
{
    public interface IOptionsService
    {
        Task<List<Sys_Options>> GetAllOptions();
        Task<bool> UpdateOptions(Sys_Options options);
    }
}
