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
        /// 根据ID获取用户、角色、部门信息
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
            return Json(new ResponseDto() { Code = (int)ResponseCode.Success, Msg = "注销成功！" });
        }
        /// <summary>
        /// 获取全部用户邮箱
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetUserEmailAll()
        {
            var userList = await _user.GetUserEmialAll();
            return Json(userList);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数据</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetAllUserInformation(int pageIndex,int pageSize)
        {
            var list = await _user.GetAllInfo(pageIndex,pageSize);
            return Json(list);
        }
        /// <summary>
        /// 按条件分页查询
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数据</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetAllUserInformationWhere(int pageIndex, int pageSize,string where)
        {
            var list = await _user.GetAllInfo(pageIndex, pageSize,where);
            return Json(list);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<JsonResult> AddUserInformation(Sys_User user)
        {
            if (await _user.AddUser(user))
            {
                return Json(new ResponseDto() { Code = (int)ResponseCode.Success, Msg = "添加成功！" });
            }
            return Json(new ResponseDto() { Code = (int)ResponseCode.CodeError, Msg = "添加失败！" });
        }
        /// <summary>
        /// 根据ID删除用户
        /// </summary>
        /// <param name="UserID">用户id</param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize]
        public async Task<JsonResult> DelUser(int UserID)
        {
            if (await _user.DelUser(UserID))
            {
                return Json(new ResponseDto() { Code = (int)ResponseCode.Success, Msg = "删除成功！" });
            }
            return Json(new ResponseDto() { Code = (int)ResponseCode.CodeError, Msg = "删除失败！" });
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list">id列表</param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize]
        public async Task<JsonResult> DelUserList(dynamic[] list)
        {
            if (await _user.DelUserList(list))
            {
                return Json(new ResponseDto() { Code = (int)ResponseCode.Success, Msg = "删除成功！" });
            }
            return Json(new ResponseDto() { Code = (int)ResponseCode.CodeError, Msg = "删除失败！" });
        }
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public async Task<JsonResult> UpdateUser(Sys_User user)
        {
            if (await _user.UpdateUser(user))
            {
                return Json(new ResponseDto() { Code = (int)ResponseCode.Success, Msg = "更新成功！" });
            }
            return Json(new ResponseDto() { Code = (int)ResponseCode.CodeError, Msg = "更新失败！" });
        }
        /// <summary>
        /// 更新用户角色
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public async Task<bool> UpdateUserRole(Sys_User user)
        {
            return await _user.UpdateUserRole(user);
        }
    }
}
