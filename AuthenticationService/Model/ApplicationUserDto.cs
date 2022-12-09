using Authentication.Model;

namespace AuthenticationService.Model
{
    public class ApplicationUserDto
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? EncryptedPrivateKey { get; set; }
        public string? EncryptedPublicKey { get; set; }
    }
}
