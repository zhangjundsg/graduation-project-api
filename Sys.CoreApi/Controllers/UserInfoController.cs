﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.IService;
using Sys.Model;
using Sys.Model.DBModels;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
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
        public JsonResult GetUserInformation(int id)
        {
            var userinfo = _user.GetUserInfo(id);
            Sys_User user = new Sys_User();
            foreach (var item in userinfo)
            {
                user.UserID = item.UserID;
                user.UserName = item.UserName;
                user.Email= item.Email;
                user.UserImg = item.UserImg;
                user.Email=item.Email;
                user.Name= item.Name;
            }
            return Json(user);
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
