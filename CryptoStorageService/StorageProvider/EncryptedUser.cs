namespace StorageProvider
{
    public class EncryptedUser
    {
        public Guid Id { get; set; }
        public string EncryptedData { get; set; } = string.Empty;
        public string EncryptedKey { get; set; } = string.Empty;
        public string Nonce { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
    }
}
