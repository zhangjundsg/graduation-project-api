using Sys.IRepository;
using Sys.IService;
using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class SalaryService: ISalaryService
    {
        private readonly ISalaryRepository _salary;
        public SalaryService(ISalaryRepository salary)
        {
            _salary= salary;
        }
        public async Task<List<Sys_Salary>> GetSalaryDataList()
        {
            return await _salary.GetListAsync();
        }
        public async Task<bool> UpdateSalary(Sys_Salary salary)
        {
            return await _salary.UpdateAsync(salary);
        }
    }
}
