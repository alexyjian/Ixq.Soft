using System.Threading.Tasks;
using Ixq.Soft.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // override identity tables name
            builder.Entity<ApplicationUser>().ToTable("Base_ApplicationUser");
            builder.Entity<ApplicationRole>().ToTable("Base_ApplicationRole");
            builder.Entity<IdentityUserClaim<long>>().ToTable("Base_ApplicationUserClaim");
            builder.Entity<IdentityUserRole<long>>().ToTable("Base_ApplicationUserRole");
            builder.Entity<IdentityUserLogin<long>>().ToTable("Base_ApplicationUserLogin");
            builder.Entity<IdentityRoleClaim<long>>().ToTable("Base_ApplicationRoleClaim");
            builder.Entity<IdentityUserToken<long>>().ToTable("Base_ApplicationUserToken");
        }
    }
}