namespace StorageProvider
{
    public class EncryptedUserDao : IDao<EncryptedUser>
    {
        private static readonly List<EncryptedUser> users = new();

        static EncryptedUserDao()
        {
            //users.Add(new()
            //{
            //    Id = Guid.Parse("a17fe0b4fb944a42b36b0065393652d1"),
            //    EncryptedKey = "",
            //    EncryptedData = ""
            //});
            //users.Add(new()
            //{
            //    Id = Guid.Parse("3bfb34b3863a4372bbf5722bae660249"),
            //    EncryptedKey = "",
            //    EncryptedData = ""
            //}); 
        }

        public void Create(EncryptedUser entity)
        {
            EncryptedUser? user = users.Find(u => u.Id == entity.Id);
            if (user == null)
            {
                users.Add(entity);
            }
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
            updateUser.EncryptedData = entity.EncryptedData;
            updateUser.EncryptedKey = entity.EncryptedKey;
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
