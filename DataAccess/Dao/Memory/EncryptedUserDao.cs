using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao.Memory
{
    public class EncryptedUserDao : IDao<EncryptedUser>
    {
        private static readonly List<EncryptedUser> users = new();

        static EncryptedUserDao()
        {
            users.Add(new()
            {
                Id = Guid.Parse("a17fe0b4fb944a42b36b0065393652d1"),
                EncryptedKey = "MxQOl4iDn37tZ1LBVjh7zaHX3fer8DzP3W0N0WckT6k0QU/+D7iQ/BIUjm0+PIszKOUXiB0h64mKwKkNYvE95Z+oEIPU9mDI/NgJBLtPlbSknh4fShKg4Xhmvtu246tof/jwbWG2lI29WkrOy0kd8vvhOwVzf0svYExndwrF1UVATOIkxzdfuhdMwPaQ3odDi7W93beU+suEqNIaSdE386qQhy4lr8MZDemvyeoyUTO/4Y5JfGPJNi/WQpeSn55L1rPKiEae7AkwiBV9wo7cI46K6tpyj4SOXwU9tAL/cxqw2B8YulFDY/lz9mbYgkct9UxObFs7/NPF4jVeVoXdRw==",
                EncryptedData = "pL4P2gmTy+9Ow8sAVCGp7YwZ3T64jWD2DNMh6u1YHRZNvRfNMgE0w9YVlP5YMXbY"
            });
            users.Add(new()
            {
                Id = Guid.Parse("3bfb34b3863a4372bbf5722bae660249"),
                EncryptedKey = "PDEUBPEbeoYE85NL3EMcDLsxPs2cuEJQkQ5Tw1sAzFnTnZEoJvgvRsvpCr6nV5MZScYPMTLu7j73/L+P9/GXrfa6W9g/clSBqDdV6oSk4qGFIqyacCG1x8OpNN7Yx//2Ik1kDn6XaFfgFYG2WZIfhxHBVf196hQThEMi1OlwnciuWT41D9aw3TUlHMin1U6XzqsSFqdoobcNcj1aA8WYqm12lk68w2WVjCyVAjMJ29NUbOLRZNsftWxRVAKj3nHdYxUXPMSskf9+Xi7pOvUlE9Gw+JD8cT9673azzMp994fJU+zzD/20klWZuE0/wEnNxHEtCEWQVQMeARZQtGpTZw==",
                EncryptedData = "ZxX/zsehfivBVbgEVQpWtayDqJ3mseEd3vIBaILbrHP+tr/rj3W+aZsxsqkX0mrB"
            }); 
        }

        public void Create(EncryptedUser entity)
        {
            users.Add(entity);
        }

        public EncryptedUser? Read(Guid id)
        {
            return users.Find(u => u.Id == id);
        }

        public bool Update(EncryptedUser entity)
        {
            EncryptedUser? updateUser = users.Find(u => u.Id == entity.Id);
            if (updateUser == null)
            {
                return false;
            }
            return true;
        }

        public bool Delete(Guid id)
        {
            EncryptedUser? deleteUser = users.Find(u => u.Id == id);
            if (deleteUser == null)
            {
                return false;
            }
            users.Remove(deleteUser);
            return true;
        }
    }
}
