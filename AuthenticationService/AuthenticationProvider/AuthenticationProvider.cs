using Authentication.Model;
using AuthenticationService.AuthenticationProvider.Data;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Authentication
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private readonly IAuthenticationDataContext _dataContext;
        //private readonly ICertificateUtility _certificateUtility;
        private const KeyDerivationPrf PRF = KeyDerivationPrf.HMACSHA512;
        private const int ITERATION_COUNT = 10000;
        private const int SALT_LENGTH = 16;
        private const int DERIVED_KEY_LENGTH = 32;

        public AuthenticationProvider(IAuthenticationDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CreateLogin(string username, string password)
        {
            // check username
            ApplicationUser? userInfo = _dataContext.GetUser(username);
            if (userInfo != null)
            {
                return false;
            }

            RSA rsa = RSA.Create();
            byte[] privateKeyBytes = rsa.ExportRSAPrivateKey();
            byte[] publicKeyBytes = rsa.ExportRSAPublicKey();

            var privateKey = Convert.ToBase64String(privateKeyBytes);
            var publicKey = Convert.ToBase64String(publicKeyBytes);

            userInfo = new()
            {
                Id = Guid.NewGuid(),
                Username = username,
                PasswordHash = CreatePasswordHash(password), // creates password hash
                PublicKey = publicKey, // create public key
                PrivateKey = privateKey // create private key
            };
            _dataContext.AddUser(userInfo);
            return true;
        }

        public ApplicationUser? GetUserInfo(string username)
        {
            return _dataContext.GetUser(username);
        }

        public bool ValidateLogin(string username, string password, out ApplicationUser? userInfo)
        {
            // gets the user
            userInfo = _dataContext.GetUser(username);
            if (userInfo == null)
            {
                return false;
            }
            // validates whether the hash of the provided password equals the stored one 
            return ValidatePassword(password, userInfo.PasswordHash);
        }

        private static string CreatePasswordHash(string password)
        {
            // generate salt
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] saltBytes = new byte[SALT_LENGTH];
            rng.GetBytes(saltBytes);

            byte[] subkey = KeyDerivation.Pbkdf2(password, saltBytes, PRF, ITERATION_COUNT, DERIVED_KEY_LENGTH);

            // creates a bytearray that contains the salt and the subkey
            var passwordHashBytes = new byte[SALT_LENGTH + subkey.Length];
            Buffer.BlockCopy(saltBytes, 0, passwordHashBytes, 0, SALT_LENGTH);
            Buffer.BlockCopy(subkey, 0, passwordHashBytes, SALT_LENGTH, subkey.Length);

            return Convert.ToBase64String(passwordHashBytes);
        }

        private static bool ValidatePassword(string password, string passwordHash)
        {
            byte[] hash = Convert.FromBase64String(passwordHash);
            int passwordHashLength = hash.Length - SALT_LENGTH;

            // extract password hash
            byte[] passwordHashBytes = new byte[passwordHashLength];
            Buffer.BlockCopy(hash, SALT_LENGTH, passwordHashBytes, 0, passwordHashLength);

            // extract salt
            byte[] saltBytes = new byte[SALT_LENGTH];
            Buffer.BlockCopy(hash, 0, saltBytes, 0, SALT_LENGTH);

            // generates password hash for comparison
            byte[] subkey = KeyDerivation.Pbkdf2(password, saltBytes, PRF, ITERATION_COUNT, DERIVED_KEY_LENGTH);

            // returns result
            return passwordHashBytes.SequenceEqual(subkey);
        }


    }
}
