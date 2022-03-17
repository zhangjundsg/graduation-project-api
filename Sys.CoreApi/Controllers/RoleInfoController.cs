using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.IService;
using Sys.Model;
using Sys.Model.DBModels;
using System.Threading.Tasks;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 角色信息
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RoleInfoController : Controller
    {
        private readonly IRoleInformationService _roleInformationService;
        public RoleInfoController(IRoleInformationService roleInformationService) 
        {
            _roleInformationService = roleInformationService;
        }
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetRoleInformation()
        {
            var RoleList = await _roleInformationService.GetRoleList();
            return Json(RoleList);
        }
       /// <summary>
       /// 添加角色信息
       /// </summary>
       /// <param name="role">信息内容</param>
       /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> AddRoleInformation(Sys_Role role)
        {
            if (await _roleInformationService.AddRoleInfo(role))
            {
                return Json(new { Code = ResponseCode.Success, Msg = "添加成功" });
            }
            else
            {
                return Json(new { Code = ResponseCode.CodeError, Msg = "添加失败" });
            }
          
        }
        /// <summary>
        /// 删除单个角色
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<JsonResult> DelRoleInformation(int RoleID)
        {
            if (await _roleInformationService.DeleteRoleInfo(RoleID))
            {
                return Json(new { Code = ResponseCode.Success, Msg = "删除成功" });
            }
            else
            {
                return Json(new { Code = ResponseCode.CodeError, Msg = "删除失败，当前角色有关联数据！" });
            }

        }
        /// <summary>
        /// 删除多个角色
        /// </summary>
        /// <param name="list">角色ID数组</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> DelRoleInformationArry(int[] list)
        {

            if (await _roleInformationService.DeleteRoleInfoList(list))
            {
                return Json(new { Code = ResponseCode.Success, Msg = "删除成功" });
            }
            else
            {
                return Json(new { Code = ResponseCode.CodeError, Msg = "删除失败！" });
            }

        }
        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="role">角色信息</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<JsonResult> UpdateRoleInformation(Sys_Role role)
        {
            if (await _roleInformationService.UpdateRoleInfo(role))
            {
                return Json(new { Code = ResponseCode.Success, Msg = "更新成功" });
            }
            else
            {
                return Json(new { Code = ResponseCode.CodeError, Msg = "更新失败" });
            }

        }
    }
}
