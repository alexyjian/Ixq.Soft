using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Core.Application.Service;
using Ixq.Soft.Core.Configuration;
using Ixq.Soft.Services.Identity;
using Ixq.Soft.Services.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.Services.Configuration
{
    /// <summary>
    /// 应用服务配置。
    /// </summary>
    public class ApplicationConfigureServices : IConfigureServices
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IEntityAppService<,>), typeof(EntityAppService<,>));
            services.AddScoped(typeof(IEntityAppService<>), typeof(EntityAppService<>));

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
        }

        public int Order => 15;
    }
}
