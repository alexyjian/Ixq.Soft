using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixq.Soft.Core.Thread;
using StackExchange.Redis;

namespace Ixq.Soft.Core.Caching
{
    /// <summary>
    ///     IConnectionMultiplexerAccessor
    /// </summary>
    public class RedisCache : ICache
    {
        private readonly AppConfig _appConfig;
        private readonly IConnectionMultiplexerAccessor _connectionMultiplexerAccessor;
        private readonly IDatabase _database;
        private readonly ISerializableService _serializableService;

        public RedisCache(AppConfig appConfig, ISerializableService serializableService,
            IConnectionMultiplexerAccessor connectionMultiplexerAccessor)
        {
            _appConfig = appConfig;
            _serializableService = serializableService;
            _connectionMultiplexerAccessor = connectionMultiplexerAccessor;

            _database = _connectionMultiplexerAccessor.ConnectionMultiplexer.GetDatabase();
        }


        public void Dispose()
        {
        }

        public bool Exists(string key)
        {
            return TaskHelper.RunSync(() => ExistsAsync(key));
        }

        public Task<bool> ExistsAsync(string key)
        {
            return _database.KeyExistsAsync(ParseKey(key));
        }

        public IDictionary<string, object> GetAll()
        {
            return TaskHelper.RunSync(GetAllAsync);
        }

        public async Task<IDictionary<string, object>> GetAllAsync()
        {
            var dict = new Dictionary<string, object>();
            foreach (var endPoint in _connectionMultiplexerAccessor.ConnectionMultiplexer.GetEndPoints())
            {
                var server = _connectionMultiplexerAccessor.ConnectionMultiplexer.GetServer(endPoint);

                var keys = server.Keys(_database.Database);

                keys = keys.Where(key =>
                    key.ToString().StartsWith(_appConfig.RedisCacheKeyPrefix, StringComparison.OrdinalIgnoreCase));

                foreach (var originalKey in keys)
                {
                    var key = originalKey.ToString().Replace(_appConfig.RedisCacheKeyPrefix, "");
                    var value = await GetAsync(key);
                    if (value != null) dict.Add(key, value);
                }
            }

            return dict;
        }

        public object Get(string key)
        {
            return TaskHelper.RunSync(() => GetAsync(key));
        }

        public async Task<object> GetAsync(string key)
        {
            var byteValue = await _database.StringGetAsync(ParseKey(key));
            if (TryDeserialize(byteValue, out var value))
                return value.Value;
            return null;
        }

        public T Get<T>(string key)
        {
            return TaskHelper.RunSync(() => GetAsync<T>(key));
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var byteValue = await _database.StringGetAsync(ParseKey(key));
            TryDeserialize(byteValue, out var value);
            if (value == null)
                return default(T);
            return (T) value.Value;
        }

        public void Set<T>(string key, T value)
        {
            TaskHelper.RunSync(() => SetAsync(key, value));
        }

        public Task SetAsync<T>(string key, T value)
        {
            return _database.StringSetAsync(ParseKey(key), ParseValue(key, value));
        }

        public void Set<T>(string key, T value, int second)
        {
            TaskHelper.RunSync(() => SetAsync(key, value, second));
        }

        public Task SetAsync<T>(string key, T value, int second)
        {
            return _database.StringSetAsync(ParseKey(key), ParseValue(key, value), TimeSpan.FromSeconds(second));
        }

        public void Set<T>(string key, T value, DateTime absoluteExpiration)
        {
            TaskHelper.RunSync(() => SetAsync(key, value, absoluteExpiration));
        }

        public Task SetAsync<T>(string key, T value, DateTime absoluteExpiration)
        {
            var expiry = absoluteExpiration - DateTime.Now;
            return _database.StringSetAsync(ParseKey(key), ParseValue(key, value), expiry);
        }

        public void Set<T>(string key, T value, TimeSpan slidingExpiration)
        {
            TaskHelper.RunSync(() => SetAsync(key, value, slidingExpiration));
        }

        public Task SetAsync<T>(string key, T value, TimeSpan slidingExpiration)
        {
            return _database.StringSetAsync(ParseKey(key), ParseValue(key, value, slidingExpiration),
                slidingExpiration);
        }

        public void Remove(string key)
        {
            TaskHelper.RunSync(() => RemoveAsync(key));
        }

        public Task RemoveAsync(string key)
        {
            return _database.KeyDeleteAsync(key);
        }

        public void Clear()
        {
            TaskHelper.RunSync(ClearAsync);
        }

        public async Task ClearAsync()
        {
            foreach (var endPoint in _connectionMultiplexerAccessor.ConnectionMultiplexer.GetEndPoints())
            {
                var server = _connectionMultiplexerAccessor.ConnectionMultiplexer.GetServer(endPoint);

                var keys = server.Keys(_database.Database);

                keys = keys.Where(key =>
                    key.ToString().StartsWith(_appConfig.RedisCacheKeyPrefix, StringComparison.OrdinalIgnoreCase));

                await _database.KeyDeleteAsync(keys.ToArray());
            }
        }

        protected string ParseKey(string key)
        {
            return _appConfig.RedisCacheKeyPrefix + key;
        }

        protected byte[] ParseValue(string key, object value)
        {
            return ParseValue(key, value, null, null);
        }

        protected byte[] ParseValue(string key, object value, DateTime? absoluteExpiration)
        {
            return ParseValue(key, value, absoluteExpiration, null);
        }

        protected byte[] ParseValue(string key, object value, TimeSpan? slidingExpiration)
        {
            return ParseValue(key, value, null, slidingExpiration);
        }

        /// <summary>
        ///     使用 <see cref="RedisCacheValue" /> 包装 缓存值，并返回序列化后的结果。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpiration"></param>
        /// <param name="slidingExpiration"></param>
        /// <returns></returns>
        protected byte[] ParseValue(string key, object value, DateTime? absoluteExpiration,
            TimeSpan? slidingExpiration)
        {
            var cacheValue = new RedisCacheValue
            {
                Key = key,
                AbsoluteExpiration = absoluteExpiration,
                SlidingExpiration = slidingExpiration,
                Value = value
            };
            return Serialize(cacheValue);
        }


        protected bool CheckCacheValue(RedisCacheValue value)
        {
            if (value.SlidingExpiration.HasValue)
            {
                // 通常情况下在 滑动时间到期时 RedisCache 会自动移除缓存项。
                if (value.SlidingExpiration.Value < DateTime.Now - value.InsertTime)
                {
                    Remove(value.Key);
                    return false;
                }

                Set(value.Key, value.Value, value.SlidingExpiration.Value);
            }

            return true;
        }

        protected bool TryDeserialize(byte[] data, out RedisCacheValue @object)
        {
            @object = default(RedisCacheValue);
            if (data == null)
                return false;
            try
            {
                var result = _serializableService.Deserialize(data);
                @object = (RedisCacheValue) result;
                if (!CheckCacheValue(@object))
                {
                    @object = null;
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        protected byte[] Serialize(object obj)
        {
            return _serializableService.Serialize(obj);
        }
    }
}