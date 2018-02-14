using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Core.Configuration;
using Ixq.Soft.Services.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.Services.Configuration
{
    public class ApplicationConfigureServices : IConfigureServices
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
        }

        public int Order => 15;
    }
}
