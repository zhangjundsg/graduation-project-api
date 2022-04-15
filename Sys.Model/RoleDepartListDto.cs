using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model
{
    public class RoleDepartListDto
    {
        public List<Sys_Role> RoleList { get; set; }
        public List<Sys_Department> DepartmentList { get; set; }
    }
}
