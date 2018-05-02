using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixq.Soft.Core.Domain;

namespace Ixq.Soft.Repository
{
    public interface IRepositoryGuid<TEntity> : IRepository<TEntity, Guid> where TEntity : class, IEntityBase<Guid>
    {
    }

    public interface IRepositoryInt64<TEntity> : IRepository<TEntity, long> where TEntity : class, IEntityBase<long>
    {
    }

    public interface IRepositoryInt32<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntityBase<int>
    {
    }

    public interface IRepository<TEntity, in TKey>
        where TEntity : class, IEntityBase<TKey>
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }
        TEntity GetById(params TKey[] keyValues);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        int Save();
        Task<int> SaveAsync();
        IQueryable<TEntity> SqlQuery(string sql, params object[] parameters);
    }
}