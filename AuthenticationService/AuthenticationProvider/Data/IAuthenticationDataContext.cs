using Authentication.Model;

namespace AuthenticationService.AuthenticationProvider.Data
{
    public interface IAuthenticationDataContext
    {
        ApplicationUser? GetUser(string username);

        void AddUser(ApplicationUser user);
    }
}
