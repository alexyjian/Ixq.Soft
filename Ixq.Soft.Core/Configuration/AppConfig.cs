namespace Ixq.Soft.Core.Configuration
{
    /// <summary>
    /// 应用程序配置信息。
    /// </summary>
    public class AppConfig
    {
        public bool RedisCacheEnabled { get; set; }
        public string RedisCacheKeyPrefix { get; set; }
        public string RedisCacheConnectionString { get; set; }
        public string DbContextConnectionString { get; set; }

    }
}
