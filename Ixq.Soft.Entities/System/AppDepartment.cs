using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ixq.Soft.Entities.System
{
    public class AppDepartment : EntityBaseInt
    {
        public virtual AppDepartment ParentDepartment { get; set; }
        public virtual ICollection<AppUser> Users { get; set; }
    }
}
