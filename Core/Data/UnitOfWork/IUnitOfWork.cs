
using Data.Entity;
using Data.Repository;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}
