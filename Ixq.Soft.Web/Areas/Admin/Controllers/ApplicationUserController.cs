using Ixq.Soft.Core;
using Ixq.Soft.Mvc.Controllers;
using Ixq.Soft.Services.Identity;
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
            var pagingList = _userSvc.GetApplicationUserList(requestModel);

            var responseModel = new DataResponseModel
            {
                PageIndex = pagingList.PageIndex,
                PageTotal = pagingList.TotalPages,
                Records = pagingList.TotalRecords,
                Rows = pagingList
            };

            return Json(responseModel);
        }
    }
}