using Ixq.Security.Identity;
using Ixq.Soft.Entities.System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Ixq.Soft.Service.System
{
    public class AppRoleManager : AppRoleManager<AppRole>
    {
        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
        {
            return new AppRoleManager(new AppRoleStore<AppRole>(context.Get<DataContext.AppDataContext>()));
        }

        public AppRoleManager(IRoleStore<AppRole, long> store) : base(store)
        {
        }
    }
}