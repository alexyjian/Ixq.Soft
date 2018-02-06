using Ixq.Soft.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ixq.Soft.Repository
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sql, parameters);
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await Database.ExecuteSqlCommandAsync(sql, parameters);
        }
    }
}
