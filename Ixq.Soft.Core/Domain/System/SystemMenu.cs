using System;
using System.Collections.Generic;
using System.Text;

namespace Ixq.Soft.Core.Domain.System
{
    public class SystemMenu : EntityBase
    {
        public string Link { get; set; }
        public string Icon { get; set; }
        public bool IsEnable { get; set; }
        public virtual SystemMenu ParentMenu { get; set; }
    }
}
