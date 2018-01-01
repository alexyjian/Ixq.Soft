﻿using Ixq.Security.Identity;
using Ixq.Soft.Basis.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Ixq.Soft.Basis.Core
{
    public class ApplicationRoleManager : AppRoleManager<ApplicationRole>
    {
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new AppRoleStore<ApplicationRole>(context.Get<DataContext.AppDataContext>()));
        }

        public ApplicationRoleManager(IRoleStore<ApplicationRole, long> store) : base(store)
        {
        }
    }
}