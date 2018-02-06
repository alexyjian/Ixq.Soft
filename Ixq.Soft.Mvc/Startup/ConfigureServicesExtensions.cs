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
                configureServiceTypes.Select(x => (IConfigureServices) Activator.CreateInstance(x));
            foreach (var configureService in configureServiceInstances)
                configureService.ConfigureServices(services, configuration);
        }

        private static void ConfigureInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            // http context accessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // app config
            var appConfig = new AppConfig();
            configuration.Bind(appConfig);
            services.AddSingleton(typeof(AppConfig), appConfig);

            // caching
            if (appConfig.RedisCacheEnabled)
            {
                services.AddScoped<ICache, MemoryCache>();
            }
            else
            {
                services.AddSingleton<ISerializableService, BinarySerializableService>();
                services.AddSingleton<IConnectionMultiplexerAccessor, ConnectionMultiplexerAccessor>();
                services.AddScoped<ICache, RedisCache>();
            }

            // type finder
            services.AddSingleton<ITypeFinder, AppDomainTypeFinder>();
        }
    }
}