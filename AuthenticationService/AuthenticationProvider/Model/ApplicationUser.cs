using System.Security;

namespace Authentication.Model
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash{ get; set; } = string.Empty;
        public byte[] EncryptedPrivateKey { get; set; } = Array.Empty<byte>();
        public byte[] PublicKey { get; set; } = Array.Empty<byte>();
    }
}