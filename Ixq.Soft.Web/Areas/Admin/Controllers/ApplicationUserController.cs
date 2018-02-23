using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixq.Soft.Core.Domain.Identity;
using Ixq.Soft.Mvc.Controllers;
using Ixq.Soft.Mvc.Models;
using Ixq.Soft.Services.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ixq.Soft.Web.Areas.Admin.Controllers
{
    public class ApplicationUserController : AdminBaseController
    {
        private readonly IApplicationUserService _userSvc;
        public IHttpContextAccessor HttpAccessor { get; set; }

        public ApplicationUserController(IApplicationUserService userSvc)
        {
            _userSvc = userSvc;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ApplicationUserList()
        {

            var userList = _userSvc.GetApplicationUserList();

            var model = new DataTableResult<ApplicationUser>();
            model.Draw = 1;
            model.RecordsTotal = userList.Count;
            model.RecordsFiltered = userList.Count;
            model.Data = userList.ToList();

            return Json(model);
        }
    }
}