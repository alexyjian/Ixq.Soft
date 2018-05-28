using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixq.Soft.Core.Domain;

namespace Ixq.Soft.Core.Repository
{
    public interface IRepository<TEntity> : IRepository<TEntity, int>
        where TEntity : class, IEntityBase<int>
    {
    }

    public interface IRepository<TEntity, TKey>
        where TEntity : class, IEntityBase<TKey>
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }
        TEntity GetById(params object[] keyValues);
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        TEntity Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        int Save();
        Task<int> SaveAsync();
        IQueryable<TEntity> SqlQuery(string sql, params object[] parameters);
    }
}