using SymmetricEncryptionDemo;
using System.Security.Cryptography;
using System.Text;

string plaintext = "The workshop instructor is a cryptographic genius";

(string key, string nonce, string tag, string ciphertext) = GCM.Encrypt(plaintext);

Console.WriteLine($"Plaintext: {plaintext}");
Console.WriteLine($"CipherText: {ciphertext}");
Console.WriteLine($"Key: {key}");
Console.WriteLine($"Nonce: {nonce}");
Console.WriteLine($"Tag: {tag}");

Console.WriteLine($"Decrypted ciphertext: {GCM.Decrypt(key, nonce, tag, ciphertext)}");