﻿using Sys.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.IService
{
    public interface IAuthenticateService
    {
        /// <summary>
        /// 认证授权
        /// </summary>
        /// <param name="request">用户信息</param>
        /// <param name="token">Token</param>
        /// <returns></returns>
        bool IsAuthenticated(LoginRequestDto request, out string token);
        /// <summary>
        /// 验证信息
        /// </summary>
        /// <param name="req">用户登录信息</param>
        /// <returns></returns>
        bool IsValid(LoginRequestDto req);
    }
}
