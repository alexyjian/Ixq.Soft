using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ixq.Soft.Core.Configs
{
    public class SiteConfigs
    {
        public const string AdminAreaName = "Ixq.Soft.Web.Areas.Admin";
        public static bool IsDebug = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["IsDebug"]);
    }
}
