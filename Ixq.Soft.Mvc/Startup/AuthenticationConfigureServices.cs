using Ixq.Soft.Core.Configuration;
using Ixq.Soft.Core.Domain.Identity;
using Ixq.Soft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.Mvc.Startup
{
    public class AuthenticationConfigureServices : IConfigureServices
    {
        public int Order => 5;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}