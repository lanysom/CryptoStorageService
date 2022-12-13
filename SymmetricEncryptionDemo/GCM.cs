﻿using System.Security.Cryptography;
using System.Text;

namespace SymmetricEncryptionDemo
{
    internal class GCM
    {
        public static (string, string, string, string) Encrypt(string message)
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

            string encryptedMessage = Convert.ToBase64String(ciphertext);
            string generatedTag = Convert.ToBase64String(tag);
            string generatedNonce = Convert.ToBase64String(nonce);
            string generatedKey = Convert.ToBase64String(key);

            return (generatedKey, generatedNonce, generatedTag, encryptedMessage);
        }

        public static string Decrypt(string keyString, string nonceString, string tagString, string ciphertextString)
        {
            byte[] key = Convert.FromBase64String(keyString);
            byte[] nonce = Convert.FromBase64String(nonceString);
            byte[] tag = Convert.FromBase64String(tagString);
            byte[] ciphertext = Convert.FromBase64String(ciphertextString);

            // the plaintext and the ciphertext must have the same length.
            byte[] plaintext = new byte[ciphertext.Length];

            using AesGcm aesGcm = new(key);
            aesGcm.Decrypt(nonce, ciphertext, tag, plaintext);

            return Encoding.UTF8.GetString(plaintext);
        }
    }
}
