using System.Security.Cryptography;
using System.Text;

namespace SymmetricEncryptionDemo
{
    internal class GCM
    {
        public static (byte[], byte[], byte[], byte[]) Encrypt(string message)
        {
            // the key length must be 16, 24, or 32 bytes 
            byte[] key = new byte[32];
            RandomNumberGenerator.Fill(key);

            // the supported nonce sizes is 12 bytes 
            byte[] nonce = new byte[AesGcm.NonceByteSizes.MaxSize];
            RandomNumberGenerator.Fill(nonce);

            // the supported tag sizes are 12, 13, 14, 15, or 15 bytes 
            byte[] tag = new byte[AesGcm.TagByteSizes.MaxSize];

            // the plaintext parameter and the ciphertext must have the same length.
            byte[] plaintext = Encoding.UTF8.GetBytes(message);
            byte[] ciphertext = new byte[plaintext.Length];

            using AesGcm aesGcm = new(key);
            aesGcm.Encrypt(nonce, plaintext, ciphertext, tag);

            return (key, nonce, tag, ciphertext);
        }

        public static string Decrypt(byte[] key, byte[] nonce, byte[] tag, byte[] ciphertext)
        {
            // the plaintext and the ciphertext must have the same length.
            byte[] plaintext = new byte[ciphertext.Length];

            using AesGcm aesGcm = new(key);
            aesGcm.Decrypt(nonce, ciphertext, tag, plaintext);

            return Encoding.UTF8.GetString(plaintext);
        }
    }
}
