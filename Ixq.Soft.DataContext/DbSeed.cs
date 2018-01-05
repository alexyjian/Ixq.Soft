using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Security.Identity;
using Ixq.Soft.Entities.System;
using Microsoft.AspNet.Identity;

namespace Ixq.Soft.DataContext
{
    public class DbSeed
    {
        public static void SeedSystemUser(AppDataContext context)
        {
            var roleManager = new AppRoleManager<ApplicationRole>(new AppRoleStore<ApplicationRole>(context));
            var userManager = new AppUserManager<ApplicationUser>(new AppUserStore<ApplicationUser>(context));

            var adminRole =
                new ApplicationRole() {Name = "Admin", Description = "具备全部权限的角色", CreateDate = DateTime.Now};
            if (!roleManager.RoleExists(adminRole.Name))
                roleManager.Create(adminRole);

            var adminUser = new ApplicationUser
            {
                UserName = "admin",
                Age = 20,
                CreateDate = DateTime.Now,
                PhoneNumber = "",
            };
            if (userManager.FindByName(adminUser.UserName) == null)
            {
                userManager.Create(adminUser, "123123");
                userManager.AddToRole(adminUser.Id, adminRole.Name);
            }
            context.SaveChanges();
        }
    }
}