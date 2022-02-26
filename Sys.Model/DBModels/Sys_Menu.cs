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
    [SugarTable("Sys_Menu")]
    public partial class Sys_Menu
    {
           public Sys_Menu(){


           }
           /// <summary>
           /// Desc:菜单ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int MenuID {get;set;}

           /// <summary>
           /// Desc:菜单url
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MenuUrl {get;set;}

           /// <summary>
           /// Desc:菜单路径
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MenuPath {get;set;}

           /// <summary>
           /// Desc:组件
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Component {get;set;}

           /// <summary>
           /// Desc:菜单名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MenuName {get;set;}

           /// <summary>
           /// Desc:菜单图标
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IconCls {get;set;}

           /// <summary>
           /// Desc:父级菜单ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ParentID {get;set;}

           /// <summary>
           /// Desc:是否启用
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MenuEnabled {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Remarks {get;set;}


        [SugarColumn(IsIgnore = true)]
        public List<Sys_Menu> Children { get; set; }


    }
}
