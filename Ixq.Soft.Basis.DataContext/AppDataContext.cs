using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Security.Identity;
using Ixq.Soft.Basis.Entities;
using Ixq.Soft.Basis.Entities.System;

namespace Ixq.Soft.Basis.DataContext
{
    public class AppDataContext : IdentityDbContextBase<ApplicationUser>
    {
        public AppDataContext() : base("DataContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static AppDataContext Create()
        {
            return new AppDataContext();
        }

    }
}