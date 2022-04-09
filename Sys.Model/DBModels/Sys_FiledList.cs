using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.DBModels
{
    public class Sys_FiledList
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int FiledID { get; set; }
        /// <summary>
        /// 申请类型 1.转岗 2.请假 3.离职
        /// </summary>
        public int? FiledType { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? FiledTime { get; set; }
        /// <summary>
        /// 申请状态 0:审核中 1.通过 2.拒绝
        /// </summary>
        public int FiledStatus { get; set; } = 0;
        /// <summary>
        /// 申请人id
        /// </summary>
        public int FiledUserID { get; set; }

        /// <summary>
        /// 要转入的职位
        /// </summary>
        public int? FiledToRoleID { get; set; }
        public string FiledTypeName { get; set; }
        public string FiledText { get; set; }
    }
}
