using Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    public interface IAuthenticationProvider
    {
        bool CreateLogin(string username, string password, out ApplicationUser user);
        ApplicationUser? GetUserInfo(string username);
        void UpdateUser(ApplicationUser user);
        bool ValidateLogin(string username, string password, out ApplicationUser? userInfo);
    }
}
