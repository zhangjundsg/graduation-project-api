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
        public IEnumerable<MenuInformation> MenuList(int ID)
        {
            using (IDbConnection conn = DbConnection.SqlConnection(AppConfigurtaion.GetSectionValue("SqlServer")))
            {
                try
                {
                    string sql = @"select menu.* from UserInformation u
inner join UserRole ur on u.ID=ur.UserID
inner join RoleInformation r on ur.RoleID=r.RoleID
inner join RoleMenu rm on r.RoleID=rm.RoleID
inner join MenuInformation menu on rm.MenuID=menu.MenuID
where u.ID=@ID;";
                    return conn.Query<MenuInformation>(sql,ID);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

    }
}
