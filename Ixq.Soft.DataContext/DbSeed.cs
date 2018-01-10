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
        public static void SeedSystemDept(AppDataContext context)
        {
            if (context.AppDepartment.Any()) return;

            var dept = new AppDepartment();
            dept.Name = "总裁办";
            context.AppDepartment.Add(dept);
            context.Save();
        }

        public static void SeedSystemUser(AppDataContext context)
        {
            var roleManager = new AppRoleManager<AppRole>(new AppRoleStore<AppRole>(context));
            var userManager = new AppUserManager<AppUser>(new AppUserStore<AppUser>(context));

            var adminRole =
                new AppRole() {Name = "Admin", Description = "具备全部权限的角色", CreateDate = DateTime.Now};
            if (!roleManager.RoleExists(adminRole.Name))
                roleManager.Create(adminRole);

            var adminUser = new AppUser
            {
                UserName = "admin",
                Age = 20,
                CreateDate = DateTime.Now,
                PhoneNumber = "",
                Department = context.AppDepartment.SingleOrDefault(x=>x.Name == "总裁办")
            };
            if (userManager.FindByName(adminUser.UserName) == null)
            {
                userManager.Create(adminUser, "123123");
                userManager.AddToRole(adminUser.Id, adminRole.Name);
            }
            context.Save();
        }
    }
}