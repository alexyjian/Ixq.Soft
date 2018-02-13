using System;
using System.Linq;
using Ixq.Soft.Core.Caching;
using Ixq.Soft.Core.Configuration;
using Ixq.Soft.Core.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.Mvc.Startup
{
    public static class ConfigureServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureInfrastructureServices(configuration);

            var serviceProvider = services.BuildServiceProvider();

            var typeFinder = serviceProvider.GetService<ITypeFinder>();

            var configureServiceTypes = typeFinder.FindTypes<IConfigureServices>();
            var configureServiceInstances =
                configureServiceTypes.Select(x => (IConfigureServices) Activator.CreateInstance(x))
                    .OrderBy(x => x.Order);
            foreach (var configureService in configureServiceInstances)
                configureService.ConfigureServices(services, configuration);
        }

        /// <summary>
        ///     添加一些基础设置服务至容器。
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private static void ConfigureInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            // http context accessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // user accessor
            services.AddSingleton<UserAccessor>();

            // app config
            var appConfig = new AppConfig();
            configuration.Bind("AppConfig", appConfig);
            appConfig.DbContextConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddSingleton(typeof(AppConfig), appConfig);

            // caching
            if (appConfig.RedisCacheEnabled)
            {
                services.AddSingleton<ISerializableService, BinarySerializableService>();
                services.AddSingleton<IConnectionMultiplexerAccessor, ConnectionMultiplexerAccessor>();
                services.AddScoped<ICache, RedisCache>();
            }
            else
            {
                services.AddScoped<ICache, MemoryCache>();
            }

            // type finder
            services.AddSingleton<ITypeFinder, AppDomainTypeFinder>();

            // logging
            services.AddLogging();
        }
    }
}