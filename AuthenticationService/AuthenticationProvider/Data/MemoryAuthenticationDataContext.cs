using Authentication.Model;

namespace AuthenticationService.AuthenticationProvider.Data
{
    public class MemoryAuthenticationDataContext : IAuthenticationDataContext
    {
        private static List<ApplicationUser> _users = new();

        //static MemoryAuthenticationDataContext()
        //{
        //    _users.Add(new()
        //    {
        //        Id = Guid.Parse("3bfb34b3863a4372bbf5722bae660249"),
        //        Username = "bob",
        //        PasswordHash = "DSk+N4JZfCMv4LOn02gSAgNcnkkm13Bbz+xTzAL3PvCksGs5EFH/1vyNaCcL80U9",
        //        EncryptedPrivateKey = "MIIEowIBAAKCAQEAx2LtYa393qi62EnFXTmcxwnBD2YWHPY6K6WBWP5mcUBzfM6ATfzfQ9fZKJTqcTGMNI4s+Rhie7q/0yzTuprDVJRSouP1jzYViGw3V9uHnTDvh4rvukpqk4LRpEf33rpfPFBl+CDpSDXUlTywv35D5BaHrRjfKvdGkGVLdoUQj3B8bOkk/kiDAE1Cs4OGZnXktIQ+LvC4Ndrg7xvDcTe6qFTRVyHk6Vij90iyHRBbB1JfPt0MiWr2laB8K5x4NV+jmlPEJeC1t1aOVmeOVgvSApFnCi5bHUhevzQK2mc8bVmKV+BloFBaCg68XsQYpjTOuYqosYG/1u2aRIBSqSk7iQIDAQABAoIBAQCW6/vxLyl2C9P6ecSp7z0LsAdxp31fiMW5WfrRqSdT3ExOkWSvI5TAHrdir23SJoYRFflWx61sKIygxVKy8giekfMHF3Q9ZdvgusEdgK9jPbJhr7oMEd4gMCqNpmgqMHp8BgNZUVgjb5OtLxY+rM2o7aDfVm8+b5P7IqF/YfOKDmxxOYHew7x8kpTZd4TP8Egqdek3Ib/t4gyrNURtn3RFsujpUqgT5wcxdTOwjGwPkTmfedEM3htRopo4GDqmplzKghqtLrRgPdafZ8zviXddFK4FE+AaC/qwDdeW30SRltRbqNaYRy3/eg5rfMUBw+9yxy+4WCOG+L1xJ9hTsHjdAoGBAMxhQmrI8mQb11ksElDbWQEnWrXh44PA14UqwqY+PRj9fqL8JzNMxJhGpV+vepDLMjyQwqeCSDcIJA/foiSaLa/3PZ8CIcLGPBPIN5X9ZPWpgnuXaV5jurbBb6T/nfnx8jLcFffuE+C0goG1CS6H+jQU9ko6WiKucr7Ba2u+EmkLAoGBAPm+zOpAdExgQxq0LV9DoieZlAG+iFNFzz/aKC75AYGEKERZN3JwNQ4BK/J1WJUjTT+E06AJDf3TlmbtG+HCe39tUbPBZNkNMkj8qZpQX0dyhoKTnfOoegQ4fdwoJh3XwUpk00HE2KwkRO+/3jMsY8oXL+0pnjbv6JBQGAQ6QNI7AoGAG2ffVBpmBm6FTfvO6PDA2prAWytTKtOtErpNJ6Wo47T6SjituP9OTW0Lt+z77naQ4fY3Y+bgcCCzVT2TrHzQK4xnwu6yQD/8xlpOudoks5xrVs9S3clZvC/sHJ/6Ow3qgE9q0rgmCjeqWGJCPO8W6ez1qbZxZ70kvdeJ5AS0y0kCgYAaqfFMzUbdZKWlczko45qraa0wpnv9kAV5hrwlj7ZGcqqt6WyPDkXL0fo0L60edx9nObIycuUIhY+YO5ZvewkeaLiBXZN7zPniav9cl1ok0ahkxoflnMYyLynY2HyBUSi03aDkc7TCZDjr8+swQXwB9onKY1gd+200AykdQm7rQwKBgBCYm/sQnV6N+Oecip2kRWkMluhI3uit7hT4bYwaoNkDujB5gri3AUx9Yh7eZ5dagKqaL52XUqBXbcH7Y9UugNw4JKV3KrqMaUhv3wdiFhmrgj3rky+blRbOzH9PQqY6GcLupL/NkFbprFb9bCy1a2U5gaOBbkjgUWBY0BfPq3SR",
        //        EncryptedPublicKey = "MIIBCgKCAQEAx2LtYa393qi62EnFXTmcxwnBD2YWHPY6K6WBWP5mcUBzfM6ATfzfQ9fZKJTqcTGMNI4s+Rhie7q/0yzTuprDVJRSouP1jzYViGw3V9uHnTDvh4rvukpqk4LRpEf33rpfPFBl+CDpSDXUlTywv35D5BaHrRjfKvdGkGVLdoUQj3B8bOkk/kiDAE1Cs4OGZnXktIQ+LvC4Ndrg7xvDcTe6qFTRVyHk6Vij90iyHRBbB1JfPt0MiWr2laB8K5x4NV+jmlPEJeC1t1aOVmeOVgvSApFnCi5bHUhevzQK2mc8bVmKV+BloFBaCg68XsQYpjTOuYqosYG/1u2aRIBSqSk7iQIDAQAB"
        //    });
        //    _users.Add(new()
        //    {
        //        Id = Guid.Parse("a17fe0b4fb944a42b36b0065393652d1"),
        //        Username = "alice", 
        //        PasswordHash = "FE5KSGfTEr2KjhWGJBHEa8SJbnNEy0MctZroMnwO95WUwfUIobMGJHx+Z5guYWgG", 
        //        EncryptedPrivateKey = "MIIEogIBAAKCAQEA3lx3COXsOT0NdnErf8hud3WDnni2M5kFefb2xw+N2wprLPvTXOCnye3COUCphTsetnXCZpXA3h+N3GpxfynLT2+DKs5clwjAIYmeiAoGOzh4Q09+Matwo1Hen2ziCMHtumuIO9XBwiqQX8ERpwzpYKyqeKIdZKHamPU7Jgj+gfML1TQ4Nsl1xpGwCk18Q85/Km4gwf6NIrrNviIplOCN3emAmqUBsqLGAifUyAoRj0br5A3M+q0h7I3oflu80xtlS+qbeqpignM6sgkTG9C7sOFp2LvP7oKe+cHN8pPt6dos2HSZ+sGq86MRq6t3h9ZARus9Bp9tNR5TSvlajeoUTQIDAQABAoIBAGSCGQ/9lXv927L4znew6jW2+WpNF9ZUyYPqnHs3zZ//opgvr8cgiNceUBc+4iElqulAa0GhWQ9N5fqGZozbIFnkhr53jqR6QRYntW+6UDy+dqW+LcVXv88it2UKe1UIC2OjLW4WXcFdKesOQuNmU6ruARQL+ws8malf13+GuzuS/8FKnbmWkUGHu1naJRBLSK8g+3LvGgR984UAHlviDC/MBcZLjYpZgoq/HXgEcLX0PVHoLaMeFDH/a3zwcFeCORevOSBndlIz74cpeIDco1esG7ZwRjoD8l7XSWc92QqmSjdhoN9kLO731fri9pq8QK51LATPIFdBKXfauTR65wUCgYEA8w1MLsqj986+2Y6vmJWYQyyScIiyTyfTLEl4+v+tERuyjWxk/vOfQ6afR802IMP1VhQdgjsXpTRVJIktp9sy5fPdKF42vc3uoIlYCuh/sTx8Py8gu9j3U5153HtuU6ZqOllZ86M0kCxQFIFKBiiMlzXUiR1i60Fn4QPj6UWyItMCgYEA6jT9hUA+LvQ6iI2zNbKDNU7PXl4+9/DUHfpNh/mXSKYtrBSqxkvyKDqGMIkv77OxK9f2cvB/7nbOPaRGXQIMh3NtbbjHeyzG410qVUZlkExaa+DjahGi73SRXOxdKL0ara8B91nvmkEo/4tjB1sHS5/AQN6stpP9guwBOElrOF8CgYAjrzIeNJY6Tdpraq2RQ3Vld2fQqeE0Ce7RM8BVabBpMJ3Yca+qVu5tKkt8aT6nNN4SU0W51x8znClcAd/4IxCn/lPcF2kGGPQOEdwhTd1hkjXTuQGfUs2NMzOvEVgzY914z6GLSczv1fGz8P+DQ/TQRpD7yJq7W5D60m1l1FvBDQKBgAsQZcmdt1JQh1NcHlMzE6+5AWLb4O2lmt+vq2n5CISOFSpD761eeRodaalxUappOr1vflz/r4t8YVHYKNrL9fuQIGNGj2XqP5sOE6njoXinor3l6dhg7OmTACr7n4sFI/WAhv9AaGlJGr63vv3h9v5Dlbl6y330j81XiNc34LDRAoGACCxNK+a9LWmXYgBXTTEWA6C+kERnxucEfMoAeWM/9hBWLJx8Pw47mKqyGpmctPH6HODe9+37dzFjfRovdw7BqtTZHkAGfWre166TTxfnPUmzDmmEGbqchf+qsFbd1HmkEfDH1Uni7I6mzl5Tfp63eIM9ZhIBOGlNuZPT7FMxfBg=",
        //        EncryptedPublicKey = "MIIBCgKCAQEA3lx3COXsOT0NdnErf8hud3WDnni2M5kFefb2xw+N2wprLPvTXOCnye3COUCphTsetnXCZpXA3h+N3GpxfynLT2+DKs5clwjAIYmeiAoGOzh4Q09+Matwo1Hen2ziCMHtumuIO9XBwiqQX8ERpwzpYKyqeKIdZKHamPU7Jgj+gfML1TQ4Nsl1xpGwCk18Q85/Km4gwf6NIrrNviIplOCN3emAmqUBsqLGAifUyAoRj0br5A3M+q0h7I3oflu80xtlS+qbeqpignM6sgkTG9C7sOFp2LvP7oKe+cHN8pPt6dos2HSZ+sGq86MRq6t3h9ZARus9Bp9tNR5TSvlajeoUTQIDAQAB"
        //    });
        //}

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
