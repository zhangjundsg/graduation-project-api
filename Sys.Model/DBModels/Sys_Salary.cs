using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.DBModels
{
    public class Sys_Salary
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }
        public string basicSalary { get; set; }
        public string bonus { get; set; }
        public string lunchSalary { get; set; }
        public string trafficSalary { get; set; }
        public string pensionBase { get; set; }
        public string pensionPer { get; set; }
        public DateTime createDate { get; set; }
        public string medicalBase { get; set; }
        public string medicalPer { get; set; }
        public string accumulationFundBase { get; set; }
        public string accumulationFundPer { get; set; }
        public string name { get; set; }
    }
}
