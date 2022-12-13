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
                PasswordHash = "ZbH5D/nVTwgKc21FaDxpig8G91fdOsD0yN5OJ4tVRvQPFSzDnV2uNI0QvLyE41Na",
                EncryptedPrivateKey = "MIIEpQIBAAKCAQEAxIiTBKaRmGeVr4/Flf5VkwZexTLvzVi2YimTVAzzkcNof7PnGaFOksgFiarvTsBZpt/XmjTAXAjDl3/cn5kx8cvyKZg6TDjI4IBlqxsX5OYoH0AHOizUOWKujbiBie+kSTgDMlPI72qKUp3xXN80FFJvezuH1/JwFR4HqdC7YgnbOb5L5WJPtBA7edNj4EGB7m4dGvJs3dvoXfUaGxPuy0imy50Bi4NLV6jcM3DMqdEgAs+FuaCg8bUiFhNRTRTkKcp23yNcNgsW7rw66RknVDCwojLIPPmBSELJOFIIiljoqnSPOy7gdiADJlbPtM8nIcn/RNiA030AlEmffWmeZQIDAQABAoIBAQCAWjWx9trlbtkKVFoVUIowwBtKrK6CLKrIRyDJ5r939eecZzDJw1hecjVzqGgrxWGHo27abhMmyC59FetPbCx7HtfjpGCGgRtny1MawVIEku+nIRjXPInJhJI9Sj+HhzODAgrMZn23Jpx5wl7saXVIxGG8WK+qL9JVaExW8lQ+fM5lwRXVxmiZ132OWa81AfKrq6h6vb1k90bP5qaNx5W9m7QaMGteZgSAPGocGDaU4qPzMdAg1UD8kfzRNzI+A1pZqCZePcVP/mEGL7iQxdWDL4/VjtWUmq6KMZmls30eplrG5/xT4AvIQ4unJUQe4Ae1IquZbObPRGpY5dEhpRftAoGBAN0qS4s5QkNomRqHLqFwIe8bDki54cFLlIRc9WVFdZB1Zj0E7lcuAYnxvgSVniuPuZlnushFBdVHDUSEkV5OlmtJ07LaXo27rPlLYxuEExo1dkbdyy1HbA2I2oeYwgkIJW7FP67cNmim00rMhCr2BESClQdniWeCV59VG+lZnYGnAoGBAON9F5cRdOme1hhm1RP7KSCcj5mtdhYJuALqoGNERPiI60j1RDiledfNU4dQ9nt8Wu23VNy7rr5s5PLocZ4shYQMMRHqP1ht2EyJ/VAskKOi0mQ74Wq+C7UwOqzADSe1C03XrC5xqlyqVYfnvpZLP1XJzvqacUelZsGgHs/tiOkTAoGBAIpViirrBadkJV+SbnhLyu3j3mte2PYucBbajiNp7r8Mr4Y7L1kYTZ4att/nNafJni111D6v7ZYZexMAWGzEexFgfCnCrKG6YdcMcFElq00ZY4Gv+QW5RrywfP+TbMp5bfB7L/oPg3ix4DdI9OJqPwEbLFwVRryXqnbepTav9vTBAoGADkwzalw/g9tmy1vTMpFLkXAlmlwLmvD7brt+Xx7QUuqQFyLLKeBEmyqdgFi3VSWItX4bSFBHeFJxxU6UrYNQ1O7LOrwFRTKKMK1PjXVvlclK/d/BmCrfo4Cnf2oGqaM4VakjejvMoExYWdVX5ixOi77GUnvYeM9NeQfuR9U/EJ8CgYEAo9NAMhKEZv89X1aKxOFeMo/uCKqANjQg3jVnjdTOyt+JVJIOLRHyfqEhLmY4vLFo0gIs+fq50XLgfQPCfCP3LT4IwGzL5DQoMgtBSUesZP+oBWHan7uBoKeaL9tLOH9gH+ZHJjeFUxPqaBHiPQ2sw9Ruz3WPmcC4Rm17Ik2kxpU=",
                PublicKey = "MIIBCgKCAQEAxIiTBKaRmGeVr4/Flf5VkwZexTLvzVi2YimTVAzzkcNof7PnGaFOksgFiarvTsBZpt/XmjTAXAjDl3/cn5kx8cvyKZg6TDjI4IBlqxsX5OYoH0AHOizUOWKujbiBie+kSTgDMlPI72qKUp3xXN80FFJvezuH1/JwFR4HqdC7YgnbOb5L5WJPtBA7edNj4EGB7m4dGvJs3dvoXfUaGxPuy0imy50Bi4NLV6jcM3DMqdEgAs+FuaCg8bUiFhNRTRTkKcp23yNcNgsW7rw66RknVDCwojLIPPmBSELJOFIIiljoqnSPOy7gdiADJlbPtM8nIcn/RNiA030AlEmffWmeZQIDAQAB"
            });
            _users.Add(new()
            {
                Id = Guid.Parse("3bf79df3d19046128d42f086cf44056f"),
                Username = "alice",
                PasswordHash = "RkLqGpvrtJ40ZdO3O5JL5tv/UBo6LB1w92MHQztx8JEHvj8Pz9IIMz5R/xENn0S/",
                EncryptedPrivateKey = "MIIEowIBAAKCAQEA0Ia1iRgz0SvVNep5qUsXomubcItTTW2/p9iheiPdtO6KpfpC+GcnPslFlEewTqPf3ThgLjMxQ2h1RpZ4ihEc2/0JbcrwHnf25rZIYLdZ+hJg2ybVHxucE8eMnFUBH8NW2pvCO1k6Kq7jgZuogO790hiFdBHunCfKshegPy3gPL9xKhO8WiSoCzaKB88VjrEzrY7vggwAlEzcKuxFrEDJdj+UF4emWJeV+PeRHPf9vbwSyjZbL661+/vD9uNjHrt2cqmpaosqTTvDSZjQmzWYdfl6heeHVJSeumFLG5ZqNyNsFhLnEFc4f2DGQ3BXuGwsF7Oj0vvju/2G9woUUP1EiQIDAQABAoIBAEe7Dxdpy+lYOq+hSNiDjE3C1mWQh8dKyXLjgiiRzeI/bFJMFF1+nnFqqxSm1G84z/k5O1ypH3kgpbbya+SSnmrOUEAEXzUb70LN0Xfzmm/7gnXglc9tn/Lt4eClHQ3gFDB/BAGGYAvuvTQIZ55yl7190eprgLkWtxMsLWOOVGSQlzuBlFX+5qvUjBPSeeKT+kmXWtwyHMYeOF0m9coNlOjbRsbsEAdcjqVhe1qY7WwCaUaC12gZLmyPhpgXfWu9BFWerIG1BIHFsyLNKdH3ODlbSySJxUoLa8dfeLWHie9FM4BBm7RfAZ+6Wg5o2dDxEL3xG/7NTHJJhx4qVXyHwUECgYEA3pdBn2aSDNCdfAy/b6k3rBiHcZF+yVcUXux8+lhh6I6XCwf5sayBH/eSO9tksnIImyIrC4UOKlX52r51vXrLVKinp6FAGrwFOVFx3VAP+yalQWs5UxJ2vG0w03xoNXolTD29zBqwJatoT+4rvWugYSd+dGMTNwsE7qJ3M8TymlcCgYEA79MJ5Lk2taI3CMxiKTNDDvfZeVtrUdqezCZHG4gop/aOA1AFnCaVwb9w8+pQ4vM4Z2KAV7fiPi8GPFj48KQu0FzHTBfD/sZVAcmi5pXPMknWn/EzFsgDeRJgQCZaudbNZnXMhVyMepY98CWh5cV+60pN9sBKqLLm3Ujt3KdTjB8CgYBjdslvFiFrMok81mFw3veuoiNb3zz9cTj8FcbfA0F07sqVtlGgUEo+45znvGipyIUJ9WGwuxsSVerZEUSBj+5t/RM1t7tydtQKwdcUouMRQjqUGfq6oUSHfG9WAYB7bQJfqDM4kjBmFMr+9Jl9AivfXguGrIL4lKb2j4iejIIv7wKBgQDbKO5XmHJIlg7Y+X2SzQew/Ao+/q4aRUDsquY8YLdWlte8azpVMmWUgtBD9pMocr/OqpNClgYocWyvZVdJAaDORJrUDLvNbY1tbshxE+IewJ9j1lWrseiKkaJnvSUXwxY9VdUq4iJ2PCop9Rn4Ef0kI+kPXzZa5/JVsjm8dSTCXQKBgGSePv0YdTYPjP8pe53+1MlOUw6G3Mlov4YsUaDAELesludHZN31GORpQo+iDka7pB0fH7vXdUCqck01WDbNSWcIuDR/Tt83oORNIFAM/ZSbLeh9FYxf57zcsIN9uJjB21aRPvCTBau7RudRmdXYJLuh32M5VDRpgj+AOimQCHQJ",
                PublicKey = "MIIBCgKCAQEA0Ia1iRgz0SvVNep5qUsXomubcItTTW2/p9iheiPdtO6KpfpC+GcnPslFlEewTqPf3ThgLjMxQ2h1RpZ4ihEc2/0JbcrwHnf25rZIYLdZ+hJg2ybVHxucE8eMnFUBH8NW2pvCO1k6Kq7jgZuogO790hiFdBHunCfKshegPy3gPL9xKhO8WiSoCzaKB88VjrEzrY7vggwAlEzcKuxFrEDJdj+UF4emWJeV+PeRHPf9vbwSyjZbL661+/vD9uNjHrt2cqmpaosqTTvDSZjQmzWYdfl6heeHVJSeumFLG5ZqNyNsFhLnEFc4f2DGQ3BXuGwsF7Oj0vvju/2G9woUUP1EiQIDAQAB"
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
                oldUser.PublicKey = newUser.PublicKey;
            }
        }
    }
}
