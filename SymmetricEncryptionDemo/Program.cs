using SymmetricEncryptionDemo;

string plaintext = "The workshop instructor is a cryptographic genius";

byte[] key;
byte[] nonce;
byte[] tag = Array.Empty<byte>();
byte[] ciphertext;

(key, nonce, ciphertext) = CBC.Encrypt(plaintext);

//(key, nonce, tag, ciphertext) = CBC_MAC.Encrypt(plaintext);
//(key, nonce, tag, ciphertext) = GCM.Encrypt(plaintext);

Console.WriteLine($"Plaintext : {plaintext}\n");
Console.WriteLine($"CipherText: {Convert.ToBase64String(ciphertext)}\n");
Console.WriteLine($"Key       : {Convert.ToBase64String(key)} \n");
Console.WriteLine($"Nonce     : {Convert.ToBase64String(nonce)} \n");
Console.WriteLine($"Tag       : {Convert.ToBase64String(tag)} \n");

Console.WriteLine($"Decrypted ciphertext: {CBC.Decrypt(key, nonce, ciphertext)}");

//Console.WriteLine($"Decrypted ciphertext: {CBC_MAC.Decrypt(key, nonce, tag, ciphertext)}");
//Console.WriteLine($"Decrypted ciphertext: {GCM.Decrypt(key, nonce, tag, ciphertext)}");