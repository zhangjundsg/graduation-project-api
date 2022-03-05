using Sys.IService;
using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using Sys.IRepository;

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

        public List<Sys_Role> GetRoleList()
        {
            var list = _roleRepository.GetAll();
            return list;
        }
        public bool AddRoleInfo(Sys_Role role)
        {
            return _roleRepository.Insert(role);
        }

        public bool DeleteRoleInfo(int roleID)
        {
            if (_userRepository.RelevancyRoleCount(roleID) < 1)
            {
                return _roleRepository.DeleteRoleById(roleID);
            }
            else
            {
                return false;
            }
        }

        public bool UpdayeRoleInfo(Sys_Role role)
        {
            return _roleRepository.Update(role);
        }

        public bool DeleteRoleInfoList(int[] list)
        {
            return _roleRepository.DeleteRoleListById(list);
        }
    }
}
