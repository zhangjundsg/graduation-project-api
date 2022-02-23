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

namespace Sys.Repository
{
    public class Menu : BaseRepository,IMenu
    {
        public IEnumerable<MenuInformation> MenuList()
        {
            using (IDbConnection conn = DbConnection.SqlConnection())
            {
                try
                {
                    //                    string sql = @"select menu.* from UserInformation u
                    //inner join UserRole ur on u.ID=ur.UserID
                    //inner join RoleInformation r on ur.RoleID=r.RoleID
                    //inner join RoleMenu rm on r.RoleID=rm.RoleID
                    //inner join MenuInformation menu on rm.MenuID=menu.MenuID
                    //where u.ID=1";
                    string sql = "select * from MenuInformation";
                    return conn.Query<MenuInformation>(sql);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally 
                {
                    conn.Close();
                }
            }
        }

    }
}
