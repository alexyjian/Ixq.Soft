using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ixq.Soft.Entities.System
{
    public class AppMenuRole
    {
        public virtual int AppMenuId { get; set; }
        public virtual long AppRoleId { get; set; }
    }
}
