using Authentication.Model;
using System.Text.Json;

namespace AuthenticationService.AuthenticationProvider.Data
{
    public class MemoryAuthenticationDataContext : IAuthenticationDataContext
    {
        //private static List<ApplicationUser> _users = new();
        private static Dictionary<string, string> _users = new();

        static MemoryAuthenticationDataContext()
        {
            _users.Add("alice", "{\"Id\":\"9273742a-cc58-4bbd-96b3-fd32fab13836\",\"Username\":\"alice\",\"PasswordHash\":\"5okxIK8Yd3YowJHtgLXvRwf7k6O78EYVkgvE4Q7W6Ub2B4WQScBns3fhnxCk7Jmd\",\"EncryptedPrivateKey\":\"MIIFNTBfBgkqhkiG9w0BBQ0wUjAxBgkqhkiG9w0BBQwwJAQQwQlWPnO6qcbHWfa02TclWAICA+gwDAYIKoZIhvcNAgkFADAdBglghkgBZQMEAQIEEPQ0ClU7kLqnJlVKT/c7AsgEggTQkkqLOwotfzmV1NACy+ErDja5px/jvn+u84XypVBtd/Rk+f0Oj9wcVdNr3ZBJG5KYX1syKAfpWWz5sJ5DF0sCJCsfxiNIT56lZwee4H5fseQdq7ehWuoHA6YoXxAz278WhAcXwhwnI4uXlJoLFB2+LyOVsjV1I9wpAL4zF/Qo4hAC9YiBmDzQvefFPosPXXzuMKi6qj4TfkMJyrzfqWAmeczYP260X0bC16SRtnwoEhKDjXgA4ekUG6yHhBtQidiRdWQqRQw4p8/sxhR+Hcplb+bD4fThau3+6m1yv7KblfWaVMWuOZRkcYIYjV/aSfcPfQ9BMZ7hRqSF9XVB94c1KHybNqnNhg85JuQ8uNLcSjl/P7aKjgOvIY3eJ12l9GDRaZJK95y1cbnrWPdgTVwsJDbqEY7/4RxyCISuV1hCR8Syms1d5dsW56NhEf8iISqHsAhelFaz4R+PiozBC9tIKaKnSMJPnhX5j7huyXuaOwyBjv+vZ7QeXikmC+SCcYo9otZARLirqFIxDgll3KZ5yjTc7rGD1erNIVxlyWEJnnYZQO5KEGZw3x9VEUpHeBQahNEF6opJ1HUzCxMLu9k5QhkgR2aQqosqoueHSttHOhCfp5Ln1pVELiif4s8HAU7RIMjx3o0Ehcd/LwQgS/OhvpRDLDutLfAqWwTq1cdTTV43QS5nOwmQoZjk6ChvLYL4yOoaYPAkc84WCKiXmuHAMuTHYmTkWnVvLJn5OvPSjXgLOJuqDcQZ/R9Eb9l0gafJKMXEJALyukd8taUBQYD4vdYhndHb51ebivgFVshTyWcdC/lfQcA4p3pvzaJI6TbUrBG7cqPg9YUIfNkXuetLdjWvtCdf91pC0WPmue/FDlBuvFgJgIGAOOkhn6dYa3XTReinA1birb6grHMPurcufANLXaty9Q2np3k2U39ExbtlQO7VWYIj4VvOqzmQW4BJ5/A40Gz3QJ7DlnLIZpFOaTDsQL/9EuFJpQbyyhl0bP99iVJ93lfeSKcEAs+7Y0AJC3ittQLQu3PtTsQE2FLAS5mQvurf6bOLMH9KnkpPtOB5BzlDIBIDWWb0Xus7e91R09Q02ADOvBQaefIatZFgYFqmMjZISOly3FeRrQXLmDyj503FhE2mcJhZmMVff3Vk2zOBqH0FlFw7Uze9/6sXAvAltPoLgIT9ddOGol8vpOPeqNbpQfDM7MRmzhKi+73qnH3MtyAKxLzZb0G7D2/tKyfgHnE0TxUwY391MvtYDunxV6qcKYmMYUaDBpgf9mSGfmA2koqJw/kECV7ZLVYSJNAYiAjZmHwFiTs9aHwqy42Y2xPCJi6lqaAV5r0toxB9sgtnDen1vmjrLnq4GkKOYyZ449q1XhtO1D83jsNYMIhT1iWKcvaMA4AXPcJ42YjFU0qe1ktVa11ffkOKAGjLbvMYOxgKwGssDVGVxedSEKBM3I2/HjRquBjqjM2JOSZxJ5NYfYslmcYKKNvovdhUFzpIJ3wbhEXhew43IzcnRW8ZUckQgas3BYZKWQw0YzzKk1eLtkixma+5fsuot+1DFD7RRlXtpX8bvyHenG5cnZcacbAhyxGeJXwtIj70mUex08+YmhEA/Hqp5FKdkEUdRGFbnWU5dYEDKWoDiRo7M5k=\",\"PublicKey\":\"MIIBCgKCAQEAzK7wuJODIGDe2zFmZx6zRIbohlGx/TqglzC3S24yJEhisoJBnLq389PdGRHuHz8JHarDOppcspoov1dp80F1sjSIlS6HcZy6gTM40SPa/eGDEx5FwSp6E+ZGytP6SLKIJgHnCIWPu9Xo5IedPD04uPenZA0ZRQufaOt8/l4qxsKUCwfdEiLTgw9o5JNywFyoR4tSB+xLSv+p/QTSW/22E3IFJnlWnyWfLx1EBpQImR/js8Lt9seBhSRmXoWaw3DcVZyr9dA24HlJn0cuPJZ+5eO8AfbsHFsFU0t5gZYZjibIsCtxzxrgW2GfBY43DaKS0hrdqA/ZKNHKvZlv9SIVMQIDAQAB\"}");
            _users.Add("bob", "{\"Id\":\"98cdfb87-70f9-4b86-b22e-91f866e7b247\",\"Username\":\"bob\",\"PasswordHash\":\"iiHYBmnhrX/Eqpcgkco6cPIM/s7\\u002BUH2kzCFMnaCUEypL4rz4qT\\u002B0UnXwtCOCMw7o\",\"EncryptedPrivateKey\":\"MIIFNTBfBgkqhkiG9w0BBQ0wUjAxBgkqhkiG9w0BBQwwJAQQ9XzcP22mSaVsDrHbGDvbOgICA+gwDAYIKoZIhvcNAgkFADAdBglghkgBZQMEAQIEEGTY+RaKGOBDYdzPXsY9IUIEggTQDs30aF+x5PA44AhcOuw4JigBeQAyBkuYIZa79SeqGBHczVyWyS24dDfpQrBKfG/u46ZmZQMtnKXM6ysuuPqou49PVAE1EAmaFE/U44h+51HATwV4pufVNMEQAwwwzVb/6KZcSHt67N/9WYL4hSlCM45ly/OQfZ/dq72EFQJ4XFBpDtRJZRbi/xlPgU1/+Lll6yA63oS+nU/kukGOdRTGseyI54O2mOk9VRgwZ3Gk1sSfOe/2H8JC/mRgYAElE1amyudAGXuTcY0MHHrMofz+QvfCbtVGiE+xF5dxQI+XyIf+iS5N14pP9tEjE/tD7/rxLegjyOCxpmIQ/zZR5ls3uCSeDYQMRXIuIZchILOWhmUMg3rowjN5QgUCZhFKMVTBkYCLYLUEfSXhXHzrw1/YjhowYzYuBBBO8It09ev+9Q0t8PSbBUmvyQPyriE3rJo62UsVe4tomNTCX3ecN4W6TPvoabWfOLKSTey0tuig5dVCJmhP2au6M7BbxD14Hegpr3T2xvj7I4P9AB+rdxMjUf1x8QWrMRZBgw/FGpfA4oRVarA1qlTAhhYNpAWgEcKsOheFvye1k/N/Gw2g5UrJCAHPCtTS9S5v3mZ/tIFob319iuMoPncXr/J3bq1YxDi7C1mGdYfeC4qTS/2JcaUuUL85WJ5pdO4xY7CI2PRQMvz3dfzuVdQM9oTOf4txxqSjrIg/t9owqNK9kvqnlFWESPdI6GB4kDtxR2mHtu6fF+vkfF9ku9bMUTOR5C86TVAVSidZoOCpSJS1/LGTcm/cDoPPcRKhl/ICy5ND9zuxPD3znbExr3xJpV0TC/kuX4r4QtekXJvhVOqafpBky+5pLxydJduk+lK4337nv1GjvEQn02eadyO1BgG/zKdSuNfJUJNUOOO6ezNTMVaP6kMQ6m7jbXu8QhBRLI74VdvwAh2+0Kmr+tAbn2JzG39Xw0qSwuNB1pQKnmNtOEWNHldMu02nbSGJD1RTgYjBkQK7RI+v7dhRuMfazY8+HHacIotNumwl1m8/davttuMK4Ee+TXh66pS+P/Ic/WRHWfQkoltEk7eZOK/rwa/Y3k2JKZlXqBAkBeyGFaBlJ/nzmLETIga2mIJF1jY7h+dMDERyqGD7Fy/5YI9OSjMqnctQuTakUg8eW0bLNpH5SWTl74SKOjBijRX9bob2ZmXWW07McPRaJ0PUwaSJXRbPwPGzrmuGNp2rFfuVwpH5MWsmIKO2qQGQ0Eik90gSImYWXjGuBUJJMR3D5CAqHmfJ/aBkNVD0CpRCAlCdNXNar/siOEn4h6E2IndFytw7mFoULu6/OW97nQLe6uk4PlTjL2N7klaLV1tXFLy/kXSHLkzbMNEhR6ZSuXu3qfCgPNGktUAnG/VntdjwPX3u6Xg5mY0x4so/y4O8JWNRi4ly4zKoQO7BkmF//J5v2c/gq1y3MFoV005SRaYCeWgPV+L+zalN+zzxfrhQUVxTwI4VbGyWhshM4hwEvlOyGbr0O2Eg4xNB2ldY0mofW5R77/OZl3riEenaJY5z0/ywPNXP1boV5MS3o5zgxqKoFcr0ZFoqYqBIbnstoLwmFLFaMgmXxhik997K+c3hN3FuIESzK6qT4mzjr5zc4jTvlzDDOD9R1onFZzM=\",\"PublicKey\":\"MIIBCgKCAQEA0+tpitrwoyzgR2hHSJu60JDdWmLy+QiVfnjNo7TfYWd4R7BkBOsIKStW/B78xgu7ePTbMJWnafOgkIET0F3Sr8aRKPUuqxxVd1N04MN9vTZlB7gQmXPa7IiPgN4LAsyy12gLtYBafArvR/tDRXovav/+By644kFVtDdufwEjj5YGW2ME8tDIDxiKd16bpdgzmMRdQWt5CrTjcVmayHJxrhed1C9nuzhdk2SaMZv6nfuP2VJz7ir7jWhYdxIMHs64x8fSe4TJSU6C2a1L58sL+kQxlYXx9xUUG2jRaZ/ODS4DBZwHcstP6+l1OqP2mc2esWlSz45DQfofsfRR4WESkQIDAQAB\"}");
        }

        public void AddUser(ApplicationUser user)
        {
            string serializedUser = JsonSerializer.Serialize(user);
            _users.Add(user.Username, serializedUser);
        }

        public ApplicationUser? GetUser(string username)
        {
            string userJson = _users.SingleOrDefault(x => x.Key == username).Value;
            if (userJson != null)
            {
                return JsonSerializer.Deserialize<ApplicationUser>(userJson);
            }
            return null;
        }

        public void RemoveUser(string username)
        {
            _users.Remove(username);
        }

        public void UpdateUser(ApplicationUser newUser)
        {
            string userJson = _users.SingleOrDefault(k => k.Key == newUser.Username).Value;
            if (userJson != null)
            {
                ApplicationUser? oldUser = JsonSerializer.Deserialize<ApplicationUser>(userJson);
                if (oldUser != null)
                {
                    oldUser.Username = newUser.Username;
                    oldUser.EncryptedPrivateKey = newUser.EncryptedPrivateKey;
                    oldUser.PublicKey = newUser.PublicKey;
                }
                string serializedUser = JsonSerializer.Serialize(oldUser);
                _users[newUser.Username] = serializedUser;
            }
        }
    }
}
