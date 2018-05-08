using Ixq.Soft.Core;
using Ixq.Soft.Core.Domain.Identity;
using Ixq.Soft.Mvc.Controllers;
using Ixq.Soft.Services.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Ixq.Soft.Mvc.ModelBinding.Metadata;
using Ixq.Soft.Mvc.UI;
using Ixq.Soft.Repository;
using Ixq.Soft.Web.Models.IdentityViewModels;

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
            var listPagesModel = MetadataProvider.GetListPageModel(typeof(ApplicationUserModel));
            return View(listPagesModel);
        }

        [HttpPost]
        public IActionResult List(DataRequestModel requestModel)
        {
            var pagingList = _userSvc.GetPagingList(requestModel);

            var responseModel = pagingList.ToDataResponse();

            responseModel.Rows = pagingList.Select(user => new ApplicationUserModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                LockoutEnabled = user.LockoutEnabled
            });

            return Json(responseModel);
        }

        public IActionResult Create()
        {
            return View("CreateOrEdit", new ApplicationUserModel());
        }

        public IActionResult Edit(long id)
        {
            var repos = Ixq.Soft.Core.Infrastructure.DependencyResolver.Current
                .GetRequiredService<IRepositoryInt64<ApplicationUser>>();

            var u = repos.GetById(id);

            var user = _userSvc.GetEntityById(id);
            if (user == null)
                return RedirectToAction("index");

            return View("CreateOrEdit", CreateApplicationUserModel(user));
        }

        private static ApplicationUserModel CreateApplicationUserModel(ApplicationUser user)
        {
            return new ApplicationUserModel
            {
                Id = user.Id,
                Email = user.Email,
                LockoutEnabled = user.LockoutEnabled,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            };
        }
    }
}