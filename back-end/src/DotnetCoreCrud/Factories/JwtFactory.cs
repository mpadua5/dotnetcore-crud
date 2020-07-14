using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotnetCoreCrud.Configurations;
using Microsoft.IdentityModel.Tokens;

namespace DotnetCoreCrud.Factories
{
    public class JwtFactory
    {
        public string JwtPass { get; set; }

        public JwtFactory()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtConfiguration.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            JwtPass = tokenHandler.WriteToken(token);
        }
    }
}
