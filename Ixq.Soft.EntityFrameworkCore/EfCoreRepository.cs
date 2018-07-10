using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixq.Soft.Core.Domain;
using Ixq.Soft.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ixq.Soft.EntityFrameworkCore
{
    /// <summary>
    /// 基于 ef core 实现的仓储。
    /// </summary>
    /// <typeparam name="TEntity">实体类型。</typeparam>
    public class EfCoreRepository<TEntity> : EfCoreRepository<TEntity, int>
        where TEntity : class, IEntityBase<int>
    {
        public EfCoreRepository(IDbContextUow dbContext) : base(dbContext)
        {
        }
    }

    /// <summary>
    /// 基于 ef core 实现的仓储。
    /// </summary>
    /// <typeparam name="TEntity">实体类型。</typeparam>
    /// <typeparam name="TKey">实体主键。</typeparam>
    public class EfCoreRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntityBase<TKey>
    {
        private readonly IDbContextUow _dbContext;
        private readonly DbSet<TEntity> _entities;

        public EfCoreRepository(IDbContextUow uow)
        {
            UnitOfWork = uow ?? throw new ArgumentNullException(nameof(uow));
            DbContextUow = uow;
            _dbContext = uow;
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


        protected IDbContextUow DbContextUow { get; }
        public IUnitOfWork UnitOfWork { get; }
        public IQueryable<TEntity> Table => _entities;
        public IQueryable<TEntity> TableNoTracking => _entities.AsNoTracking();
    }
}