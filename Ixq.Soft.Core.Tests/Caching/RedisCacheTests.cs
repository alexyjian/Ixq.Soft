using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ixq.Soft.Core.Caching;
using Ixq.Soft.Core.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoryCache = Ixq.Soft.Core.Caching.MemoryCache;

namespace Ixq.Soft.Core.Tests.Caching
{
    [TestClass]
    public class RedisCacheTests
    {
        private readonly IOptions<AppConfig> _appConfig;
        private readonly ISerializableService _serializableService;
        private readonly IConnectionMultiplexerAccessor _cma;
        public RedisCacheTests()
        {
            _appConfig = Options.Create(new AppConfig
            {
                RedisCacheKeyPrefix = "Ixq.Soft::",
                RedisCacheConnectionString = "localhost:6379"
            });

            _serializableService = new BinarySerializableService();
            _cma = new ConnectionMultiplexerAccessor(_appConfig);
        }

        [TestMethod]
        public void SetAndGetCacheItem()
        {
            var cache = new RedisCache(_appConfig, _serializableService, _cma);

            cache.Set("test_key_str", "test");
            cache.Set("test_key_int", 123);

            Assert.AreEqual(cache.Get("test_key_str"), "test");
            Assert.AreEqual(cache.Get<int>("test_key_int"), 123);

            Assert.AreEqual(cache.GetAll().Count, 2);

            cache.Remove("test_key_str");
            cache.Remove("test_key_int");
        }

        [TestMethod]
        public async Task SetAndGetCacheItemAsync()
        {
            var cache = new RedisCache(_appConfig, _serializableService, _cma);

            await cache.SetAsync("test_key_str", "test");
            await cache.SetAsync("test_key_int", 123);

            Assert.AreEqual(await cache.GetAsync("test_key_str"), "test");
            Assert.AreEqual(await cache.GetAsync<int>("test_key_int"), 123);

            await cache.RemoveAsync("test_key_str");
            await cache.RemoveAsync("test_key_int");
        }

        [TestMethod]
        public void UseExpiryTimeAsync()
        {
            var cache = new RedisCache(_appConfig, _serializableService, _cma);

            cache.Set("test_key", 123, 3);
            Assert.AreEqual(cache.Get("test_key"), 123);
            System.Threading.Thread.Sleep(4 * 1000);
            Assert.IsNull(cache.Get("test_key"));

            Assert.AreEqual(cache.GetAll().Count, 0);
        }

        [TestMethod]
        public void UseExpiryTime_Slidin()
        {
            var cache = new RedisCache(_appConfig, _serializableService, _cma);

            cache.Set("test_key_async", 456, TimeSpan.FromSeconds(5));
            Assert.AreEqual(cache.Get("test_key_async"), 456);
            Assert.AreNotEqual(cache.Get("test_key_async"), 123);
            System.Threading.Thread.Sleep(3 * 1000);
            Assert.AreEqual(cache.Get("test_key_async"), 456);
            System.Threading.Thread.Sleep(6 * 1000);
            Assert.IsNull(cache.Get("test_key_async"));

            Assert.AreEqual(cache.GetAll().Count, 0);
        }

        [TestMethod]
        public void UseExpiryTime_Absolute()
        {
            var cache = new RedisCache(_appConfig, _serializableService, _cma);

            cache.Set("test_key_async", 456, DateTime.Now.AddSeconds(5));
            Assert.AreEqual(cache.Get("test_key_async"), 456);
            Assert.AreNotEqual(cache.Get("test_key_async"), 123);
            System.Threading.Thread.Sleep(3 * 1000);
            Assert.AreEqual(cache.Get("test_key_async"), 456);
            System.Threading.Thread.Sleep(3 * 1000);
            Assert.IsNull(cache.Get("test_key_async"));

            Assert.AreEqual(cache.GetAll().Count, 0);
        }

        [TestMethod]
        public void RemoveCache()
        {
            var cache = new RedisCache(_appConfig, _serializableService, _cma);

            cache.Set("test_key", 123, 3);
            cache.Remove("test_key");

            Assert.IsNull(cache.Get("test_key"));
            Assert.AreEqual(cache.GetAll().Count, 0);
        }

        [TestMethod]
        public void ClearCache()
        {
            var cache = new RedisCache(_appConfig, _serializableService, _cma);

            cache.Set("test_key", 123, 3);

            cache.Clear();

            Assert.IsNull(cache.Get("test_key"));
            Assert.AreEqual(cache.GetAll().Count, 0);
        }

        [TestMethod]
        public async Task Exists()
        {
            var cache = new RedisCache(_appConfig, _serializableService, _cma);

            cache.Set("test_key", 123);

            Assert.IsTrue(cache.Exists("test_key"));

            var isTrue = await cache.ExistsAsync("test_key");
            Assert.IsTrue(isTrue);

            cache.Remove("test_key");

            Assert.IsFalse(cache.Exists("test_key"));
        }
    }
}
