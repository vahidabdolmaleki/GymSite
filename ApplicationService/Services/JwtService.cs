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
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // اگر شخص نقش دارد، اسم نقش را استخراج کن
            var roleNames = person.PersonRoles?.Select(r => r.Role?.RoleName).Where(r => r != null).ToList() ?? new List<string>();

            var claims = new List<Claim>
            {
                    new Claim(JwtRegisteredClaimNames.Sub, person.Id.ToString()),
                    new Claim("FullName", $"{person.FirstName} {person.LastName}"),
                    new Claim("Email", person.Email ?? ""),
                    new Claim("Phone", person.PhoneNumber ?? ""),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // اضافه کردن نقش‌ها
            foreach (var roleName in roleNames)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleName!));
            }

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
