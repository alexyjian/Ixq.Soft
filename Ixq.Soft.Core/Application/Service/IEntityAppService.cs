using Ixq.Soft.Core.Domain;

namespace Ixq.Soft.Core.Application.Service
{
    /// <summary>
    ///     具有实体 CRUD 操作的服务接口。
    /// </summary>
    /// <typeparam name="TEntity">实体类型。</typeparam>
    public interface IEntityAppService<TEntity> : IEntityAppService<TEntity, int>
        where TEntity : class, IEntityBase<int>
    {
    }

    /// <summary>
    ///     具有实体 CRUD 操作的服务接口。
    /// </summary>
    /// <typeparam name="TEntity">实体类型。</typeparam>
    /// <typeparam name="TKey">实体主键类型。</typeparam>
    public interface IEntityAppService<TEntity, TKey> : IApplicationService
        where TEntity : class, IEntityBase<TKey>
    {
        TEntity GetEntityById(params object[] keyValues);
        bool AddEntity(TEntity entity);
        bool UpdateEntity(TEntity entity);
        bool RemoveEntity(TEntity entity);
        PagedList<TEntity> GetPagedList(DataRequest request);
    }
}