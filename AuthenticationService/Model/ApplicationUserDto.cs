using Authentication.Model;

namespace AuthenticationService.Model
{
    public class ApplicationUserDto
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? PrivateKey { get; set; }
        public string? PublicKey { get; set; }
    }
}
