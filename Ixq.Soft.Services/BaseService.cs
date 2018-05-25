using System.Security.Claims;
using Ixq.Soft.Core.Infrastructure;
using Ixq.Soft.Core.Ioc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ixq.Soft.Services
{
    public abstract class BaseService : IBaseService
    {
        private readonly UserAccessor _userAccessor;

        protected BaseService()
        {
            _userAccessor = IocResolver.Current.GetService<UserAccessor>();
            var loggerFactory = IocResolver.Current.GetService<ILoggerFactory>();
            Logger = loggerFactory.CreateLogger(GetType());
        }

        public ILogger Logger { get; }

        public ClaimsPrincipal User => _userAccessor.User;
    }
}