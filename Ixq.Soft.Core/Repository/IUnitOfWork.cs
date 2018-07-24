using System.Threading;
using System.Threading.Tasks;
using Ixq.Soft.Core.Infrastructure;

namespace Ixq.Soft.Core.Repository
{
    /// <summary>
    ///     工作单元。负责事务控制/数据持久化操作，通常情况下一个工作单元的生命周期是跟随着 http 请求。
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        ///     获取一个 <see cref="UserAccessor" /> 实例。
        /// </summary>
        UserAccessor UserProvider { get; }

        /// <summary>
        ///     获取一值，表示是否启用软删除过滤器。
        /// </summary>
        bool IsSoftDeleteFilterEnabled { get; }

        /// <summary>
        ///     提交当前单元操作的更改。
        /// </summary>
        /// <returns>操作影响的行数。</returns>
        int SaveChanges();

        /// <summary>
        ///     异步提交当前单元操作的更改。
        /// </summary>
        /// <param name="cancellationToken">在等待任务完成时观察 <see cref="System.Threading.CancellationToken" />。</param>
        /// <returns>操作影响的行数。</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     回滚事务。
        /// </summary>
        void RollbackTransaction();
    }
}