using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.AccessData.Models.Account;
using Microsoft.Extensions.Options;
using CommonJtw;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
namespace store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IOptions<AuthOptions> authOptions;
        public AuthController(IOptions<AuthOptions> authOptions)
        {
            this.authOptions = authOptions;
        }
        private List<Account> Accounts => new()
        {
            new Account()
            {
                Id = Guid.Parse("3a7c77d6-9462-4da0-a3a4-20ba6be8b741"),
                Email = "admin@gmail.com",
                Password = "admin",
                Roles = new DB.AccessData.Models.Account.Role[] { Role.Admin }
            },
            new Account()
            {
                Id = Guid.Parse("2094b1a7-ed7b-436b-be8a-a3abd0f3f3f5"),
                Email = "user@gmail.com",
                Password = "user",
                Roles = new DB.AccessData.Models.Account.Role[] { Role.User }
            },
            new Account()
            {
                Id = Guid.Parse("be118a6b-43af-4fe1-8c9a-96d887a75d5c"),
                Email = "user@example.com",
                Password = "emp",
                Roles = new DB.AccessData.Models.Account.Role[] { Role.Employee }
            },
        };


        [HttpPost]
        public IActionResult Login([FromBody]Login login)
        {
            var user = AuthencateUser(login.Email, login.Password);

            if (user != null)
            {
                var token = GenerateJWT(user);
                return Ok(new { access_token = token });
            }
            else
            {
                return Unauthorized();
            }
        }


        private Account AuthencateUser(string email, string password)
        {
            return Accounts.SingleOrDefault(u => u.Email==email && u.Password == password);
        }

        private string GenerateJWT(Account user)
        {
            
            var authParams = authOptions.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();
            var credintials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            foreach (var item in user.Roles)
            {
                claims.Add(new Claim("role", item.ToString())); 
            }

            var token = new JwtSecurityToken(authParams.Issuer, authParams.Audience, claims, expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime), signingCredentials: credintials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
