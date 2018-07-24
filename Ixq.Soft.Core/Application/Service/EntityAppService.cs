using System.Linq;
using Ixq.Soft.Core.Domain;
using Ixq.Soft.Core.Extensions;
using Ixq.Soft.Core.Ioc;
using Ixq.Soft.Core.Repository;

namespace Ixq.Soft.Core.Application.Service
{
    /// <summary>
    ///     默认的 <see cref="IEntityAppService{TEntity}" /> 实现。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EntityAppService<TEntity> : EntityAppService<TEntity, int>
        where TEntity : class, IEntityBase<int>
    {
    }

    /// <summary>
    ///     默认的 <see cref="IEntityAppService{TEntity, TKey}" /> 实现。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class EntityAppService<TEntity, TKey> : ApplicationService, IEntityAppService<TEntity, TKey>
        where TEntity : class, IEntityBase<TKey>
    {
        public EntityAppService()
        {
            Repository = IocResolver.Current.GetService<IRepository<TEntity, TKey>>();
        }

        protected IRepository<TEntity, TKey> Repository { get; }

        public virtual TEntity GetEntityById(params object[] keyValues)
        {
            return Repository.GetById(keyValues);
        }

        public virtual bool AddEntity(TEntity entity)
        {
            Repository.Add(entity);
            return Repository.Save() > 0;
        }

        public virtual bool UpdateEntity(TEntity entity)
        {
            Repository.Update(entity);
            return Repository.Save() > 0;
        }

        public virtual bool RemoveEntity(TEntity entity)
        {
            Repository.Remove(entity);
            return Repository.Save() > 0;
        }

        public virtual PagedList<TEntity> GetPagedList(DataRequest request)
        {
            var query = Repository.TableNoTracking;

            query = !string.IsNullOrEmpty(request.SortField)
                ? query.OrderByDirection(request.SortField, request.ListSortDirection)
                : query.OrderByDescending(x => x.SoteCode);

            return query.ToPagedList(request.PageIndex, request.PageSize);
        }
    }
}