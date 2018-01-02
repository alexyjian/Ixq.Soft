using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ixq.Soft.Basis.Core.System;
using Ixq.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Ixq.Soft.Basis.Web.Controllers
{
    public class AccountController : BaseController
    {
        public ApplicationSignInManager SignInManager =>
            HttpContext.GetOwinContext().Get<ApplicationSignInManager>();

        private IAuthenticationManager AuthenticationManager =>
            HttpContext.GetOwinContext().Authentication;

        public ApplicationUserManager UserManager =>
            HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string userName, string password, string code, string returnUrl)
        {
            var user = UserManager.Find(userName, password);
            if (user != null)
            {
                var identity = SignInManager.CreateUserIdentity(user);
                AuthenticationManager.SignIn(identity);
                if (string.IsNullOrWhiteSpace(returnUrl))
                    return RedirectToAction("Index", "Home");
                return Redirect(returnUrl);
            }

            ViewBag.ErrorMessage = "登录失败";
            return View();

        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }
    }
}