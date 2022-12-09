using Authentication.Model;
using AuthenticationService.Model.Mappers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
            if (login.Username == null || login.Password == null)
            {
                throw new ArgumentException("Invalid login");
            }

            // validate username and password
            if (_authenticationProvider.ValidateLogin(login.Username, login.Password, out ApplicationUser? userInfo))
            {
                if (userInfo == null)
                {
                    return Unauthorized();
                }

                // login accepted                 
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

                // decrypting user keypair
                var publicKey = DecryptKey(userInfo.EncryptedPublicKey, login.Password);
                var privateKey = DecryptKey(userInfo.EncryptedPrivateKey, login.Password);
                
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", userInfo == null ? "" : userInfo.Id.ToString()),
                        new Claim("username", login.Username),
                        new Claim("publicKey", userInfo == null ? "" : publicKey),
                        new Claim("privateKey", userInfo == null ? "" : privateKey),
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
            if (login.Username == null || login.Password == null)
            {
                throw new ArgumentException("Invalid login");
            }

            // check username and create application user 
            if (!_authenticationProvider.CreateLogin(login.Username, login.Password, out ApplicationUser user))
            {
                return BadRequest("Could not create login");
            }
            // creating keys
            (string encryptedPrivateKey, string encryptedPublicKey) = CreateEncryptedKeyPair(login.Password);

            user.EncryptedPrivateKey = encryptedPrivateKey;
            user.EncryptedPublicKey = encryptedPublicKey;

            _authenticationProvider.UpdateUser(user);

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

        private static (string, string) CreateEncryptedKeyPair(string password)
        {
            // creating keys
            RSA rsa = RSA.Create();
            byte[] privateKeyBytes = rsa.ExportRSAPrivateKey();
            byte[] publicKeyBytes = rsa.ExportRSAPublicKey();

            // encrypting keys 
            byte[] encryptedPrivateKey = new byte[privateKeyBytes.Length];
            byte[] encryptedPublicKey = new byte[publicKeyBytes.Length];
            byte[] tag = new byte[16];
            byte[] nonce;
            byte[] key = MD5.HashData(Encoding.UTF8.GetBytes(password));

            using AesGcm privateAes = new(key);
            nonce = RandomNumberGenerator.GetBytes(12);
            privateAes.Encrypt(nonce, privateKeyBytes, encryptedPrivateKey, tag);
            string privateKeySet = $"{Convert.ToBase64String(nonce)}.{Convert.ToBase64String(tag)}.{Convert.ToBase64String(encryptedPrivateKey)}";

            using AesGcm publicAes = new(key);
            nonce = RandomNumberGenerator.GetBytes(12);
            publicAes.Encrypt(nonce, publicKeyBytes, encryptedPublicKey, tag);
            string publicKeySet = $"{Convert.ToBase64String(nonce)}.{Convert.ToBase64String(tag)}.{Convert.ToBase64String(encryptedPublicKey)}";

            return (privateKeySet, publicKeySet);
        }

        private static string DecryptKey(string keySet, string password)
        {
            // extract nonce
            byte[] nonce = Convert.FromBase64String(keySet[..16]);
            // extract tag
            byte[] tag = Convert.FromBase64String(keySet[17..41]);
            // extract key
            byte[] encryptedKey = Convert.FromBase64String(keySet[42..]);

            byte[] decryptedKey = new byte[encryptedKey.Length];
            byte[] key = MD5.HashData(Encoding.UTF8.GetBytes(password));

            using AesGcm aes = new(key);
            aes.Decrypt(nonce, encryptedKey, tag, decryptedKey);

            return Convert.ToBase64String(decryptedKey);
        }
    }


}
