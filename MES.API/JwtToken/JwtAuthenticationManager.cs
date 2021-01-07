using MES.API.ViewModels;
using MES.DB.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MES.API.JwtToken
{
    public class JwtAuthenticationManager:IJwtAuthenticationManager
    {
        
        private readonly string key;

        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }


        public string Authenticate(UserViewModel userViewModel)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.SerialNumber,userViewModel.user.USER_ID.ToString()),
                //    new Claim(ClaimTypes.NameIdentifier, users.USERNAME),
                //    new Claim(ClaimTypes.Name, users.NAME +" "+ users.SURNAME),
                //    new Claim( ClaimTypes.GroupSid, users..ToString()),
                //new Claim(ClaimTypes.PrimaryGroupSid, companies.ProductCategoryId.ToString()),
                //new Claim(ClaimTypes.Email, users.Email)
                }),
                Expires = DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

    }
}
