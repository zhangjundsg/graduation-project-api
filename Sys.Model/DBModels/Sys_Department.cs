using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sys.Model.DBModels
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("Sys_Department")]
    public partial class Sys_Department
    {
           public Sys_Department(){


           }
           /// <summary>
           /// Desc:部门ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int DepartmentID {get;set;}

           /// <summary>
           /// Desc:部门名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DepartmentName {get;set;}

           /// <summary>
           /// Desc:部门电话
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DepartmentTel {get;set;}

           /// <summary>
           /// Desc:部门邮箱
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DepartmentEmail {get;set;}

           /// <summary>
           /// Desc:备注(部门)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Remarks {get;set;}

    }
}
