using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sys.Model
{
    public class LoginRequestDto
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required]
        [JsonProperty("username")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        [Required]
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
