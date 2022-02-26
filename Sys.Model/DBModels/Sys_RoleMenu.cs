using SqlSugar;

namespace Sys.Model.DBModels
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("Sys_RoleMenu")]
    public partial class Sys_RoleMenu
    {
           public Sys_RoleMenu(){


           }
           /// <summary>
           /// Desc:角色ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int RoleID {get;set;}

           /// <summary>
           /// Desc:菜单ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int MenuID {get;set;}

    }
}
