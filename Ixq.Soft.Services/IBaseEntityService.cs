using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Core;
using Ixq.Soft.Core.Domain;

namespace Ixq.Soft.Services
{
    public interface IBaseEntityService<TEntity> : IBaseEntityService<TEntity, int>
        where TEntity : class, IEntityBase<int>
    {

    }

    public interface IBaseEntityService<TEntity, TKey> : IBaseService
        where TEntity : class, IEntityBase<TKey>
    {
        TEntity GetEntityById(params object[] keyValues);
        TEntity AddEntity(TEntity entity);
        TEntity UpdateEntity(TEntity entity);
        TEntity RemoveEntity(TEntity entity);
        PagingList<TEntity> GetPagingList(DataRequestModel requestModel);
    }
}