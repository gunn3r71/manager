using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Manager.API.Security
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _configuration;

        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken()
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, _configuration["Jwt:Login"]),
                    new(ClaimTypes.Role, "User")
                }),
                Expires = DateTime.UtcNow.AddHours(double.Parse(_configuration["Jwt:Expires"])),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}
