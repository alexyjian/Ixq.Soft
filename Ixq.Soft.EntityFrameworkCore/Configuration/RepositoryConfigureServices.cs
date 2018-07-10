using Ixq.Soft.Core.Configuration;
using Ixq.Soft.Core.Domain.Identity;
using Ixq.Soft.Core.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.EntityFrameworkCore.Configuration
{
    /// <summary>
    /// 仓储配置。
    /// </summary>
    public class RepositoryConfigureServices : IConfigureServices
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(EfCoreRepository<,>));
            services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));
        }

        public int Order => 10;
    }
}