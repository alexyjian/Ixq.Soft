using System.Web;
using System.Web.Mvc;
using Ixq.Web.Mvc;

namespace Ixq.Soft.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new RuntimeLogHandleErrorAttribute { View = "~/Areas/Ixq.Soft.Web.Areas.Admin/Views/Shared/Error.cshtml" });
        }
    }
}
