using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ixq.Soft.Entities.System
{
    public class AppMenu : EntityBaseInt
    {
        [StringLength(200)]
        public string Link { get; set; }
        [StringLength(200)]
        public string Icon { get; set; }
        public virtual AppMenu ParentMenu { get; set; }
    }
}
