namespace StorageProvider
{
    public interface IDao<TEntity>
    {
        void Create(TEntity entity);
        TEntity? Read(Guid id);
        bool Update(TEntity entity);
        bool Delete(Guid id);
    }
}