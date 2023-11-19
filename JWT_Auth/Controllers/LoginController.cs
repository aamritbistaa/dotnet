using JWT_Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWT_Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        private Users AuthenticateUser(Users users)
        {
            Users _user = null;
            if(users.Username=="admin"&&users.Password=="admin")
            {
                _user = new Users { Username = "Amrit" };
            }
            return _user;
        }
        private string GenerateToken(Users users)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null, expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(Users users)
        {
            IActionResult response = Unauthorized();
            var user_ = AuthenticateUser(users);
            if(user_ != null)
            {
                var token = GenerateToken(user_);
                response = Ok(new { token = token });

            }
            return response;
        }
    }
}
