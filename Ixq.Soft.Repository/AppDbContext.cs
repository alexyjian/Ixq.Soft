using System.Threading.Tasks;
using Ixq.Soft.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ixq.Soft.Repository
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>, IDbContext
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