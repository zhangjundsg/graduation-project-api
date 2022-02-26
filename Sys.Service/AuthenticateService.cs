using Microsoft.Extensions.Options;
using Sys.IService;
using Sys.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Sys.IRepository;
using Sys.Model.DBModels;
using Sys.Common;

namespace Sys.Service
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly TokenManagement _tokenManagement;
        private readonly IUserLogin _userLogin;
        public AuthenticateService(IOptions<TokenManagement> tokenManagement, IUserLogin userLogin)
        {
            _tokenManagement = tokenManagement.Value;
            _userLogin = userLogin;
        }
        public bool IsAuthenticated(LoginRequestDto request, out string token)
        {
            if (!IsValid(request))
            {
                token = "";
                return false;
            }
            var claims = new[]
                 {
                     new Claim(ClaimTypes.Name,request.UserName)
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claims,
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return true;
        }

     

        public bool IsValid(LoginRequestDto req)
        {
            var userInfo = _userLogin.IsSuccess(req.UserName, Md5Encrypt.Md5Enc(req.Password));
            if (userInfo.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
