using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Ixq.Soft.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Ixq.Soft.Repository
{
    public interface IDbContext : IDisposable
    {
        bool IsSoftDeleteFilterEnabled { get; }
        UserAccessor UserProvider { get; }

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

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int ExecuteSqlCommand(string sql, params object[] parameters);

        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);
    }
}