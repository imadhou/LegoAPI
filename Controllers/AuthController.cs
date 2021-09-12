using LegoApi.Errors;
using LegoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LegoApi.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController: ControllerBase
    {
        private readonly IConfiguration configuration;
        private List<User> Users = new List<User>
                {
                    new User{id=0, email="aa@aa.aa", password="12345678"},
                    new User{id=1, email="bb@bb.bb", password="12345678"},
                    new User { id = 2, email = "cc@cc.cc", password = "12345678" },
                    new User { id = 3, email = "dd@dd.dd", password = "12345678" },
                };
        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [Route("login")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoggedInUser))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public IActionResult Login([FromBody] User user)
        {
            var foundUser = Users.Find(e => e.email == user.email);
            if(foundUser == null || foundUser.password != user.password)
            {
                throw new LoginException("Email ou mot de passe incorrect");
            }
            LoggedInUser loggedInUser = new LoggedInUser();
            loggedInUser.email = foundUser.email;
            loggedInUser.token = CreateJWT(user);
            return Ok(loggedInUser);
        }


        private string CreateJWT(User user)
        {
            var jwtSecret = configuration.GetSection("AppSettings:JWT_SECRET").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.email),
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString())
            };
            var signedCredintials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = signedCredintials,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
