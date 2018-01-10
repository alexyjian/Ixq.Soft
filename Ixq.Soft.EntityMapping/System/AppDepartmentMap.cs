using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Soft.Entities.System;

namespace Ixq.Soft.EntityMapping.System
{
    public class AppDepartmentMap : EntityTypeConfiguration<AppDepartment>
    {
        public AppDepartmentMap()
        {
            this.ToTable("AppDepartments");
            this.HasOptional(d => d.ParentDepartment);
            this.HasMany(d => d.Users).WithRequired().HasForeignKey(u => u.Department);
        }
    }
}
