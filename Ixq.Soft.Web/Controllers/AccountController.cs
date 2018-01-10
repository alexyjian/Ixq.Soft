using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ixq.Soft.Core.ViewModels.LoginMoldes;
using Ixq.Soft.Entities.System;
using Ixq.Soft.Service.System;
using Ixq.Soft.Utility;
using Ixq.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Ixq.Soft.Web.Controllers
{
    public class AccountController : Ixq.Soft.Mvc.BaseController
    {
        private AppSignInManager _signInManager;
        private AppUserManager _userManager;
        private IAuthenticationManager _authenticationManager;

        public AppSignInManager SignInManager =>
            _signInManager ?? (_signInManager = HttpContext.GetOwinContext().Get<AppSignInManager>());

        private IAuthenticationManager AuthenticationManager =>
            _authenticationManager ?? (_authenticationManager = HttpContext.GetOwinContext().Authentication);

        public AppUserManager UserManager =>
            _userManager ?? (_userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>());

        [AllowAnonymous]
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
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
                model.Code = null;
                return View("Login", model);
            }
            Session["ValidateCode"] = null;
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    ModelState.AddModelError("", "账户被锁定。");
                    return View(model);
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "无效的登录尝试。");
                    return View(model);
            }
        }

        public ActionResult RedirectToLocal(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Url.Action("Index", "Home");
            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult GetValidateCode()
        {
            var code = ValidateCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            var bytes = ValidateCode.CreateValidateGraphic(code);
            return File(bytes, "image/jpeg");
        }
    }
}