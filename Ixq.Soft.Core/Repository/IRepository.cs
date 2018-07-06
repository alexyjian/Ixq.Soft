using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixq.Soft.Core.Domain;

namespace Ixq.Soft.Core.Repository
{
    /// <summary>
    /// 定义仓储接口。
    /// </summary>
    /// <typeparam name="TEntity">实体类型。</typeparam>
    public interface IRepository<TEntity> : IRepository<TEntity, int>
        where TEntity : class, IEntityBase<int>
    {
    }

    /// <summary>
    /// 定义仓储接口。
    /// </summary>
    /// <typeparam name="TEntity">实体类型。</typeparam>
    /// <typeparam name="TKey">实体主键的类型。</typeparam>
    public interface IRepository<TEntity, TKey>
        where TEntity : class, IEntityBase<TKey>
    {
        /// <summary>
        /// 获取实体集。
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// 获取实体集，返回的实体不会被上下文跟踪。
        /// </summary>
        IQueryable<TEntity> TableNoTracking { get; }

        /// <summary>
        /// 根据主键查找实体。
        /// </summary>
        /// <param name="keyValues">实体主键。</param>
        /// <returns>查找出来的实体，可能为 null。</returns>
        TEntity GetById(params object[] keyValues);

        /// <summary>
        ///     添加一个实体到上下文。当使用 uow 提交更改时，将会将实体插入到数据库中。
        /// </summary>
        /// <param name="entity">需要添加的实体。</param>
        /// <returns></returns>
        TEntity Add(TEntity entity);

        /// <summary>
        ///     添加指定的实体集合到上下文。当使用 uow 提交更改时，将会将实体插入到数据库中。
        /// </summary>
        /// <param name="entities">要添加的实体集合。</param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        ///     更新一个实体。当使用 uow 提交更改时，将会将实体的更改更新到数据库中。
        /// </summary>
        /// <param name="entity">需要更新的实体。</param>
        /// <returns></returns>
        TEntity Update(TEntity entity);

        /// <summary>
        ///     更新指定的实体集合。当使用 uow 提交更改时，将会将实体的更改更新到数据库中。
        /// </summary>
        /// <param name="entities">需要更新的实体集合。</param>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        ///     从上下文中移除一个实体。当使用 uow 提交更改时，将会将实体从数据库中删除。
        /// </summary>
        /// <param name="entity">需要删除的实体。</param>
        /// <returns></returns>
        TEntity Remove(TEntity entity);

        /// <summary>
        ///     从上下文中移除指定的实体集合。当使用 uow 提交更改时，将会将实体从数据库中删除。
        /// </summary>
        /// <param name="entities">需要删除的实体集合。</param>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        ///     提交当前工作单元的更改到数据库。
        /// </summary>
        /// <returns></returns>
        int Save();

        /// <summary>
        ///     异步的提交当前工作单元的更改到数据库。
        /// </summary>
        /// <returns></returns>
        Task<int> SaveAsync();

        /// <summary>
        ///     创建一个原始 SQL 查询，该查询将返回此集中的实体。并且上下文会跟踪返回的实体。
        /// </summary>
        /// <param name="sql">SQL 查询字符串。</param>
        /// <returns>查询的结果。</returns>
        IQueryable<TEntity> SqlQuery(string sql);

        /// <summary>
        ///     创建一个原始 SQL 查询，该查询将返回此集中的实体。并且上下文会跟踪返回的实体。
        /// </summary>
        /// <param name="sql">SQL 查询字符串。</param>
        /// <param name="parameters">要应用于 SQL 查询字符串的参数。</param>
        /// <returns>查询的结果。</returns>
        IQueryable<TEntity> SqlQuery(string sql, params object[] parameters);
    }
}