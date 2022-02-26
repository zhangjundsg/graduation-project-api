using System;
using System.Linq;
using SqlSugar;
using Sys.Model.DBModels;

namespace OrmDBFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectionConfig connection = new ConnectionConfig();
            connection.ConnectionString = @"Server=DESKTOP-11JFC0K;Database=System_DB;User ID=sa;Password=123456;Trusted_Connection=False;MultipleActiveResultSets=true;";
            connection.DbType = DbType.SqlServer;

            using (SqlSugarClient sqlSugar = new SqlSugarClient(connection))
            {
                sqlSugar.DbFirst.IsCreateAttribute().Where(c => c.ToLower().StartsWith("sys")).CreateClassFile(@"E:\设计\Sys.Model\DBModels", "Sys.Model.DBModels");
                //var a = sqlSugar.Queryable<Sys_User, Sys_UserRole, Sys_Role, Sys_RoleMenu, Sys_Menu>((u, ur, r, rm, m) =>
                //      u.UserID == ur.UserID && ur.RoleID == r.RoleID && r.RoleID == rm.RoleID && rm.MenuID == m.MenuID
                //).Select((u, ur, r, rm, m)=>new{ MenuID=m.MenuID,UserID=u.UserID }).Where(u=>u.UserID==1).ToList();
                //sqlSugar.Aop.OnLogExecuting = (sql, pars) =>
                //{
                //    Console.WriteLine(sql + "\r\n" + sqlSugar.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                //    Console.WriteLine();
                //};
                //a.ForEach((item) =>
                //{
                //    Console.WriteLine(item.MenuID+"======="+item.UserID);
                //});
            }
        }
    }
}
