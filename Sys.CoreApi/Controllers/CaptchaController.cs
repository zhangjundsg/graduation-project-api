using Microsoft.AspNetCore.Mvc;
using Sys.IService;
using System.Threading.Tasks;

namespace Sys.CoreApi.Controllers
{
    /// <summary>
    /// 验证码
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CaptchaController : Controller
    {
        private readonly ICaptcha _ICaptcha;
        public CaptchaController(ICaptcha ICaptcha)
        {
            _ICaptcha = ICaptcha;
        }
        [HttpGet]
        public FileContentResult Captcha()
        {
            var code =  _ICaptcha.GenerateRandomCaptcha();

            var result = _ICaptcha.GenerateCaptchaImage(code);


            return File(result.CaptchaMemoryStream.ToArray(), "image/png");
        }
    }
}
