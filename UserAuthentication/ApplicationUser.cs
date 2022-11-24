namespace UserAuthentication
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PemPrivateKey { get; set; }
        public string PemPublicKey { get; set; }
    }
}