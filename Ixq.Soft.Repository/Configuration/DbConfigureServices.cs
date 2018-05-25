using Ixq.Soft.Core.Configuration;
using Ixq.Soft.Core.Infrastructure;
using Ixq.Soft.Core.Ioc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.Repository.Configuration
{
    public class DbConfigureServices : IConfigureServices
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.Add(ServiceDescriptor.Scoped<IDbContext>(s =>
                IocResolver.Current.GetService<AppDbContext>()));
        }

        public int Order => 1;
    }
}