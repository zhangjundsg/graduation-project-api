using Sys.IRepository;
using Sys.Model.DBModel;
using Sys.Repository.DbHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using Sys.Common;

namespace Sys.Repository
{
    public class Menu : BaseRepository,IMenu
    {
        public IEnumerable<MenuInformation> MenuList()
        {
            using (IDbConnection conn = DbConnection.SqlConnection(AppConfigurtaion.GetSectionValue("SqlServer")))
            {
                return conn.Query<MenuInformation>("getMenuList", commandType: CommandType.StoredProcedure);
            }
        }

    }
}
