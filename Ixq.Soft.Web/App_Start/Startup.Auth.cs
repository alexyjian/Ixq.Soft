using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ixq.Security.Cookies;
using Ixq.Soft.DataContext;
using Ixq.Soft.Entities;
using Ixq.Soft.Entities.System;
using Ixq.Soft.Service.System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Ixq.Soft.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(AppDataContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);
            app.CreatePerOwinContext<AppSignInManager>(AppSignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieName = "IxqApplicationCookie",
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity =
                        Security.Owin.SecurityStampValidator
                            .OnValidateIdentity<AppUserManager, AppUser>(
                                TimeSpan.FromMinutes(30),
                                (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });

            app.UseExtendCookieAuthentication<AppUserManager, AppUser>(
                new ExtendAuthenticationOptions<AppUser>()
                {
                    CookieName = "IxqApplicationCookie",
                });
        }
    }
}