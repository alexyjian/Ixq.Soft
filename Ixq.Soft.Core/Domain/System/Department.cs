using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Core.Domain.System
{
    public class Department : EntityBase
    {
        public virtual Department ParentDepartment { get; set; }
    }
}