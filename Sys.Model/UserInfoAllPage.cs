using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model
{
    public class UserInfoAllPage
    {
        /// <summary>
        /// 每页数据
        /// </summary>
        public List<UserAllInfo> list { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int PageCount { get; set; }
    }
}
