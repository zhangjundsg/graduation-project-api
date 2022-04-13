using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IService
{
    public interface IDepartmentService
    {
        Task<List<Sys_Department>> GetDepartmentList();
        Task<bool> InsertDepartObj(Sys_Department depart);
        Task<bool> UpdateDepartObj(Sys_Department depart);
        Task<bool> DeleteDepartObj(int id);
    }
}
