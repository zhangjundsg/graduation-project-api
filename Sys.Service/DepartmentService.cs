using Sys.IRepository;
using Sys.IService;
using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserRepository _userRepository;
        public DepartmentService(IDepartmentRepository departmentRepository, IUserRepository userRepository)
        {
            _departmentRepository = departmentRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Sys_Department>> GetDepartmentList()
        {
            var list = await _departmentRepository.GetListAsync();
            return list;
        }
        public async Task<bool> InsertDepartObj(Sys_Department depart)
        {
            return await _departmentRepository.InsertAsync(depart);
        }
        public async Task<bool> UpdateDepartObj(Sys_Department depart)
        {
            return await _departmentRepository.UpdateAsync(depart);
        }
        public async Task<bool> DeleteDepartObj(int id)
        {
            if (await _userRepository.AsQueryable().Where(i => i.DepartmentID == id).CountAsync() < 1)
            {
                return await _departmentRepository.DeleteByIdAsync(id);
            }
            else
            {
                return false;
            }
        }

    }
}
