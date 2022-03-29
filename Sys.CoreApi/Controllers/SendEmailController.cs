using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.IService;
using Sys.Model;
using System.Threading.Tasks;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 邮件发送
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SendEmailController : Controller
    {
        private readonly ISendEmail _sendEmail;
        public SendEmailController(ISendEmail sendEmail)
        {
            _sendEmail = sendEmail;
        }
        [HttpPost]
        public async Task<JsonResult> Send(SendEmail sm)
        {
            var result = await _sendEmail.SendEmailAsync(sm);
            return Json(new { Code = ResponseCode.Success, Msg = result });
        }
    }
}
