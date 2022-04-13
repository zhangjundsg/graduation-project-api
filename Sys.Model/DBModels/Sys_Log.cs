using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.DBModels
{
    public class Sys_Log
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int LogID { get; set; }
        public string LogType { get; set; }
        public string LogContext { get; set; }
        public DateTime? LogDateTime { get; set; }
        public string Application { get; set; }
        public string Operatingaddress { get; set; }
        public string Action { get; set; }
        public string Exception { get; set; }
    }
}
