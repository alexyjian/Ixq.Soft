using Ixq.Soft.Core.Configuration;
using Ixq.Soft.Core.Ioc;
using Ixq.Soft.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.EntityFrameworkCore.Configuration
{
    public class DbConfigureServices : IConfigureServices
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.Add(ServiceDescriptor.Scoped<IDbContextUow>(s =>
                IocResolver.Current.GetService<AppDbContext>()));

            services.Add(ServiceDescriptor.Scoped<IUnitOfWork>(s =>
                IocResolver.Current.GetService<AppDbContext>()));

        }

        public int Order => 1;
    }
}