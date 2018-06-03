using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.Core.Ioc
{
    public class IocResolver
    {
        private IServiceProvider _service;

        static IocResolver()
        {
            Current = new IocResolver();
        }

        public T GetRequiredService<T>()
        {
            return RequestServices.GetRequiredService<T>();
        }

        public object GetRequiredService(Type serviceType)
        {
            return RequestServices.GetRequiredService(serviceType);
        }

        public T GetService<T>()
        {
            return RequestServices.GetService<T>();
        }

        public IEnumerable<T> GetServices<T>()
        {
            return RequestServices.GetServices<T>();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return RequestServices.GetServices(serviceType);
        }

        public IServiceProvider RequestServices => GetServiceProvider();

        public static IocResolver Current { get; }

        private IServiceProvider GetServiceProvider()
        {
            Guard.ArgumentNotNull(_service, "service");

            var httpAccessor = _service.GetService<IHttpContextAccessor>();
            return httpAccessor?.HttpContext?.RequestServices ?? _service;
        }

        internal void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _service = serviceProvider;
        }

        internal void SetServiceProvider(Func<IServiceProvider> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            _service = func();
        }
    }
}