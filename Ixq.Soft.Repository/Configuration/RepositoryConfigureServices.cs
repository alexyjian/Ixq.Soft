using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Core.Configuration;
using Ixq.Soft.Core.Domain.Identity;
using Ixq.Soft.Core.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.Repository.Configuration
{
    public class RepositoryConfigureServices : IConfigureServices
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepositoryInt64<ApplicationUser>, EfCoreRepositoryInt64<ApplicationUser>>();
            services.AddScoped<IRepositoryInt64<ApplicationRole>, EfCoreRepositoryInt64<ApplicationRole>>();
        }

        public int Order => 10;
    }
}