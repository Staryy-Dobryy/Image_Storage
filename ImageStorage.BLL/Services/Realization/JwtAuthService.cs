using ImageStorage.BLL.Models;
using ImageStorage.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Services.Realization
{
    public class JwtAuthService : IJwtAuthService
    {
        private readonly IConfiguration _configuration;
        public JwtAuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(JwtUserModel source)
        {
            var secret = Encoding.UTF8.GetBytes(_configuration["Secret"]);

            var tokenHandler = new JwtSecurityTokenHandler();

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = "ImageStorage",
                Claims = new Dictionary<string, object>
                {
                    { "Id", source.Id },
                    { "Email", source.Email}
                },
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
