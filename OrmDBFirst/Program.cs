﻿using System;
using System.Linq;
using SqlSugar;
using Sys.Model.DBModels;

namespace OrmDBFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectionConfig connection = new ConnectionConfig
            {
                ConnectionString = @"Server=DESKTOP-11JFC0K;Database=System_DB;User ID=sa;Password=123456;Trusted_Connection=False;MultipleActiveResultSets=true;",
                DbType = DbType.SqlServer
            };
            using SqlSugarClient sqlSugar = new SqlSugarClient(connection);
            sqlSugar.DbFirst.IsCreateAttribute().Where(c => c.ToLower().StartsWith("sys")).CreateClassFile(@"E:\设计\Sys.Model\DBModels", "Sys.Model.DBModels");
        }
    }
}
