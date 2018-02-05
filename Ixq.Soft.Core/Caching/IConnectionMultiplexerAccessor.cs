using StackExchange.Redis;

namespace Ixq.Soft.Core.Caching
{
    public interface IConnectionMultiplexerAccessor
    {
        ConnectionMultiplexer ConnectionMultiplexer { get; set; }
    }
}