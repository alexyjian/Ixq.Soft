using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Ixq.Soft.Core.Domain;
using Ixq.Soft.Core.Domain.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ixq.Soft.Repository
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>, IDbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User =>
            _httpContextAccessor?.HttpContext.User ?? Thread.CurrentPrincipal as ClaimsPrincipal;

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sql, parameters);
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await Database.ExecuteSqlCommandAsync(sql, parameters);
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnSaveChangeComplete();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            OnSaveChangeComplete();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected virtual void OnSaveChangeComplete()
        {
            var entries = ChangeTracker.Entries().ToList();

            var userId = GetUserId();

            foreach (var entry in entries)
                switch (entry.State)
                {
                    case EntityState.Added:
                    {
                        AutofillGuid(entry);
                        ApplyICreationAudited(entry, userId);
                        break;
                    }
                    case EntityState.Modified:
                    {
                        ApplyIUpdateAudited(entry, userId);
                        break;
                    }
                    case EntityState.Deleted:
                    {
                        ApplyISoftDeleteAudited(entry, userId);
                        break;
                    }
                }
        }

        protected virtual void ApplyISoftDeleteAudited(EntityEntry entry, long userId)
        {
            if (!(entry.Entity is ISoftDeleteAudited entity))
                return;

            entry.State = EntityState.Modified;
            entity.IsDelete = true;
            entity.DeleteTime = DateTime.Now;
            entity.DeleteUserId = userId;
        }

        protected virtual void ApplyIUpdateAudited(EntityEntry entry, long userId)
        {
            if (!(entry.Entity is IUpdateAudited entity))
                return;

            entity.UpdateTime = DateTime.Now;
            entity.UpdateUserId = userId;
        }

        protected virtual void ApplyICreationAudited(EntityEntry entry, long userId)
        {
            if (!(entry.Entity is ICreationAudited entity))
                return;

            entity.CreationTime = DateTime.Now;
            entity.CreationUserId = userId;
        }

        protected virtual void AutofillGuid(EntityEntry entry)
        {
            if (!(entry.Entity is IEntityBase<Guid> entity))
                return;

            entity.Id = Guid.NewGuid();
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

        private long GetUserId()
        {
            var userId = 0L;
            if (User != null)
                long.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out userId);

            return userId;
        }
    }
}