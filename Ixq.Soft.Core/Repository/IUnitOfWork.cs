using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ixq.Soft.Core.Infrastructure;

namespace Ixq.Soft.Core.Repository
{
    public interface IUnitOfWork
    {
        UserAccessor UserProvider { get; }

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

        void RollbackTransaction();
    }
}