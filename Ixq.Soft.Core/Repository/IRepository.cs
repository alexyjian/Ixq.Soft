using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Soft.Core.Domain;

namespace Ixq.Soft.Core.Repository
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : class, IEntityBase<TKey>
    {
        TEntity GetById(TKey id);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        int Save();
        Task<int> SaveAsync();
        IQueryable<TEntity> SqlQuery(string sql, params object[] parameters);
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }
    }
}