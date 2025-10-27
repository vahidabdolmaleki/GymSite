using ApplicationService.Interfaces;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateTokenForPerson(Person person)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var cerds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,person.Id.ToString()),
                new Claim("FullName",$"{person.FirstName} {person.LastName}"),
                new Claim("Email",person.Email ?? ""),
                new Claim("Phone",person.PhoneNumber ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer : _config["Jwt:Issuer"],
                audience : _config["Jwt:Audience"],
                claims : claims,
                //Todo در اینجا و  برای آینده میتونیم یه موودیت تعریف و زمان اعتبار هر توکن رو بفهمم
                expires : DateTime.UtcNow.AddHours(3),
                signingCredentials : cerds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
