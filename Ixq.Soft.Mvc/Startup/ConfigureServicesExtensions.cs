﻿using System;
using System.Linq;
using Ixq.Soft.Core.Caching;
using Ixq.Soft.Core.Configuration;
using Ixq.Soft.Core.Infrastructure;
using Ixq.Soft.Core.Ioc;
using Ixq.Soft.Mvc.DataAnnotations.Internal;
using Ixq.Soft.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using IXQMemoryCache = Ixq.Soft.Core.Caching.MemoryCache;
using MSMemoryCache = Microsoft.Extensions.Caching.Memory.MemoryCache;

namespace Ixq.Soft.Mvc.Startup
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceProvider ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureInfrastructureServices(configuration);

            var mvcBuilder = services.AddMvcService();

            mvcBuilder.AddMvcOptions(options =>
            {
                options.ModelMetadataDetailsProviders.Add(new EntityDataAnnotationsMetadataProvider());
            });

            var typeFinder = new AppDomainTypeFinder();

            var configureServiceTypes = typeFinder.FindTypes<IConfigureServices>();
            var configureServiceInstances =
                configureServiceTypes.Select(x => (IConfigureServices) Activator.CreateInstance(x))
                    .OrderBy(x => x.Order);
            foreach (var configureService in configureServiceInstances)
                configureService.ConfigureServices(services, configuration);


            var serviceProvider = services.BuildServiceProvider();
            IocResolver.Current.SetServiceProvider(serviceProvider);

            return serviceProvider;
        }

        /// <summary>
        ///     添加一些基础设置服务至容器。
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private static void ConfigureInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions();

            // app config
            services.Configure<AppConfig>(config =>
            {
                configuration.GetSection("AppConfig").Bind(config);
                config.DbContextConnectionString = configuration.GetConnectionString("DefaultConnection");
            });

            // http context accessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // user accessor
            services.AddSingleton<UserAccessor>();

            // caching
            var redisCacheEnabled = configuration.GetValue<bool>("AppConfig:RedisCacheEnabled");
            if (redisCacheEnabled)
            {
                services.AddSingleton<ISerializableService, BinarySerializableService>();
                services.AddSingleton<IConnectionMultiplexerAccessor, ConnectionMultiplexerAccessor>();
                services.AddSingleton<ICache, RedisCache>();
            }
            else
            {
                services.TryAddSingleton<IMemoryCache, MSMemoryCache>();
                services.AddSingleton<ICache, IXQMemoryCache>();
            }

            // type finder
            services.AddSingleton<ITypeFinder, AppDomainTypeFinder>();

            // logging
            services.AddLogging();
        }


        public static IMvcBuilder AddMvcService(this IServiceCollection services)
        {
            services.TryAddSingleton<IModelMetadataProvider, EntityModelMetadataProvider>();
            services.TryAdd(ServiceDescriptor.Transient<ICompositeMetadataDetailsProvider>(s =>
            {
                var options = s.GetRequiredService<IOptions<MvcOptions>>().Value;
                return new DefaultCompositeMetadataDetailsProvider(options.ModelMetadataDetailsProviders);
            }));

            return services.AddMvc(optons =>
            {
                optons.ModelBinderProviders.Insert(0, new DataRequestModelBinderProvider());
            });
        }
    }
}