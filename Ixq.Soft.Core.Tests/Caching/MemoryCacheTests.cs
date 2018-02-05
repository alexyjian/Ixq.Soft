using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoryCache = Ixq.Soft.Core.Caching.MemoryCache;

namespace Ixq.Soft.Core.Tests.Caching
{
    [TestClass]
    public class MemoryCacheTests
    {
        [TestMethod]
        public void SetAndGetCacheItem()
        {
            var memoryCache =
                new MemoryCache(new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions()));

            memoryCache.Set("test_key_str", "test");
            memoryCache.Set("test_key_int", 123);

            Assert.AreEqual(memoryCache.Get("test_key_str"), "test");
            Assert.AreEqual(memoryCache.Get<int>("test_key_int"), 123);

            Assert.AreEqual(memoryCache.GetAll().Count, 2);
            Assert.AreEqual(memoryCache.GetAllKeys().Count, 2);
        }

        [TestMethod]
        public async Task SetAndGetCacheItemAsync()
        {
            var memoryCache =
                new MemoryCache(new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions()));

            await memoryCache.SetAsync("test_key_str", "test");
            await memoryCache.SetAsync("test_key_int", 123);

            Assert.AreEqual(await memoryCache.GetAsync("test_key_str"), "test");
            Assert.AreEqual(await memoryCache.GetAsync<int>("test_key_int"), 123);
        }

        [TestMethod]
        public void UseExpiryTimeAsync()
        {
            var memoryCache =
                new MemoryCache(new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions()));

            memoryCache.Set("test_key", 123, 3);
            Assert.AreEqual(memoryCache.Get("test_key"), 123);
            System.Threading.Thread.Sleep(4 * 1000);
            Assert.IsNull(memoryCache.Get("test_key"));

            Assert.AreEqual(memoryCache.GetAll().Count, 0);
        }

        [TestMethod]
        public async Task UseExpiryTime_SlidinAsync()
        {
            var memoryCache =
                new MemoryCache(new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions()));

            await memoryCache.SetAsync("test_key_async", 456, TimeSpan.FromSeconds(5));
            Assert.AreEqual(memoryCache.Get("test_key_async"), 456);
            Assert.AreNotEqual(memoryCache.Get("test_key_async"), 123);
            System.Threading.Thread.Sleep(3 * 1000);
            Assert.AreEqual(memoryCache.Get("test_key_async"), 456);
            System.Threading.Thread.Sleep(6 * 1000);
            Assert.IsNull(memoryCache.Get("test_key_async"));

            Assert.AreEqual(memoryCache.GetAll().Count, 0);
        }

        [TestMethod]
        public async Task UseExpiryTime_AbsoluteAsync()
        {
            var memoryCache =
                new MemoryCache(new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions()));

            await memoryCache.SetAsync("test_key_async", 456, DateTime.Now.AddSeconds(5));
            Assert.AreEqual(memoryCache.Get("test_key_async"), 456);
            Assert.AreNotEqual(memoryCache.Get("test_key_async"), 123);
            System.Threading.Thread.Sleep(3 * 1000);
            Assert.AreEqual(memoryCache.Get("test_key_async"), 456);
            System.Threading.Thread.Sleep(3 * 1000);
            Assert.IsNull(memoryCache.Get("test_key_async"));

            Assert.AreEqual(memoryCache.GetAll().Count, 0);
        }

        [TestMethod]
        public void RemoveCache()
        {
            var memoryCache =
                new MemoryCache(new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions()));

            memoryCache.Set("test_key", 123, 3);
            memoryCache.Remove("test_key");

            Assert.IsNull(memoryCache.Get("test_key"));
            Assert.AreEqual(memoryCache.GetAll().Count, 0);
        }

        [TestMethod]
        public void ClearCache()
        {
            var memoryCache =
                new MemoryCache(new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions()));

            memoryCache.Set("test_key", 123, 3);

            memoryCache.Clear();

            Assert.IsNull(memoryCache.Get("test_key"));
            Assert.AreEqual(memoryCache.GetAll().Count, 0);
        }
    }
}
