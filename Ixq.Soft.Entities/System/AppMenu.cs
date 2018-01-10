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
        #region constant

        public const int LinkMaxLength = 200;
        public const int IconMaxLength = 200;

        #endregion

        [StringLength(LinkMaxLength)]
        public string Link { get; set; }
        [StringLength(IconMaxLength)]
        public string Icon { get; set; }
        public virtual AppMenu ParentMenu { get; set; }
    }
}
