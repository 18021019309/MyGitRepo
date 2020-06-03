using FirstPakWebApi.IService;
using FirstPakWebApi.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FirstPakWebApi.Service
{
    public class JWTService: IJWTService
    {
       private readonly IUserService _userService;
       private readonly IConfiguration _configuration;
        public JWTService(IUserService userService, IConfiguration configuration)
        {
            this._userService = userService;
            this._configuration = configuration;
        }
        public string GetToken(ViewAuth viewAuth)
        {
            var auth = _userService.GetUser(viewAuth);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["SecurityKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, auth.Id.ToString()),
                    //new Claim(ClaimTypes.Role, user.UserRoles)
                }),
                Expires = DateTime.UtcNow.AddDays(7),//有效时间
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
