using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ixq.Soft.Core.Infrastructure;
using Ixq.Soft.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ixq.Soft.EntityFrameworkCore
{
    /// <summary>
    ///     基于 <see cref="DbContext"/> 的工作单元基础接口。
    /// </summary>
    public interface IDbContextUow : IUnitOfWork, IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// 对数据库执行给定的SQL并返回受影响的行数。 请注意，此方法不会启动事务。
        /// </summary>
        /// <param name="sql">SQL 查询字符串。</param>
        /// <param name="parameters">要应用于 SQL 查询字符串的参数。</param>
        /// <returns>受影响的行数。</returns>
        int ExecuteSqlCommand(string sql, params object[] parameters);

        /// <summary>
        /// 对数据库异步执行给定的SQL并返回受影响的行数。 请注意，此方法不会启动事务。
        /// </summary>
        /// <param name="sql">SQL 查询字符串。</param>
        /// <param name="parameters">要应用于 SQL 查询字符串的参数。</param>
        /// <returns>受影响的行数。</returns>
        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);

        /// <summary>
        /// 基于原始SQL查询创建LINQ查询。
        /// </summary>
        /// <typeparam name="T">查询所返回对象的类型。</typeparam>
        /// <param name="sql">SQL 查询字符串。</param>
        /// <returns></returns>
        IQueryable<T> SqlQuery<T>(string sql) where T : class;

        /// <summary>
        /// 基于原始SQL查询创建LINQ查询。
        /// </summary>
        /// <typeparam name="T">查询所返回对象的类型。</typeparam>
        /// <param name="sql">SQL 查询字符串。</param>
        /// <param name="parameters">要应用于 SQL 查询字符串的参数。</param>
        /// <returns></returns>
        IQueryable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class;
    }
}