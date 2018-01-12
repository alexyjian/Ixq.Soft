using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ixq.Security.Identity;
using Ixq.Soft.Entities;
using Ixq.Soft.Entities.System;

namespace Ixq.Soft.DataContext
{
    public class AppDataContext : IdentityDbContextBase<AppUser>
    {
        public AppDataContext() : base("DataContext")
        {
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
        }

        public static AppDataContext Create()
        {
            return new AppDataContext();
        }

        public IDbSet<AppDepartment> AppDepartment { get; set; }

        public IDbSet<AppMenu> AppMenu { get; set; }

        public IDbSet<AppPermissions> AppPermissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var typesToRegister = Assembly.Load("Ixq.Soft.EntityMapping").GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                               type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            modelBuilder.Entity<AppUser>().ToTable("AppUsers");
            modelBuilder.Entity<AppRole>().ToTable("AppRoles");
            modelBuilder.Entity<AppIdentityUserRole>().ToTable("AppUserRoles");
            modelBuilder.Entity<AppIdentityUserLogin>().ToTable("AppUserLogins");
            modelBuilder.Entity<AppIdentityUserClaim>().ToTable("AppUserClaims");
        }
    }
}