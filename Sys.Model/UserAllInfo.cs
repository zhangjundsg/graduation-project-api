using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model
{
    public class UserAllInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime? RegisterTime { get; set; }
        /// <summary>
        /// 联系邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartmentName { get; set; }

        

    }
}
