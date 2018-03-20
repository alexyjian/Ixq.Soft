using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.Core.Configuration
{
    public interface IConfigureServices
    {
        int Order { get; }
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}