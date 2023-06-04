namespace Data.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IQueryable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> Find(Func<TEntity, bool> predicate);

        Task<TEntity?> GetById(Guid id);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(Guid id);
    }
}
