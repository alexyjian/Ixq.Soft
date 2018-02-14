using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixq.Soft.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Ixq.Soft.Web.Areas.Admin.Controllers
{
    public class ApplicationRoleController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}