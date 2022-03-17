using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.IService;
using Sys.Model;
using Sys.Model.DBModels;
using System.Threading.Tasks;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserInfoController : Controller
    {
        private readonly IUserInformationService _user;
        public UserInfoController(IUserInformationService user) 
        {
            _user = user;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetUserInformation(int id)
        {
            var userinfo = await _user.GetUserInfo(id);
            Sys_User user = new Sys_User()
            { 
                UserID = userinfo.UserID, 
                RoleID = userinfo.RoleID,
                Name = userinfo.Name, 
                UserImg = userinfo.UserImg, 
                Email = userinfo.Email,
                RegisterTime = userinfo.RegisterTime, 
                DepartmentID = userinfo.DepartmentID 
            };
            return Json(user);
        }
        /// <summary>
        /// 获取用户、角色、部门信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetDetailUserInformation(int id)
        {
            var userinfo = await _user.GetDetailInfo(id);
            return Json(userinfo);
        }       
        /// <summary>
        /// 注销登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult LoginOut()
        {
            return Json(new { code = ResponseCode.Success, msg = "注销成功！" });
        }
    }
}
