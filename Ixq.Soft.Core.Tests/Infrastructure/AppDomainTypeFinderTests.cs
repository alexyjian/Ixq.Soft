using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Soft.Core.Caching;
using Ixq.Soft.Core.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ixq.Soft.Core.Tests.Infrastructure
{
    [TestClass]
    public class AppDomainTypeFinderTests
    {
        [TestMethod]
        public void FindType()
        {
            var typeFinder = new AppDomainTypeFinder();

            var cacheType = typeFinder.FindTypes<ICache>();

            Assert.AreEqual(cacheType.ToList().Count, 2); // memoryCache and RedisCache. 抽象的 EmptyCache 不会被查找。
        }

        abstract class EmptyCache : ICache
        {
            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool Exists(string key)
            {
                throw new NotImplementedException();
            }

            public Task<bool> ExistsAsync(string key)
            {
                throw new NotImplementedException();
            }

            public IDictionary<string, object> GetAll()
            {
                throw new NotImplementedException();
            }

            public Task<IDictionary<string, object>> GetAllAsync()
            {
                throw new NotImplementedException();
            }

            public object Get(string key)
            {
                throw new NotImplementedException();
            }

            public Task<object> GetAsync(string key)
            {
                throw new NotImplementedException();
            }

            public T Get<T>(string key)
            {
                throw new NotImplementedException();
            }

            public Task<T> GetAsync<T>(string key)
            {
                throw new NotImplementedException();
            }

            public void Set<T>(string key, T value)
            {
                throw new NotImplementedException();
            }

            public Task SetAsync<T>(string key, T value)
            {
                throw new NotImplementedException();
            }

            public void Set<T>(string key, T value, int second)
            {
                throw new NotImplementedException();
            }

            public Task SetAsync<T>(string key, T value, int second)
            {
                throw new NotImplementedException();
            }

            public void Set<T>(string key, T value, DateTime absoluteExpiration)
            {
                throw new NotImplementedException();
            }

            public Task SetAsync<T>(string key, T value, DateTime absoluteExpiration)
            {
                throw new NotImplementedException();
            }

            public void Set<T>(string key, T value, TimeSpan slidingExpiration)
            {
                throw new NotImplementedException();
            }

            public Task SetAsync<T>(string key, T value, TimeSpan slidingExpiration)
            {
                throw new NotImplementedException();
            }

            public void Remove(string key)
            {
                throw new NotImplementedException();
            }

            public Task RemoveAsync(string key)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public Task ClearAsync()
            {
                throw new NotImplementedException();
            }
        }
    }
}
