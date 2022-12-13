using System.Security;

namespace Authentication.Model
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash{ get; set; } = string.Empty;
        public string EncryptedPrivateKey { get; set; } = string.Empty;
        public string PublicKey { get; set; } = string.Empty;
    }
}