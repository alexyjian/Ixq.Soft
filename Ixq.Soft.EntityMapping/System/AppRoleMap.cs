using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Soft.Entities.System;

namespace Ixq.Soft.EntityMapping.System
{
    public class AppRoleMap : EntityTypeConfiguration<AppRole>
    {
        public AppRoleMap()
        {
            Property(r => r.Description).HasMaxLength(AppRole.DescriptionMaxLength);
            Property(r => r.SoteCode).HasMaxLength(AppRole.SoteCodeMaxLength);
            Property(r => r.CreateDate).IsRequired();
            HasMany(r => r.Menus).WithRequired().HasForeignKey(mr => mr.AppRoleId);
        }
    }
}
