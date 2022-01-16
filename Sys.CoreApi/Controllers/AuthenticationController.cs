using Microsoft.AspNetCore.Authorization;
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
            if (_authenticateService.IsAuthenticated(req, out string token))
            {
                TokenResponse obj = new TokenResponse()
                {
                    Code = (int)ResponseCode.Success,
                    TokenHeader = "Bearer",
                    Msg = "登录成功",
                    Token = token
                };
                return Ok(obj) ;
            }
            return BadRequest("验证失败！");

        }
    }
}
