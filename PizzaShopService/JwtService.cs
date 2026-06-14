using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PizzaShopCore.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopService
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration) 
        {
           _configuration = configuration;
        }

        public JwtToken GenerateToken(string userId )
        {
            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);//מפתח ואלגוריתם שיבדוק שלא שינו את ה-TOKEN שהחזירו לנו
                                                                               //אמירות וטענות על ה-TOKEN 
            var claims = new[]
                {
                //מייצג את המשתנה של המשתמש-userid מי המשתנה ש
                new Claim(ClaimTypes.NameIdentifier, userId),
            };

            // מייצג לי את הטוקן בעצמו ואני שולחת אליו ערכים שצריך שחשוב לדעת ביצירה של הטוקן

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiresMinuts"])

                ), signingCredentials: creds);
            return new JwtToken { StringToken = new JwtSecurityTokenHandler().WriteToken(token) };

        }
    }
}
