﻿using System.Web.Mvc;

namespace Ixq.Soft.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => Ixq.Soft.Core.Configs.SiteConfigs.AdminAreaName;
        

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional},
                new[] {"Ixq.Soft.Web.Areas.Admin.Controllers"}
            );
        }
    }
}