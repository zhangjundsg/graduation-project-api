using Microsoft.AspNetCore.Mvc;
using Sys.Model;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Hello World");
        }
        /// <summary>
        /// 测试参数注释
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Hello2(UserInfo userinfo)
        {
            return Ok(userinfo);
        }
    }
}
