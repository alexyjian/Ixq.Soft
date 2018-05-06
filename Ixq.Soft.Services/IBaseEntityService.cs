using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Core;
using Ixq.Soft.Core.Domain;

namespace Ixq.Soft.Services
{
    public interface IBaseEntityService<TEntity, in TKey> : IBaseService
        where TEntity : class, IEntityBase<TKey>
    {
        TEntity GetEntityById(params TKey[] keyValues);
        void AddEntity(TEntity entity);
        void UpdateEntity(TEntity entity);
        void RemoveEntity(TEntity entity);
        PagingList<TEntity> GetPagingList(DataRequestModel requestModel);
    }
}
