using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixq.Soft.Mvc.ModelBinding.Metadata;
using Ixq.Soft.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Ixq.Soft.Web.Areas.Admin.Components
{
    public class JqGridViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IListPageModel model, string viewName = "Default")
        {
            return View(viewName, model);
        }
    }
}
