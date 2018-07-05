using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.Core.Configuration
{
    /// <summary>
    /// 配置服务。在应用程序启动时，反射获取所以实现此类的实例，进行配置服务。
    /// </summary>
    public interface IConfigureServices
    {
        /// <summary>
        /// 获取一个值，表示此服务的执行优先顺序。
        /// </summary>
        int Order { get; }
        /// <summary>
        /// 进行服务模块的配置。
        /// </summary>
        /// <param name="services">服务描述集合。</param>
        /// <param name="configuration">配置信息。</param>
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}