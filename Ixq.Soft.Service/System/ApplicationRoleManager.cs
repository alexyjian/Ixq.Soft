﻿using Ixq.Security.Identity;
using Ixq.Soft.Entities.System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Ixq.Soft.Service.System
{
    public class ApplicationRoleManager : AppRoleManager<AppRole>
    {
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new AppRoleStore<AppRole>(context.Get<DataContext.AppDataContext>()));
        }

        public ApplicationRoleManager(IRoleStore<AppRole, long> store) : base(store)
        {
        }
    }
}