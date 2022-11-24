using Authentication.Model;
using AuthenticationService.Model.Mappers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationProvider _authenticationProvider;

        public AuthenticationController(IConfiguration configuration, IAuthenticationProvider authenticationProvider)
        {
            _configuration = configuration;
            _authenticationProvider = authenticationProvider;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto login)
        {
            // validate username and password
            if (login.IsValid && _authenticationProvider.ValidateLogin(login.Username, login.Password, out ApplicationUser? userInfo))
            {
                // login accepted                 
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", userInfo == null ? "" : userInfo.Id.ToString()),
                        new Claim("username", login.Username),
                        new Claim("publicKey", userInfo == null ? "" : userInfo.PublicKey), 
                        new Claim("privateKey", userInfo == null ? "" : userInfo.PrivateKey),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    }),
                    //Expires = DateTime.UtcNow.AddMinutes(5),
                    Expires = DateTime.UtcNow.AddDays(30),
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(tokenHandler.WriteToken(token));
            }
            return Unauthorized();
        }

        [HttpPost("register")]
        public IActionResult Register(LoginDto login)
        {
            if (login.IsValid)
            {
                // check username and create application user 
                if (!_authenticationProvider.CreateLogin(login.Username, login.Password))
                {
                    return BadRequest("Could not create login");
                }
            }
            return Ok();
        }

        [HttpGet("userinfo")]
        [Authorize]
        public IActionResult GetUserInfo()
        {
            string username = User.Claims.First(c => c.Type == "username").Value;
            ApplicationUser? info = _authenticationProvider.GetUserInfo(username);
            return Ok(info?.Map());
        }
    }
}
