using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.Core.Infrastructure
{
    public class DependencyResolver
    {
        private IServiceProvider _service;

        static DependencyResolver()
        {
            Current = new DependencyResolver();
        }

        public IServiceProvider RequestServices => GetServiceProvider();

        public static DependencyResolver Current { get; }

        private IServiceProvider GetServiceProvider()
        {
            Guard.ArgumentNotNull(_service, "service");

            var httpAccessor = _service.GetService<IHttpContextAccessor>();
            return httpAccessor.HttpContext.RequestServices ?? _service;
        }

        internal void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _service = serviceProvider;
        }
    }
}