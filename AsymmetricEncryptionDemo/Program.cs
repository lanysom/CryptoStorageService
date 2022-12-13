﻿using System.Security.Cryptography;
using System.Text;

byte[] password = Encoding.UTF8.GetBytes("password");

// creating keys
using RSA keyRsa = RSA.Create();
byte[] privateKeyBytes = keyRsa.ExportEncryptedPkcs8PrivateKey(password, new PbeParameters(PbeEncryptionAlgorithm.Aes128Cbc, HashAlgorithmName.SHA256, 1000));
byte[] publicKeyBytes = keyRsa.ExportRSAPublicKey();

// generate some data to encrypt
byte[] data = Encoding.UTF8.GetBytes("The teacher is awsome");

// encrypt
using RSA encryptRsa = RSA.Create();
encryptRsa.ImportRSAPublicKey(publicKeyBytes, out int publicKeyBytesRead);
byte[] encryptedData = keyRsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);

Console.WriteLine($"Encrypted data: {Convert.ToBase64String(encryptedData)}\n");

// decrypt
using RSA decryptRsa = RSA.Create();
decryptRsa.ImportEncryptedPkcs8PrivateKey(password, privateKeyBytes, out int privateKeyBytesRead);
byte[] decryptedData = keyRsa.Decrypt(encryptedData, RSAEncryptionPadding.OaepSHA256);

Console.WriteLine($"Decrypted data: {Encoding.UTF8.GetString(decryptedData)}");

