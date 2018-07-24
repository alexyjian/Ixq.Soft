using System;

namespace Ixq.Soft.Core.Caching
{
    /// <summary>
    ///     包装了 <see cref="RedisCache" /> 的缓存值。
    /// </summary>
    [Serializable]
    public class RedisCacheValue
    {
        public RedisCacheValue()
        {
            InsertTime = DateTime.Now;
        }

        public string Key { get; set; }
        public object Value { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? AbsoluteExpiration { get; set; }
        public TimeSpan? SlidingExpiration { get; set; }
    }
}