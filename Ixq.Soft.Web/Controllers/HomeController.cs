using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ixq.Soft.Mvc;

namespace Ixq.Soft.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { area = Ixq.Soft.Core.Configs.SiteConfigs.AdminAreaName });
        }
    }
}