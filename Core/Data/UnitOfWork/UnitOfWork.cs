﻿
using Data.Entity;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _context;

        private readonly IDictionary<string, IRepository<BaseEntity>> _repositories;

        private bool _disposed = false;

        public UnitOfWork(DbContext context)
        {
            this._context = context;
            this._repositories = new Dictionary<string, IRepository<BaseEntity>>();
        }

        public async Task SaveAsync()
        {
            using TransactionScope tScope = new();
           
            foreach (var item in this._context.ChangeTracker.Entries<IEntity>())
            {
                if(item.State == EntityState.Added)
                {
                   item.Entity.CreatedAt = DateTime.Now;
                }
                else if(item.State == EntityState.Modified)
                {
                    item.Entity.ModifiedAt = DateTime.Now;
                }
                else if(item.State == EntityState.Deleted)
                {
                    item.State = EntityState.Modified;
                    item.Entity.IsDeleted = true;
                }
            }

            await Task.FromResult(_context.SaveChanges());
            tScope.Complete();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            var repository = this._repositories.FirstOrDefault(e => e.Key == typeof(TEntity).Name).Value;

            if(repository is null)
            {
                var value = new GenericRepository<TEntity>(this._context);
                this._repositories.Add(typeof(TEntity).Name, value as IRepository<BaseEntity>);
                return value;
            }
            
            return repository as IRepository<TEntity>;
        }
    }
}
