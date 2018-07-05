using StackExchange.Redis;

namespace Ixq.Soft.Core.Caching
{
    /// <summary>
    /// <see cref="StackExchange.Redis.ConnectionMultiplexer"/> 访问器。
    /// </summary>
    public interface IConnectionMultiplexerAccessor
    {
        /// <summary>
        /// 获取或设置一个 <see cref="StackExchange.Redis.ConnectionMultiplexer"/> 实例。
        /// </summary>
        ConnectionMultiplexer ConnectionMultiplexer { get; set; }
    }
}