using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.IService;
using Sys.Model;

namespace Sys.CoreApi.Controllers
{
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
                return Ok(token);
            }
            return BadRequest("验证失败！");

        }
    }
}
