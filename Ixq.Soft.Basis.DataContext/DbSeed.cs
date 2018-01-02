using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Security.Identity;
using Ixq.Soft.Basis.Entities.System;
using Microsoft.AspNet.Identity;

namespace Ixq.Soft.Basis.DataContext
{
    public class DbSeed
    {
        public static void SeedSystemUser(AppDataContext context)
        {
            var roleManager = new AppRoleManager<ApplicationRole>(new AppRoleStore<ApplicationRole>(context));
            var userManager = new AppUserManager<ApplicationUser>(new AppUserStore<ApplicationUser>(context));

            var adminRole = new ApplicationRole() { Name = "Admin", Description = "具备全部权限的用户组", CreateDate = DateTime.Now };
            if (!roleManager.RoleExists(adminRole.Name))
                roleManager.Create(adminRole);

            var adminUser = new ApplicationUser
            {
                UserName = "admin",
                Age = 20,
                CreateDate = DateTime.Now,
                PhoneNumber = "",
            };
            userManager.Create(adminUser, "123");

            context.SaveChanges();
        }
    }
}
