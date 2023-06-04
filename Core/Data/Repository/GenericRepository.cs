using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            this._context = context;
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return await (Task.FromResult(this._context.Set<TEntity>().AsNoTracking()));
        }

        public async Task<IEnumerable<TEntity>> Find(Func<TEntity, bool> predicate)
        {
            return await Task.FromResult(this._context.Set<TEntity>().AsNoTracking().Where(predicate));
        }

        public async Task<TEntity> GetById(Guid id)
        {
            var entity = await this._context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

            return entity;
        }


        public async Task Create(TEntity entity)
        {
            await this._context.Set<TEntity>().AddAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            await Task.FromResult(this._context.Set<TEntity>().Update(entity));
        }

        public async Task Delete(Guid id)
        {
            var entity = await this.GetById(id);
            this._context.Set<TEntity>().Remove(entity);
        }
    }
}
