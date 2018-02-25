using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixq.Soft.Core;
using Ixq.Soft.Core.Domain.Identity;
using Ixq.Soft.Mvc.Controllers;
using Ixq.Soft.Mvc.Models;
using Ixq.Soft.Mvc.UI;
using Ixq.Soft.Services.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ixq.Soft.Web.Areas.Admin.Controllers
{
    public class ApplicationUserController : AdminBaseController
    {
        private readonly IApplicationUserService _userSvc;

        public ApplicationUserController(IApplicationUserService userSvc)
        {
            _userSvc = userSvc;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ApplicationUserList(DataRequestModel requestModel)
        {
            var responseModel = _userSvc.GetApplicationUserList(requestModel);

            return Json(responseModel);
        }
    }
}