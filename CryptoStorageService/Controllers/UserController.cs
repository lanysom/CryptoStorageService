using CryptoStorageService.Models;
using DataAccess;
using DataAccess.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CryptoStorageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IDao<EncryptedUser> _userDao;

        private const int KEY_LENGTH = 32;
        private const int IV_LENGTH = 16;

        public UserController(IDao<EncryptedUser> userDao)
        {
            _userDao = userDao;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                // Gets encrypted user info from db 
                EncryptedUser? user = _userDao.Read(id);
                if (user == null)
                {
                    return NotFound();
                }
                // get key from User
                string privateKey = User.Claims.First(c => c.Type == "privateKey").Value;

                // decrypts key and iv
                (byte[] key, byte[] iv) = DecryptKeyIV(user.EncryptedKey, privateKey);
                // decrypts data
                string decryptedData = DecryptData(user.EncryptedData, key, iv);

                UserDto? dto = JsonSerializer.Deserialize<UserDto>(decryptedData);

                return Ok(dto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post(UserDto userDto)
        {
            // gets userid and key from jwt
            string id = User.Claims.First(c => c.Type == "Id").Value;
            string publicKey = User.Claims.First(c => c.Type == "publicKey").Value;

            using Aes aes = Aes.Create();


            byte[] encryptedKeyBytes = EncryptKeyIV(aes.Key, aes.IV, publicKey);
            // encrypts user data and stores it in db

            string encryptedData = EncryptData(JsonSerializer.Serialize(userDto), aes.Key, aes.IV); //Convert.ToBase64String(encryptedDataBytes);
            string encryptedKeyIV = Convert.ToBase64String(encryptedKeyBytes);

            EncryptedUser encryptedUser = new()
            {
                Id = new Guid(id),
                EncryptedData = encryptedData, // symmetric encrypted data
                EncryptedKey = encryptedKeyIV, // assymmetric encrypted key
            };
            _userDao.Create(encryptedUser);

            return Ok(encryptedUser); // StatusCode(StatusCodes.Status501NotImplemented);
        }

        private static byte[] EncryptKeyIV(byte[] key, byte[] iv, string publicKey)
        {
            byte[] publicKeyBytes = Convert.FromBase64String(publicKey);
            byte[] joinedKeyIVBytes = new byte[KEY_LENGTH + IV_LENGTH];

            Buffer.BlockCopy(key, 0, joinedKeyIVBytes, 0, KEY_LENGTH);
            Buffer.BlockCopy(iv, 0, joinedKeyIVBytes, KEY_LENGTH, IV_LENGTH);

            using (RSACryptoServiceProvider rsaProvider = new())
            {
                rsaProvider.ImportRSAPublicKey(publicKeyBytes, out int bytesRead);

                return rsaProvider.Encrypt(joinedKeyIVBytes, false);
            }
        }

        private static string EncryptData(string data, byte[] key, byte[] iv)
        {
            // Create an Aes object for symmetric encryption with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create an encryptor to perform the encryption.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor();

                // encrypts the data.
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                byte[] cipherBytes = encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length);

                // Return the encrypted bytes.
                return Convert.ToBase64String(cipherBytes);
            }
        }

        private static string DecryptData(string data, byte[] key, byte[] iv)
        {
            // Create an Aes object for symmetric encryption with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create an encryptor to perform the encryption.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor();

                // decrypts the data.
                byte[] dataBytes = Convert.FromBase64String(data);
                byte[] decryptedDataBytes = decryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length);

                return Encoding.UTF8.GetString(decryptedDataBytes);
            }
        }

        private static (byte[] key, byte[] iv) DecryptKeyIV(string keyIv, string privateKey)
        {
            byte[] keyIvBytes = Convert.FromBase64String(keyIv);
            byte[] privateKeyBytes = Convert.FromBase64String(privateKey); // Encoding.UTF8.GetBytes(privateKey);

            using (RSACryptoServiceProvider rsaProvider = new())
            {
                rsaProvider.ImportRSAPrivateKey(privateKeyBytes, out int bytesRead);

                byte[] decryptedKeyBytes = rsaProvider.Decrypt(keyIvBytes, false);
                byte[] key = new byte[KEY_LENGTH];
                byte[] iv = new byte[IV_LENGTH];
                Buffer.BlockCopy(decryptedKeyBytes, 0, key, 0, KEY_LENGTH);
                Buffer.BlockCopy(decryptedKeyBytes, KEY_LENGTH, iv, 0, IV_LENGTH);
            
                return (key, iv);
            }
        }
    }
}
