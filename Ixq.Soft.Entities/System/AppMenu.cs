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
        #region const

        public const int LinkMaxLength = 200;
        public const int IconMaxLength = 200;

        #endregion

        public string Link { get; set; }
        public string Icon { get; set; }
        public bool IsEnable { get; set; }
        public virtual AppMenu ParentMenu { get; set; }
        public virtual ICollection<AppMenuRole> Roles { get; set; }
    }
}
