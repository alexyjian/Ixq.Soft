using System.Security.Claims;
using Ixq.Soft.Core.Infrastructure;
using Ixq.Soft.Core.Ioc;
using Microsoft.Extensions.Logging;

namespace Ixq.Soft.Core.Application.Service
{
    /// <summary>
    ///     应用服务基类。
    /// </summary>
    public abstract class ApplicationService : IApplicationService
    {
        private readonly UserAccessor _userAccessor;

        protected ApplicationService()
        {
            _userAccessor = IocResolver.Current.GetService<UserAccessor>();
            var loggerFactory = IocResolver.Current.GetService<ILoggerFactory>();
            Logger = loggerFactory.CreateLogger(GetType());
        }

        protected ILogger Logger { get; }

        protected ClaimsPrincipal User => _userAccessor.User;
    }
}