namespace StorageProvider
{
    public class CryptoData
    {
        public Guid Id { get; set; }
        public byte[] EncryptedData { get; set; } = Array.Empty<byte>();
        public byte[] EncryptedKey { get; set; } = Array.Empty<byte>();
        public byte[] Nonce { get; set; } = Array.Empty<byte>();
        public byte[] Tag { get; set; } = Array.Empty<byte>();
    }
}
