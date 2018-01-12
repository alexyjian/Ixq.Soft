using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ixq.Soft.Entities.System
{
    public class AppPermissions : EntityBaseInt
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Link { get; set; }
    }
}
