using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Ixq.Soft.Core.Ioc
{
    /// <summary>
    ///     依赖注入解析器。
    /// </summary>
    public class IocResolver
    {
        private IServiceProvider _service;

        static IocResolver()
        {
            Current = new IocResolver();
        }

        /// <summary>
        ///     获取服务提供者。
        /// </summary>
        public IServiceProvider RequestServices => GetServiceProvider();

        /// <summary>
        ///     获取解析器实例。
        /// </summary>
        public static IocResolver Current { get; }


        /// <summary>
        ///     从 <see cref="IServiceProvider" /> 获取 <typeparamref name="T" /> 类型的服务。
        /// </summary>
        /// <typeparam name="T">要获取的服务对象的类型。</typeparam>
        /// <returns>类型 <typeparamref name="T" /> 的服务对象。</returns>
        /// <exception cref="InvalidOperationException">没有类型<typeparamref name="T" />的服务。</exception>
        public T GetRequiredService<T>()
        {
            return RequestServices.GetRequiredService<T>();
        }


        /// <summary>
        ///     从 <see cref="IServiceProvider" /> 获取 <paramref name="serviceType" /> 类型的服务。
        /// </summary>
        /// <param name="serviceType">指定要获取的服务对象类型的对象。</param>
        /// <returns>类型 <paramref name="serviceType" /> 的服务对象。</returns>
        /// <exception cref="InvalidOperationException">没有类型<paramref name="serviceType" />的服务。</exception>
        public object GetRequiredService(Type serviceType)
        {
            return RequestServices.GetRequiredService(serviceType);
        }

        /// <summary>
        ///     从 <see cref="IServiceProvider" /> 获取 <typeparamref name="T" /> 类型的服务。
        /// </summary>
        /// <typeparam name="T">要获取的服务对象的类型。</typeparam>
        /// <returns>类型 <typeparamref name="T" /> 的服务对象。</returns>
        public T GetService<T>()
        {
            return RequestServices.GetService<T>();
        }


        /// <summary>
        ///     从 <see cref="IServiceProvider" /> 获取 <typeparamref name="T" /> 类型的枚举。
        /// </summary>
        /// <typeparam name="T">要获取的服务对象的类型。</typeparam>
        /// <returns>类型 <typeparamref name="T" /> 的服务枚举对象。</returns>
        public IEnumerable<T> GetServices<T>()
        {
            return RequestServices.GetServices<T>();
        }

        /// <summary>
        ///     从 <see cref="IServiceProvider" /> 获取 <paramref name="serviceType" /> 类型的枚举。
        /// </summary>
        /// <param name="serviceType">指定要获取的服务对象类型的对象。</param>
        /// <returns>类型 <paramref name="serviceType" /> 的服务枚举对象。</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return RequestServices.GetServices(serviceType);
        }

        /// <summary>
        ///     获取服务提供者。
        /// </summary>
        /// <returns></returns>
        private IServiceProvider GetServiceProvider()
        {
            Guard.ArgumentNotNull(_service, "service");

            var httpAccessor = _service.GetService<IHttpContextAccessor>();
            return httpAccessor?.HttpContext?.RequestServices ?? _service;
        }

        /// <summary>
        ///     设置<see cref="IServiceProvider" />。
        /// </summary>
        /// <param name="serviceProvider"></param>
        internal void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _service = serviceProvider;
        }

        /// <summary>
        ///     设置<see cref="IServiceProvider" />。
        /// </summary>
        /// <param name="func"></param>
        internal void SetServiceProvider(Func<IServiceProvider> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));

            _service = func();
        }
    }
}