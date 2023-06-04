
using Data.Entity;
using Data.Repository;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}
