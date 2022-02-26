using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sys.Model.DBModels
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("Sys_Role")]
    public partial class Sys_Role
    {
           public Sys_Role(){


           }
           /// <summary>
           /// Desc:角色ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int RoleID {get;set;}

           /// <summary>
           /// Desc:角色名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string RoleName {get;set;}

           /// <summary>
           /// Desc:备注(角色)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Remarks {get;set;}

    }
}
