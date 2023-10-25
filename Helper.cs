using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using netmvc.Models;

namespace netmvc
{
    public static class Helper
    {
        public static Object GetToken(string userId,ApplicationUser user,List<string> roles)
        {
            var key = ConfigurationManager.AppSettings["JwtKey"];

            var issuer = ConfigurationManager.AppSettings["JwtIssuer"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("userid", userId));
            if (roles.Count>0)
            {
                foreach (var role in roles)
                {
                    permClaims.Add(new Claim(ClaimTypes.Role,role ));

                }
            }
            
            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken(issuer, //Issure    
                issuer,  //Audience    
                permClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return new { access_token = jwt_token,token_type = "Bearer" };
        }
    }
}