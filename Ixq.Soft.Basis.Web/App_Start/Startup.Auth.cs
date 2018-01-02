using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ixq.Security.Cookies;
using Ixq.Soft.Basis.Core;
using Ixq.Soft.Basis.Core.System;
using Ixq.Soft.Basis.DataContext;
using Ixq.Soft.Basis.Entities;
using Ixq.Soft.Basis.Entities.System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Ixq.Soft.Basis.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(AppDataContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieName = "IxqApplicationCookie",
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity =
                        Security.Owin.SecurityStampValidator
                            .OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                                TimeSpan.FromMinutes(30),
                                (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });

            app.UseExtendCookieAuthentication<ApplicationUserManager, ApplicationUser>(
                new ExtendAuthenticationOptions<ApplicationUser>()
                {
                    CookieName = "IxqApplicationCookie"
                });
        }
    }
}