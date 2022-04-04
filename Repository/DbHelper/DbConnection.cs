using Sys.Common;
using SqlSugar;
using System.Linq;
using System;

namespace Sys.Repository.DbHelper
{
    public class DbConnection
    {
        public static SqlSugarClient Instance
        {
            get
            {
                var db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = AppConfigurtaion.GetConfigStr("SqlServer"),
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                });
                db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                    Console.WriteLine();
                };
                return db;
            }
        }
    }
}
