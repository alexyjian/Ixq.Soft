using System.Security.Claims;
using System.Threading.Tasks;
using Ixq.Security.Owin;
using Ixq.Soft.Entities.System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Ixq.Soft.Service.System
{
    public class AppSignInManager : AppSignInManager<AppUser>
    {
        public AppSignInManager(UserManager<AppUser, long> userManager,
            IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }

        public static AppSignInManager Create(IdentityFactoryOptions<AppSignInManager> options,
            IOwinContext context)
        {
            return new AppSignInManager(context.GetUserManager<AppUserManager>(),
                context.Authentication);
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(AppUser user)
        {
            return user.GenerateUserIdentityAsync((AppUserManager) UserManager);
        }
    }
}
