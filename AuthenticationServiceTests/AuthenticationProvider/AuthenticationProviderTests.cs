using Xunit;
using Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Model;
using AuthenticationService.AuthenticationProvider.Data;

namespace Authentication.Tests
{
    public class AuthenticationProviderTests
    {
        [Fact]
        public void CreateLoginTest()
        {
            // Arrange
            var provider = new AuthenticationProvider(new MemoryAuthenticationDataContext()); 

            // Act
            var result1 = provider.CreateLogin("test", "password", out ApplicationUser? user);

            // Assert
            Assert.True(result1);
            Assert.NotNull(user);
        }
    }
}