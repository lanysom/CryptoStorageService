namespace StorageProvider
{
    public static class DaoFactory
    {
        public static IDao<TEntity> Create<TEntity>()
        {
            var dao = new EncryptedUserDao() as IDao<TEntity>;
            if (dao == null)
                throw new Exception("Could not instantiate dao");
            return dao;
        }
    }
}
