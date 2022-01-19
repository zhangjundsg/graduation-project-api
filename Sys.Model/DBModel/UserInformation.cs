using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sys.Model.DBModel
{
    /// <summary>
    /// UserInformation表
    /// </summary>
    public class UserInformation
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public DateTime RegisterTime { get; set; }
        public string Remarks { get; set; }
        public string Email { get; set; }
        public int DepartmentID { get; set; }
    }
}
