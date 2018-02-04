using System;
using System.Collections.Generic;
using System.Text;
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
        }
    }
}
