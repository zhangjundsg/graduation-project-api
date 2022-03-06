using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sys.Model.DBModels
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("Sys_User")]
    public partial class Sys_User
    {
           public Sys_User(){


           }
           /// <summary>
           /// Desc:用户ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int UserID {get;set;}

           /// <summary>
           /// Desc:账号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserName {get;set;}

           /// <summary>
           /// Desc:用户密码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserPassword {get;set;}

           /// <summary>
           /// Desc:名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Name {get;set;}

           /// <summary>
           /// Desc:用户头像
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string UserImg {get;set;}

           /// <summary>
           /// Desc:用户邮箱
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Email {get;set;}

           /// <summary>
           /// Desc:注册时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RegisterTime {get;set;}

           /// <summary>
           /// Desc:角色ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int RoleID {get;set;}

           /// <summary>
           /// Desc:部门ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int DepartmentID {get;set;}

        [SugarColumn(IsIgnore = true)]
        public Sys_Role Role { get; set; }

        [SugarColumn(IsIgnore = true)]
        public Sys_Department Department { get; set; }

    }
}
