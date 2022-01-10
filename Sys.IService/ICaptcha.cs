using Sys.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IService
{
    public interface ICaptcha
    {
        /// <summary>
        /// 生成随机验证码
        /// </summary>
        /// <param name="codeLength">验证码长度</param>
        /// <returns></returns>
        Task<string> GenerateRandomCaptchaAsync(int codeLength = 5);

        /// <summary>
        /// 生成验证码图片
        /// </summary>
        /// <param name="captchaCode">验证码</param>
        /// <param name="width">宽为0将根据验证码长度自动匹配合适宽度</param>
        /// <param name="height">高</param>
        /// <returns></returns>
        Task<CaptchaResult> GenerateCaptchaImageAsync(string captchaCode, int width = 0, int height = 30);
    }
}
