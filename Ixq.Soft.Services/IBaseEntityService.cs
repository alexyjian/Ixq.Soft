using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Core;
using Ixq.Soft.Core.Domain;

namespace Ixq.Soft.Services
{
    /// <summary>
    /// 具有实体 CRUD 操作的服务接口。
    /// </summary>
    /// <typeparam name="TEntity">实体类型。</typeparam>
    public interface IBaseEntityService<TEntity> : IBaseEntityService<TEntity, int>
        where TEntity : class, IEntityBase<int>
    {

    }

    /// <summary>
    /// 具有实体 CRUD 操作的服务接口。
    /// </summary>
    /// <typeparam name="TEntity">实体类型。</typeparam>
    /// <typeparam name="TKey">实体主键类型。</typeparam>
    public interface IBaseEntityService<TEntity, TKey> : IBaseService
        where TEntity : class, IEntityBase<TKey>
    {
        TEntity GetEntityById(params object[] keyValues);
        TEntity AddEntity(TEntity entity);
        TEntity UpdateEntity(TEntity entity);
        TEntity RemoveEntity(TEntity entity);
        PagedList<TEntity> GetPagingList(DataRequest request);
    }
}