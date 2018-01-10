using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Soft.Entities.System;

namespace Ixq.Soft.EntityMapping.System
{
    public class AppMenuMap : EntityTypeConfiguration<AppMenu>
    {
        public AppMenuMap()
        {
            ToTable("AppMenus");
            Property(m => m.Link).HasMaxLength(AppMenu.LinkMaxLength).IsRequired();
            Property(m => m.Icon).HasMaxLength(AppMenu.IconMaxLength);
            HasMany(m => m.Roles).WithRequired().HasForeignKey(mr => mr.AppMenuId);
        }
    }
}
