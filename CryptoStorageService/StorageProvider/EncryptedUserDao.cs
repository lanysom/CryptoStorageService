namespace StorageProvider
{
    public class EncryptedUserDao : IDao<CryptoData>
    {
        private static readonly List<CryptoData> users = new();

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

        public void Create(CryptoData entity)
        {
            CryptoData? user = users.Find(u => u.Id == entity.Id);
            if (user == null)
            {
                users.Add(entity);
            }
        }

        public CryptoData? Read(Guid id)
        {
            return users.Find(u => u.Id == id);
        }

        public bool Update(CryptoData entity)
        {
            CryptoData? updateUser = users.Find(u => u.Id == entity.Id);
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
            CryptoData? deleteUser = users.Find(u => u.Id == id);
            if (deleteUser == null)
            {
                return false;
            }
            users.Remove(deleteUser);
            return true;
        }
    }
}
