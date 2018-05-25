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
            services.AddScoped<IRepository<ApplicationUser, long>, EfCoreRepository<ApplicationUser, long>>();
            services.AddScoped<IRepository<ApplicationRole, long>, EfCoreRepository<ApplicationRole, long>>();
            services.AddScoped<IRepository<ApplicationRole, long>, EfCoreRepository<ApplicationRole, long>>();
        }

        public int Order => 10;
    }
}