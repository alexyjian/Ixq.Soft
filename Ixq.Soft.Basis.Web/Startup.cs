﻿using System;
using System.Data.Entity;
using System.Reflection;
using System.Threading.Tasks;
using Ixq.Core.Cache;
using Ixq.Core.DependencyInjection.Extensions;
using Ixq.Core.Logging;
using Ixq.Logging.Log4Net;
using Ixq.Owin.Extensions;
using Ixq.Soft.Basis.DataContext;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Ixq.Soft.Basis.Web.Startup))]
namespace Ixq.Soft.Basis.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 启用缓存
            CacheManager.SetCacheProvider(new Ixq.Web.Mvc.Caching.WebCacheProvider());
            // 启用日志
            ILoggerFactory factory = new Log4NetLoggerFactory();
            LogManager.SetLoggerFactory(factory);

            app.Initialization()
                .RegisterAutoMappe()
                .RegisterService(serverCollection =>
                {
                    serverCollection.TryAddSingleton<DbContext, AppDataContext>();
                    ConfigureAuth(app);
                })
                .RegisterAutofac(Assembly.GetExecutingAssembly());
        }
    }
}