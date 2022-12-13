using Authentication.Model;

namespace AuthenticationService.AuthenticationProvider.Data
{
    public class MemoryAuthenticationDataContext : IAuthenticationDataContext
    {
        private static List<ApplicationUser> _users = new();

        static MemoryAuthenticationDataContext()
        {
            _users.Add(new()
            {
                Id = Guid.Parse("46138a79a6664bcc8e3adcbe0125de78"),
                Username = "bob",
                PasswordHash = "lMV6BvSfkuMUBoWocjEDvSK32tzbkszBXYE5cWzvoodUOc4bbAw7s/3Xpg1G0FLx",
                EncryptedPrivateKey = "UcfGm7uBm4K+ZbiVUwi0YCwtm9yCVe5WX1rriw==pDdSFE65Va0MfPD6LEfYUrRt3infkDoq2PCBUhEjC8rWJxvLbtOd+xdwlDYs/VskWQ2uvYwUyAI1Wh1Q6izvTYOvDz3Xxct65r3RiAJN/gC6ODNIWg4rfgI2x8GAClHVKeKl6ER+6GNchZx5xRuAiEhrmmvaw73/3J23coHvQtnys0VPcetmZqbkZK/J8sQcz5r8hRCgSDp9JdcyHYoMcyi+NfZIiKpFmt9nw+v3jQSsDDbgc4IUvZefFVEcI1MV1eJd9zf2wwFgnRek5wk9hH3/UIjRzqgwq1um36xEWReJzSPkbOsLlEJU9QJs9+yEtHP9sE1kCgaV5ddmH4pw6WGq2VH58AzmDX1Z2AMq53uaO7k38MaL3m0+H/qzSrXR8b/btX4L/8I2xPKX740Ha3kQ7EV1dODRUIOaakFgGrT1i6iig/+WeuIxLqoH3kLC4B8icuFK8/zPmb9iPZpTMij/xrXIMQtnJNigs2bHvZlMD4cEK4KieVGIw/oGuayE0y7WrlSesqCLsbfEgboBSq7QaA9uJG72mcLwDeaDvK0bfjvboYcqA4izsqXasCbESnhCkiOdV0V0aC6aLSfT07rL1DMK8UobfirBk3lIzZXD9Wd6hKEncxk1prnJwdcE6/igikO0pljV/0MNEWsmrRHOY1OFT8AeIcG9sr31TNIKensViBTR+NzXY4YZeweqETjp+LRKRX/XVqjJJPGHbhpkj+keC+m5qjY7yQLk68h98pXJVqyrAH6Dy+vZOw4Zcjwb0ln0jWMNGZSeRB4uhC/j05k9RF9dX9Gshx8+zX+lTn3s2aM2ajiacmfdqgwyhgzLRxs3yCEZcAGOzmAr7L/B+tj5HhW2RR5cmuRMydgGbkRrn0+rh9+eXlM7uEAw+xLybX5t2SqktqjhVyNesvtwU0RBFCqjr4Rpea05ixTjJaIwIuo9HxpE1qr+D6k6oX0LHnTv4sOZBlWtCJEST+9N4DGO6os0faUhTd74FgkN6IXExlB5rWRq5FTxjqHRxXZOgw45HMp2WncNeAf8FDW0yMNfrRr4uxq4XX4cTUZ7GHA/QLvGwFPUhwJxTlO9EFX1ySw2dl1j9JoFpF6CZKlpIx9rsSxA+LkdIq16jBgx7tCAQ2D5qdFSnAO4fbhb562FSkHdkzK4yBCw3UVfJlhAWPyiymuLhadLCPQJ96p+NKGi6MAP8phxwgFZUAsBi8/FtPTgvFusa3lxONNg6mcM2IxJ3vvmBXbmrsc1kEnws1Ykt4SehUqsRrGvnctKgpym728JJD8QQEySIhot12VHQLFZK3/CW6r6WeGdrGGFQwK/vMw2/WoMv8U9TUqdVGmzYoiJ1QDQpnLZbZrUil/4Mg9gvrDtaw1Hlfu2GpmCq5Y1IxTbhg+f5+WAoOOYso13x1GMfjj+0cGejEKUG7GPLsXmAHSRLVesgACemu++z09pFSk9zIW78gQRQqf8eASAE8BGaB2c0SoM2K0uNsbHKlFpnoAeXYndyr+V8VbDO+3cjujk2hvUyzeg7gHwQUvrahhZBcl2cjOEHDYKeBbHPbVPGB1qPMH3/FrB+ZVCbVxnemuM",
                EncryptedPublicKey = "7FT04ybN7GR5Ppx0rlc5UswdBynpe1BtsF5DKw==Dl59NwuYjBA9BML4WcOQrKrFak9wUqFsDXUqg4n2WiXY5JYN/mLVqGqb4xskAK1LtmXsrPoqTPXLOP3f1SkfTS4kRkA/e3NwdWPjXAAbW4UFivJDH7LL7UDsZZkupFm3cGKGao0apYx7CfMt0Nb9DxxPiexetkQ9SSmKy7t3AAb1d/UaGIPVOP6JM8SM2lAyjjmMDpKC7MRJPpX2zuJLIkqQwP2s5ojjB2ruH1CUN/imKO850inLNhjf0ftFc1oz59SmmwADS3SmZVBle3an35AjXKgBbuvYjqO8xicHybggeUZgD8ysFmH5qDHCYudjpJGC610jCKI05GYdQvSgWMAdDF6iSfTmfINekl1K"
            });
            _users.Add(new()
            {
                Id = Guid.Parse("ea789eb5588547d6a1c4c5d22d151eea"),
                Username = "alice",
                PasswordHash = "vA0iClB6qGfD/FoyHSxHxklU9oTgnPkkYqjkz0jMrUGTkYMEKMRuWE/Xl/B5L3jC",
                EncryptedPrivateKey = "jzTjmrIROBzbkVdP4WYeIxGXbaQVhdaXZcrWGQ==t9/KFp0Yb+rI/TnMZsKFSE1jazmusCSbrcMLytiqGZ9Sg7ga0vod44BezDzd6tgazosyZbOT6/J3dFPr1vf2SGG34ngN+05nUUbndYBj1CIna5dhJBTpLQPQijdZe5+DQ6u/oMJNCyiNypm8UYfAe14e7z80aqzzht02V7MWpXKN2dBYO2kiGi3vIptUhI5ZNOYfLk0tbL4Qzb0av+Ik4DE8SkpIQMnoti9xcQPc6OoVYsiPRwK2Xjh1EH1Ly3hIL7uaqLt94c4A1Eip8N0eszIoRFtlC0Ibm+jJYgMAXO3lmHQJiNZbwr4TXd2qkOurvw4BNwAEgtbqxgqNMsNAyJ54SK75LZDhHSMnoToU/2OdFpxRAAWEYw9SI1T81I0KXIJ4pyxchMssY+IU2Dss0LVlfMflaIJ5rFaCyH7ywBSOpRcqe//9RIKWDl8aSxwVvLQxJKBWwEzIeYko4nxEUZn8HfXFwHULqvC21vpbvRUlouFAn+SNJNRM+fdI8DOvaf8Hf+bN+MSKzeUkwkunIK/ezA/PH/2k8/abcKWqRheKA5rN5ezPIxslbpPahpC2yvcuzZEK9cP0h8XsFfnIH2xguaJLoJWiGfdXg2on5+uKp/7iOcfW58+yv6hIXzBAVgFE5b2JjEsexo8AxmIvZ1XSYrK6zITurTiGaxVbMFrfNcE5LM2WMiJJHGh0nOckzDR7roBL18L339Axq4b5yNM68iQqOCUvWVx5WMm1qxyFwteBgs9xL2519E7802ubsxY3h01LGhNAMmaJ7ntNMn+Emcngo7HFX02FV7wuQemzxyoA6rYEL4U0eNfZWooalPkQDbXOMLkl+O8i4gpLQTGYq4PClru25wkddXWc2HVpyyIUF1yun3vcvimHja5n1QWzSFj9l0FWSHlJvZ1NnMxjJBqFJaXS8/WG8zKvY6FqbZ/LiRIfA/KTGAH9gpNKQ2aQTF4ij3UFpQvE4he5Uy6DUnCeh9+5OgNpEwE0BA3Bfol/82nrFrnUN1lvWid/N0fxybaCrH11DFzRM5ngv8UT0MnKgNKLWFiu+zrPEuOSZJCf2nZNIxkADdf1msnA0iJvk/sJCXW2dOk1PJowMKr+A4ipZugpU29uD089RKFqQM3jvDRFLP47bp9N0ER/qOdBEAKGlaWTF9P6v4gMyrPR37p0/7xShYppXylgY/4PMsvseeyHORUrdhetbwLldWNwmcBiwYbIAzXiEHIpb1qG5wi/hda/toLrXbjwUBAvinouw6eulvSrYiXTujsoUl72IbyCDp9eJO67/tcRnHVeewp+FPbWYVuDfo4TiveavZ/NVqPs9EhdiShnCRUZN0Y6te8I+6jVS7UC5rj4sntZ5l06avD1QPBq8+ILcYkV0E9jIJ/ecD46lZwWq+V/Vys8CYVaRqcYJQf28AhkqiXWZrGokwxAHiKsimJrGr+uVne2u1W6IDW418GlX3gIC9iV2kEP6MNMG3TLRnavkWl8e1ZscnpeiFGgW9yzBsp3kvd3HCxt5x4+eSboOPehM84oiiDjpAx22ENSuJUMJpvnH0iZybpFnZQ+VzPZQRNXFmPms0v3",
                EncryptedPublicKey = "nchMxmA6KM+t5hr+OeaeGgGrt/WPFQ24qfsESw==FRWco7DdoVxHft3hn36g3q2iV13Pg2dmYIz+F2VG+Sjj+m1ajsKrVuJlDW6sYcL532xKKeP0OqQqlKBgbUqgythDjZxwXkN+oCCHW6lwu+zCve3MZcRxpID7ToEia57bvKMV+xkrGaJuv4s/JhicCTXUGpb9kPvpqXnxsEuTbHuurhODxyYBNJlnWlTK7OhGdjhh7PSNFGFjFB5vLRsYh2hR06rmN9yc3nvZ/0NpnACk9ikzgIH61z/H7KLLjYyUk79IfIg9EILUA3AOxCPUPHyl6O5o+7GUykIJH7mKqmDlS0iZI6ZacYM/DNBOh5gzgUVIVnIVpkHdL6Ba+0s0FqVQDoj7kzpctQvGPymo"
            });
        }

        public void AddUser(ApplicationUser user)
        {
            _users.Add(user);
        }

        public ApplicationUser? GetUser(string username)
        {
            return _users.SingleOrDefault(x => x.Username == username);
        }

        public void RemoveUser(string username)
        {
            ApplicationUser? user = _users.SingleOrDefault(x => x.Username == username);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        public void UpdateUser(ApplicationUser newUser)
        {
            ApplicationUser? oldUser = _users.SingleOrDefault(x => x.Username == newUser.Username);
            if (oldUser != null)
            {
                oldUser.Username = newUser.Username;
                oldUser.EncryptedPrivateKey = newUser.EncryptedPrivateKey;
                oldUser.EncryptedPublicKey = newUser.EncryptedPublicKey;
            }
        }
    }
}
