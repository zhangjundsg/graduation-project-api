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
using Sys.Model.DBModel;

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
            token = string.Empty;
            if (!IsValid(request))
                return false;
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
            return true;

        }
    }
}
