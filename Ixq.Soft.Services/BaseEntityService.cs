using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Ixq.Soft.Core;
using Ixq.Soft.Core.Domain;
using Ixq.Soft.Core.Infrastructure;
using Ixq.Soft.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.Services
{
    public class BaseEntityService<TEntity, TKey> : BaseService, IBaseEntityService<TEntity, TKey>
        where TEntity : class, IEntityBase<TKey>
    {
        private readonly IRepository<TEntity, TKey> _entityRepository;

        public BaseEntityService()
        {
            var dbContext = DependencyResolver.Current.GetService<IDbContext>();

            _entityRepository = new EfCoreRepository<TEntity, TKey>(dbContext);
        }

        protected IRepository<TEntity, TKey> EntityRepository => _entityRepository;

        public virtual TEntity GetEntityById(TKey id)
        {
            return EntityRepository.GetById(id);
        }

        public virtual void AddEntity(TEntity entity)
        {
            EntityRepository.Add(entity);
        }

        public virtual void UpdateEntity(TEntity entity)
        {
            EntityRepository.Update(entity);
        }

        public virtual void RemoveEntity(TEntity entity)
        {
            EntityRepository.Remove(entity);
        }

        public virtual PagingList<TEntity> GetEntityPagingList(DataRequestModel requestModel)
        {
            var query = EntityRepository.TableNoTracking;

            if (!string.IsNullOrEmpty(requestModel.SortField))
            {
                query = query.OrderByDirection(requestModel.SortField, requestModel.ListSortDirection);
            }

            return query.ToPagingList(requestModel.PageIndex, requestModel.PageSize);
        }
    }
}
