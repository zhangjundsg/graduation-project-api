using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.IService;
using Sys.Model;
using System.Collections.Generic;
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
        private readonly ISendEmailService _sendEmail;
        public SendEmailController(ISendEmailService sendEmail)
        {
            _sendEmail = sendEmail;
        }
        [HttpPost]
        public async Task<JsonResult> Send(SendEmail sm)
        {
            var result = await _sendEmail.SendEmailAsync(sm);
            return Json(result);
        }
    }
}
