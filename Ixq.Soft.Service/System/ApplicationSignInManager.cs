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
    public class ApplicationSignInManager : AppSignInManager<AppUser>
    {
        public ApplicationSignInManager(UserManager<AppUser, long> userManager,
            IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options,
            IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(),
                context.Authentication);
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(AppUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager) UserManager);
        }
    }
}
