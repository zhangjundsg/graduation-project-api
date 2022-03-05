using Sys.IRepository;
using Sys.Model.DBModels;
using Sys.Repository.DbHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Repository
{
    internal class RoleRepository : BaseRepository<Sys_Role>, IRoleRepository
    {
      
        public List<Sys_Role> GetAll()
        {
            using var db = DbConnection.Instance;
            return db.Queryable<Sys_Role>().ToList();
        }
        public bool DeleteRoleById(int roleID)
        {
            using var db = DbConnection.Instance;
            return db.Deleteable<Sys_Role>().In(roleID).ExecuteCommand() > 0;
        }

        public bool DeleteRoleListById(int[] list)
        {
            using var db = DbConnection.Instance;
            return db.Deleteable<Sys_Role>().In(list).ExecuteCommand() > 0;
        }
    }
}
