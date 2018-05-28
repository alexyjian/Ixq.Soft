using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Ixq.Soft.Core;
using Ixq.Soft.Core.Domain;
using Ixq.Soft.Core.Infrastructure;
using Ixq.Soft.Core.Ioc;
using Ixq.Soft.Core.Repository;
using Ixq.Soft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.Services
{
    public class BaseEntityService<TEntity> : BaseEntityService<TEntity, int>
        where TEntity : class, IEntityBase<int>
    {

    }
    public class BaseEntityService<TEntity,TKey> : BaseService, IBaseEntityService<TEntity, TKey>
        where TEntity : class, IEntityBase<TKey>
    {
        public BaseEntityService()
        {
            var dbContext = IocResolver.Current.GetService<IDbContext>();

            EntityRepository = new EfCoreRepository<TEntity, TKey>(dbContext);
        }

        protected IRepository<TEntity, TKey> EntityRepository { get; }

        public virtual TEntity GetEntityById(params object[] keyValues)
        {
            return EntityRepository.GetById(keyValues);
        }

        public virtual TEntity AddEntity(TEntity entity)
        {
            return EntityRepository.Add(entity);
        }

        public virtual TEntity UpdateEntity(TEntity entity)
        {
            return EntityRepository.Update(entity);
        }

        public virtual TEntity RemoveEntity(TEntity entity)
        {
            return EntityRepository.Remove(entity);
        }

        public virtual PagingList<TEntity> GetPagingList(DataRequestModel requestModel)
        {
            var query = EntityRepository.TableNoTracking;

            query = !string.IsNullOrEmpty(requestModel.SortField)
                ? query.OrderByDirection(requestModel.SortField, requestModel.ListSortDirection)
                : query.OrderByDescending("Id");

            return query.ToPagingList(requestModel.PageIndex, requestModel.PageSize);
        }
    }
}