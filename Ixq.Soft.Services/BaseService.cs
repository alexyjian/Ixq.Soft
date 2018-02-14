using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Ixq.Soft.Core.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ixq.Soft.Services
{
    public abstract class BaseService : IBaseService
    {
        private readonly UserAccessor _userAccessor;

        protected BaseService()
        {
            _userAccessor = DependencyResolver.Current.RequestServices.GetService<UserAccessor>();
            Logger = DependencyResolver.Current.RequestServices.GetService<ILogger>();
        }

        public ClaimsPrincipal User => _userAccessor.User;

        public ILogger Logger { get; }
    }
}