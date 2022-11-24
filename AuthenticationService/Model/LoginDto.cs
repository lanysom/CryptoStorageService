namespace Authentication.Model
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsValid => !string.IsNullOrEmpty(Password) || !string.IsNullOrEmpty(Username);
    }
}
