using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.Core.Configuration
{
    public interface IConfigureServices
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
        int Order { get; }
    }
}
