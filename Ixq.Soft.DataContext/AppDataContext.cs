using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static AppDataContext Create()
        {
            return new AppDataContext();
        }

        public IDbSet<AppDepartment> AppDepartment { get; set; }

        public IDbSet<AppMenu> AppMenu { get; set; }

        //public IDbSet<AppMenuRole> AppMenuRole { get; set; }
        public IDbSet<AppPermissions> AppPermissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppMenuRole>()
                .HasKey(r => new {r.AppMenuId, r.AppRoleId })
                .ToTable("AppMenuRoles");
        }
    }
}