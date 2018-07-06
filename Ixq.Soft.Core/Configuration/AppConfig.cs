namespace Ixq.Soft.Core.Configuration
{
    /// <summary>
    ///     应用程序配置信息。
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// 获取或设置一个值，表示是否启用 Redis Cache.
        /// </summary>
        public bool RedisCacheEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，表示 Redis Cache 中缓存 Key 的前缀。
        /// </summary>
        public string RedisCacheKeyPrefix { get; set; }
        /// <summary>
        /// 获取或设置一个值，表示 Redis Cache 的连接串。
        /// </summary>
        public string RedisCacheConnectionString { get; set; }
        /// <summary>
        /// 获取或设置一个值，表示数据库连接串。
        /// </summary>
        public string DbContextConnectionString { get; set; }
        /// <summary>
        /// 获取或设置一个值，表示是否启用软删除过滤器。
        /// </summary>
        public bool IsSoftDeleteFilterEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，表示 <see cref="DataRequest.QueryParam"/> 属性绑定的指定前缀。
        /// </summary>
        public string DataQueryParamKeyPrefix { get; set; }
    }
}