using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ixq.Soft.Core.Thread;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace Ixq.Soft.Core.Caching
{
    public class MemoryCache : ICache
    {
        private static readonly ConcurrentDictionary<string, bool> AllKeys;
        private readonly IMemoryCache _memoryCache;
        private CancellationTokenSource _cancellationTokenSource;

        static MemoryCache()
        {
            AllKeys = new ConcurrentDictionary<string, bool>();
        }

        public MemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Dispose()
        {
            Clear();
            _memoryCache?.Dispose();
        }

        public bool Exists(string key)
        {
            Guard.ArgumentNotNullOrWhiteSpace(key, nameof(key));

            return _memoryCache.TryGetValue(key, out object _);
        }

        public Task<bool> ExistsAsync(string key)
        {
            return TaskHelper.Run(() => Exists(key));
        }

        public IDictionary<string, object> GetAll()
        {
            var dict = new Dictionary<string, object>();

            AllKeys.ToList().ForEach(item =>
            {
                var value = _memoryCache.Get(item.Key);
                if (value != null) dict.Add(item.Key, value);
            });

            return dict;
        }

        public Task<IDictionary<string, object>> GetAllAsync()
        {
            return TaskHelper.Run(GetAll);
        }

        public object Get(string key)
        {
            Guard.ArgumentNotNullOrWhiteSpace(key, nameof(key));

            return _memoryCache.Get(key);
        }

        public Task<object> GetAsync(string key)
        {
            return TaskHelper.Run(() => Get(key));
        }

        public T Get<T>(string key)
        {
            Guard.ArgumentNotNullOrWhiteSpace(key, nameof(key));

            return _memoryCache.Get<T>(key);
        }

        public Task<T> GetAsync<T>(string key)
        {
            return TaskHelper.Run(() => Get<T>(key));
        }

        public void Set<T>(string key, T value)
        {
            Guard.ArgumentNotNullOrWhiteSpace(key, nameof(key));
            Guard.ArgumentNotNull(value, nameof(value));

            _memoryCache.Set(AddKey(key), value, CreateCacheOptions());
        }

        public Task SetAsync<T>(string key, T value)
        {
            return TaskHelper.Run(() => Set(key, value));
        }

        public void Set<T>(string key, T value, int second)
        {
            Guard.ArgumentNotNullOrWhiteSpace(key, nameof(key));
            Guard.ArgumentNotNull(value, nameof(value));

            var absoluteExpiration = DateTime.Now.AddSeconds(second);
            _memoryCache.Set(AddKey(key), value, CreateCacheOptions().SetAbsoluteExpiration(absoluteExpiration));
        }

        public Task SetAsync<T>(string key, T value, int second)
        {
            return TaskHelper.Run(() => Set(key, value, second));
        }

        public void Set<T>(string key, T value, DateTime absoluteExpiration)
        {
            Guard.ArgumentNotNullOrWhiteSpace(key, nameof(key));
            Guard.ArgumentNotNull(value, nameof(value));

            _memoryCache.Set(AddKey(key), value, CreateCacheOptions().SetAbsoluteExpiration(absoluteExpiration));
        }

        public Task SetAsync<T>(string key, T value, DateTime absoluteExpiration)
        {
            return TaskHelper.Run(() => Set(key, value, absoluteExpiration));
        }

        public void Set<T>(string key, T value, TimeSpan slidingExpiration)
        {
            Guard.ArgumentNotNullOrWhiteSpace(key, nameof(key));
            Guard.ArgumentNotNull(value, nameof(value));

            _memoryCache.Set(AddKey(key), value, CreateCacheOptions().SetSlidingExpiration(slidingExpiration));
        }

        public Task SetAsync<T>(string key, T value, TimeSpan slidingExpiration)
        {
            return TaskHelper.Run(() => Set(key, value, slidingExpiration));
        }

        public void Remove(string key)
        {
            Guard.ArgumentNotNullOrWhiteSpace(key, nameof(key));

            _memoryCache.Remove(RemoveKey(key));
        }

        public Task RemoveAsync(string key)
        {
            return TaskHelper.Run(() => Remove(key));
        }

        public void Clear()
        {
            // 发送取消请求
            _cancellationTokenSource.Cancel();

            // 释放此取消标记使用的所有资源
            _cancellationTokenSource.Dispose();

            // 重新创建取消令牌
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public Task ClearAsync()
        {
            return TaskHelper.Run(Clear);
        }

        protected MemoryCacheEntryOptions CreateCacheOptions()
        {
            return new MemoryCacheEntryOptions()
                .AddExpirationToken(new CancellationChangeToken(_cancellationTokenSource.Token))
                .RegisterPostEvictionCallback(PostEviction);
        }

        protected string AddKey(string key)
        {
            AllKeys.TryAdd(key, true);
            return key;
        }

        protected string RemoveKey(string key)
        {
            TryRemoveKey(key);
            return key;
        }

        protected void TryRemoveKey(string key)
        {
            if (!AllKeys.TryRemove(key, out bool _))
                AllKeys.TryUpdate(key, false, false);
        }

        internal IReadOnlyDictionary<string, bool> GetAllKeys()
        {
            var dict = new ReadOnlyDictionary<string, bool>(AllKeys);
            return dict;
        }

        private void ClearKeys()
        {
            foreach (var key in AllKeys.Where(p => !p.Value).Select(p => p.Key).ToList()) RemoveKey(key);
        }

        private void PostEviction(object key, object value, EvictionReason reason, object state)
        {
            // 如果缓存项目只是改变，那么什么都不做
            if (reason == EvictionReason.Replaced)
                return;

            // 尝试从字典中删除这个键
            TryRemoveKey(key.ToString());

            // 尝试删除标记为不存在的所有密钥
            ClearKeys();
        }
    }
}