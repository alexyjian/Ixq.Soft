﻿using System;
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
            ToTable("AppDepartments");
            HasOptional(d => d.ParentDepartment);
            HasMany(d => d.Users).WithRequired(u => u.Department);
        }
    }
}
