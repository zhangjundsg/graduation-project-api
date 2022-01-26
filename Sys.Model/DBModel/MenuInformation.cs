using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.DBModel
{
    /// <summary>
    /// MenuInformation表
    /// </summary>
    public class MenuInformation
    {
        public int MenuID { get; set; }
        public string MenuUrl { get; set; }
        public string MenuPath { get; set; }
        public string Component { get; set; }
        public string MenuName { get; set; }
        public string IconCls { get; set; }
        public int ParentID { get; set; }
        public int MenuEnabled { get; set; }
        public string Remarks { get; set; }
        List<MenuInformation> Children { get; set; }
    }
}
