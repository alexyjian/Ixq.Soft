using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Soft.Entities.System;

namespace Ixq.Soft.EntityMapping.System
{
    public class AppMenuRoleMap : EntityTypeConfiguration<AppMenuRole>
    {
        public AppMenuRoleMap()
        {
            ToTable("AppMenuRoles");
            HasKey(mr => new {mr.AppMenuId, mr.AppRoleId});
        }
    }
}
