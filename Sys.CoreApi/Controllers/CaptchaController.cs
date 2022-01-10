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
        public async Task<FileContentResult> CaptchaAsync()
        {
            var code = await _ICaptcha.GenerateRandomCaptchaAsync();

            var result = await _ICaptcha.GenerateCaptchaImageAsync(code);

            return File(result.CaptchaMemoryStream.ToArray(), "image/png");
        }
    }
}
