using System.Security.Cryptography;
using System.Text;

namespace SymmetricEncryptionDemo
{
    internal class CBC_MAC
    {
        public static (byte[], byte[], byte[], byte[]) Encrypt(string message)
        {
            // the key length must be 16, 24, or 32 bytes 
            byte[] key = new byte[32];
            RandomNumberGenerator.Fill(key);

            // the supported nonce sizes are 7, 8, 9, 10, 11, 12, or 13 bytes 
            byte[] nonce = new byte[AesCcm.NonceByteSizes.MaxSize];
            RandomNumberGenerator.Fill(nonce);

            // the supported tag sizes are 4, 6, 8, 10, 12, 14, or 16 bytes 
            byte[] tag = new byte[AesCcm.TagByteSizes.MaxSize];

            // the plaintext parameter and the ciphertext must have the same length.
            byte[] plaintext = Encoding.UTF8.GetBytes(message);
            byte[] ciphertext = new byte[plaintext.Length];

            using AesCcm aes = new(key);
            aes.Encrypt(nonce, plaintext, ciphertext, tag);

            return (key, nonce, tag, ciphertext);
        }

        public static string Decrypt(byte[] key, byte[] nonce, byte[] tag, byte[] ciphertext)
        {
            // the plaintext and the ciphertext must have the same length.
            byte[] plaintext = new byte[ciphertext.Length];

            using AesCcm aesCcm = new(key);
            aesCcm.Decrypt(nonce, ciphertext, tag, plaintext);

            return Encoding.UTF8.GetString(plaintext);
        }
    }
}
