using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixq.Soft.Core.Domain;
using Ixq.Soft.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ixq.Soft.EntityFrameworkCore
{
    public class EfCoreRepository<TEntity> : EfCoreRepository<TEntity, int>
        where TEntity : class, IEntityBase<int>
    {
        public EfCoreRepository(IDbContextUow dbContext) : base(dbContext)
        {
        }
    }

    public class EfCoreRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntityBase<TKey>
    {
        private readonly IDbContextUow _dbContext;
        private readonly DbSet<TEntity> _entities;

        public EfCoreRepository(IDbContextUow dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
        }

        public TEntity GetById(params object[] keyValues)
        {
            return _entities.Find(keyValues);
        }

        public TEntity Add(TEntity entity)
        {
            return _entities.Add(entity).Entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            return _entities.Update(entity).Entity;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }

        public TEntity Remove(TEntity entity)
        {
            return _entities.Remove(entity).Entity;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public IQueryable<TEntity> SqlQuery(string sql)
        {
            return _entities.FromSql(sql);
        }

        public IQueryable<TEntity> SqlQuery(string sql, params object[] parameters)
        {
            return _entities.FromSql(sql, parameters);
        }

        public Task<int> SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> Table => _entities;
        public IQueryable<TEntity> TableNoTracking => _entities.AsNoTracking();
    }
}