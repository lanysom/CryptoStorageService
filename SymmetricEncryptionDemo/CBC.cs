using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricEncryptionDemo
{
    internal class CBC
    {
        // returns key, iv, ciphertext
        public static (byte[], byte[], byte[]) Encrypt(string message)
        {
            byte[] plaintext = Encoding.UTF8.GetBytes(message);

            Aes aes = Aes.Create();
            byte[] ciphertext = aes.EncryptCbc(plaintext, aes.IV);

            return (aes.Key, aes.IV, ciphertext);
        } 

        public static string Decrypt(byte[] key, byte[] iv, byte[] ciphertext)
        {
            Aes aes = Aes.Create();
            aes.Key = key;

            byte[] plaintext = aes.DecryptCbc(ciphertext, iv);

            return Encoding.UTF8.GetString(plaintext);
        }
    }
}
