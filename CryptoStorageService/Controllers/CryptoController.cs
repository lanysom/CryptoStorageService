﻿using CryptoStorageService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorageProvider;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CryptoStorageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CryptoController : ControllerBase
    {
        private readonly IDao<EncryptedUser> _userDao;

        public CryptoController(IDao<EncryptedUser> userDao)
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
                // get private key from User for decryption of key
                string userPrivateKey = User.Claims.First(c => c.Type == "privateKey").Value;

                // decrypts data
                UserDto? decryptedData = DecryptData(user, userPrivateKey);

                return Ok(decryptedData);
            }
            catch (CryptographicException ex)
            {
                return NotFound(); // StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post(UserDto userDto)
        {
            // gets userid and key from jwt
            string id = User.Claims.First(c => c.Type == "Id").Value;
            string userPublicKey = User.Claims.First(c => c.Type == "publicKey").Value;

            // encrypts user data 
            EncryptedUser encryptedUser = EncryptData(userDto, id, userPublicKey); 

            _userDao.Create(encryptedUser);
            return Ok(encryptedUser);
        }

        [HttpPut]
        public IActionResult Put(UserDto userDto)
        {
            // gets userid and key from jwt
            string id = User.Claims.First(c => c.Type == "Id").Value;
            string userPublicKey = User.Claims.First(c => c.Type == "publicKey").Value;

            // encrypts user data
            EncryptedUser encryptedUser = EncryptData(userDto, id, userPublicKey);

            _userDao.Update(encryptedUser);
            return Ok(encryptedUser);
        }

        private static EncryptedUser EncryptData(UserDto userDto, string id, string publicKey)
        {
            // generate symmetric encryption key
            byte[] key = new byte[32];
            RandomNumberGenerator.Fill(key);
            
            // generate nonce
            byte[] nonce = new byte[AesCcm.NonceByteSizes.MaxSize];
            RandomNumberGenerator.Fill(nonce);

            // create plaintext bytes from UserDto
            byte[] plaintext = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(userDto));
            
            // initialize chiphertext bytes
            byte[] ciphertext = new byte[plaintext.Length];
            
            // initialize tag
            byte[] tag = new byte[AesCcm.TagByteSizes.MaxSize];

            // symmetrically encrypt data
            using AesCcm aes = new(key);
            aes.Encrypt(nonce, plaintext, ciphertext, tag);

            // assymetrically encrypt key
            byte[] publicKeyBytes = Convert.FromBase64String(publicKey);

            using RSA rsa = RSA.Create();
            rsa.ImportRSAPublicKey(publicKeyBytes, out _);
            byte[] encryptedKey = rsa.Encrypt(key, RSAEncryptionPadding.OaepSHA256);

            return new()
            {
                Id = new Guid(id),
                EncryptedData = Convert.ToBase64String(ciphertext), // symmetric encrypted data
                EncryptedKey = Convert.ToBase64String(encryptedKey), // assymmetric encrypted key
                Nonce = Convert.ToBase64String(nonce),
                Tag = Convert.ToBase64String(tag)
            };
        }

        
        private static UserDto? DecryptData(EncryptedUser data, string privateKey)
        {
            // decrypt symmetric key using the users private key
            byte[] encryptedKey = Convert.FromBase64String(data.EncryptedKey);
            using RSA rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);
            byte[] key = rsa.Decrypt(encryptedKey, RSAEncryptionPadding.OaepSHA256);

            // initialize chiphertext bytes
            byte[] ciphertext = Convert.FromBase64String(data.EncryptedData);
           
            // create plaintext bytes from UserDto
            byte[] plaintext = new byte[ciphertext.Length];
            
            // initialize tag
            byte[] tag = Convert.FromBase64String(data.Tag);
            
            // initialize nonce
            byte[] nonce = Convert.FromBase64String(data.Nonce);

            // symmetrically decrypt data
            using AesCcm aes = new(key);
            aes.Decrypt(nonce, ciphertext, tag, plaintext);

            return JsonSerializer.Deserialize<UserDto?>(Encoding.UTF8.GetString(plaintext));
        }
    }
}
