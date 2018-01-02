using System.Security.Claims;
using System.Threading.Tasks;
using Ixq.Security.Owin;
using Ixq.Soft.Basis.Core.System;
using Ixq.Soft.Basis.Entities;
using Ixq.Soft.Basis.Entities.System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Ixq.Soft.Basis.Core.System
{
    public class ApplicationSignInManager : AppSignInManager<ApplicationUser>
    {
        public ApplicationSignInManager(UserManager<ApplicationUser, long> userManager,
            IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options,
            IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(),
                context.Authentication);
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager) UserManager);
        }
    }
}
