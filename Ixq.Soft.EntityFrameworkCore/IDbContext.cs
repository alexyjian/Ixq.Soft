using System;
using System.Threading;
using System.Threading.Tasks;
using Ixq.Soft.Core.Infrastructure;
using Ixq.Soft.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ixq.Soft.EntityFrameworkCore
{
    public interface IDbContext : IUnitOfWork, IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int ExecuteSqlCommand(string sql, params object[] parameters);

        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);
    }
}