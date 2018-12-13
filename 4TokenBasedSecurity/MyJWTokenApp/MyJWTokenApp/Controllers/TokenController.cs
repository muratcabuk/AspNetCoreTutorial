using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyJWTokenApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {



        [HttpPost]
        public IActionResult Get([FromBody] UserInfo user)
        {

            if(IsValidUser(user.UserName, user.Password))
            {
              return new ObjectResult(GenerateToken(user.UserName));
            }

            return Unauthorized();


        }


        private string GenerateToken(string userName)
        {

            var myClaims = new Claim[]
            {

                new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                new Claim(JwtRegisteredClaimNames.Email, "info@muratcabuk.com"),
                new Claim(JwtRegisteredClaimNames.NameId, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Website, "http://muratcabuk.com")

            };


            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Murat Cabuk Sign Key"));


            var token = new JwtSecurityToken(
                issuer: "www.muratcabuk.com",
                audience: "murat.muratcabuk.com",
                claims: myClaims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);


        }


        private bool IsValidUser(string userName, string password)
        {

            if(userName=="murat" && password == "1234")
            {

                return true;

            }

            return false;

        }



        public class UserInfo
        {

            public string UserName { get; set; }
            public string Password { get; set; }


        }


    }
}