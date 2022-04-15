using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IService
{
    public interface ISalaryService
    {
        Task<List<Sys_Salary>> GetSalaryDataList();
        Task<bool> UpdateSalary(Sys_Salary salary);
    }
}
