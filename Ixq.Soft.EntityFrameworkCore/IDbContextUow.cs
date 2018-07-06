using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ixq.Soft.Core.Infrastructure;
using Ixq.Soft.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ixq.Soft.EntityFrameworkCore
{
    public interface IDbContextUow : IUnitOfWork, IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int ExecuteSqlCommand(string sql, params object[] parameters);

        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);

        IQueryable<T> SqlQuery<T>(string sql) where T : class;
        IQueryable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class;
    }
}