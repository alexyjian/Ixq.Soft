using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Ixq.Soft.Core.Configuration;
using Ixq.Soft.Core.Domain;
using Ixq.Soft.Core.Domain.Identity;
using Ixq.Soft.Core.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ixq.Soft.EntityFrameworkCore
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>, IDbContext
    {
        private static readonly MethodInfo ConfigureGlobalQueryFilterMethodInfo =
            typeof(AppDbContext).GetMethod(nameof(ConfigureGlobalQueryFilter),
                BindingFlags.Instance | BindingFlags.NonPublic);

        private readonly AppConfig _appConfig;

        public AppDbContext(DbContextOptions options, UserAccessor userProvider, AppConfig appConfig) : base(options)
        {
            UserProvider = userProvider;
            _appConfig = appConfig;
        }

        public bool IsSoftDeleteFilterEnabled => _appConfig.IsSoftDeleteFilterEnabled;
        public void RollbackTransaction()
        {
            Database.RollbackTransaction();
        }

        public UserAccessor UserProvider { get; }

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
            entity.IsDeleted = true;
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

            if (entity.Id == Guid.Empty)
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

            // global query filters
            ConfigureGlobalQueryFilters(builder);
        }

        protected void ConfigureGlobalQueryFilters(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
                ConfigureGlobalQueryFilterMethodInfo.MakeGenericMethod(entityType.ClrType)
                    .Invoke(this, new object[] {builder});
        }

        private void ConfigureGlobalQueryFilter<TEntity>(ModelBuilder builder)
            where TEntity : class
        {
            var filterExpression = CreateFilterExpression<TEntity>();
            if (filterExpression != null)
                builder.Entity<TEntity>().HasQueryFilter(filterExpression);
        }

        protected virtual Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>()
            where TEntity : class
        {
            Expression<Func<TEntity, bool>> expression = null;

            if (typeof(ISoftDeleteAudited).IsAssignableFrom(typeof(TEntity)) && IsSoftDeleteFilterEnabled)
            {
                Expression<Func<TEntity, bool>> softDeleteFilter = e => !((ISoftDeleteAudited) e).IsDeleted;
                expression = softDeleteFilter;
            }

            return expression;
        }

        private long GetUserId()
        {
            var userId = 0L;
            if (UserProvider?.User != null)
                long.TryParse(UserProvider.User.FindFirstValue(ClaimTypes.NameIdentifier), out userId);

            return userId;
        }
    }
}