using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ixq.Soft.Entities.System;
using Ixq.Soft.Models.Basis;
using Ixq.Soft.Service.System;
using Ixq.Soft.Utility;
using Ixq.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Ixq.Soft.Web.Controllers
{
    public class AccountController : BaseController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IAuthenticationManager _authenticationManager;

        public ApplicationSignInManager SignInManager =>
            _signInManager ?? (_signInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>());

        private IAuthenticationManager AuthenticationManager =>
            _authenticationManager ?? (_authenticationManager = HttpContext.GetOwinContext().Authentication);

        public ApplicationUserManager UserManager =>
            _userManager ?? (_userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>());

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", model);
            }
            if (Session["ValidateCode"] == null || Session["ValidateCode"].ToString() != model.Code)
            {
                ModelState.AddModelError(nameof(model.Code), "验证码错误。");
                model.Code = "";
                return View("Login", model);
            }
            Session["ValidateCode"] = null;
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
            switch (result)
            {
                case SignInStatus.Success:
                    return Redirect(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "无效的登录尝试。");
                    return View(model);
            }
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }

        public ActionResult GetValidateCode()
        {
            var code = ValidateCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            var bytes = ValidateCode.CreateValidateGraphic(code);
            return File(bytes, "image/jpeg");
        }
    }
}