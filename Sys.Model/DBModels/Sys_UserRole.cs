using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sys.Model.DBModels
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("Sys_UserRole")]
    public partial class Sys_UserRole
    {
           public Sys_UserRole(){


           }
           /// <summary>
           /// Desc:用户
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int UserID {get;set;}

           /// <summary>
           /// Desc:角色
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int RoleID {get;set;}

    }
}
