using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sys.IService;
using Sys.Model;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 登录认证
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        public AuthenticationController(IAuthenticateService authenticateService) 
        {
            _authenticateService=authenticateService; 
        }
        [AllowAnonymous]
        [HttpPost,Route("requestToken")]
        public IActionResult RequestToken([FromBody] LoginRequestDto req) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("用户数据验证失败！");
            }
            if (_authenticateService.IsAuthenticated(req, out string token,out int UserID))
            {
                return Ok(new TokenResponse()
                {
                    Code = (int)ResponseCode.Success,
                    TokenHeader = "Bearer",
                    Msg = "登陆成功",
                    UserID = UserID,
                    Token = token
                });
            }
            else
            {
                return Ok(new TokenResponse()
                {
                    Code = (int)ResponseCode.ValidationError,
                    TokenHeader = "",
                    Msg = "账号验证失败",
                    UserID = UserID,
                    Token = token
                });
            }

        }
    }
}
