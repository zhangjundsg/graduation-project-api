using Sys.IService;
using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using Sys.IRepository;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class RoleInformationService : IRoleInformationService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        public RoleInformationService(IRoleRepository roleRepository,IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Sys_Role>> GetRoleList()
        {
            var list = await _roleRepository.GetListAsync();
            return list;
        }
        public async Task<bool> AddRoleInfo(Sys_Role role)
        {
            return await _roleRepository.InsertAsync(role);
        }

        public async Task<bool> DeleteRoleInfo(int roleID)
        {
            if (await _userRepository.AsQueryable().Where(i => i.RoleID == roleID).CountAsync() < 1)
            {
                return await _roleRepository.DeleteByIdAsync(roleID);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateRoleInfo(Sys_Role role)
        {
            return await _roleRepository.UpdateAsync(role);
        }

        public async Task<bool> DeleteRoleInfoList(int[] list)
        {
            return await _roleRepository.DeleteRoleListById(list);
        }
    }
}
