using System.Security.Claims;
using Ixq.Soft.Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ixq.Soft.Services
{
    public abstract class BaseService : IBaseService
    {
        private readonly UserAccessor _userAccessor;

        protected BaseService()
        {
            _userAccessor = DependencyResolver.Current.GetService<UserAccessor>();
            var loggerFactory = DependencyResolver.Current.GetService<ILoggerFactory>();
            Logger = loggerFactory.CreateLogger(GetType());
        }

        protected ILogger Logger { get; }

        public ClaimsPrincipal User => _userAccessor.User;
    }
}