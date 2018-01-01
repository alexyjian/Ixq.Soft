using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Security.Identity;
using Ixq.Soft.Basis.Entities;

namespace Ixq.Soft.Basis.DataContext
{
    public class AppDataContext : IdentityDbContextBase<ApplicationUser>
    {
        public AppDataContext() : base("DataContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public static AppDataContext Create()
        {
            return new AppDataContext();
        }
    }
}