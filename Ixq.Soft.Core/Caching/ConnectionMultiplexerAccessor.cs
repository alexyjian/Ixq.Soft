﻿using System;
using StackExchange.Redis;

namespace Ixq.Soft.Core.Caching
{
    public class ConnectionMultiplexerAccessor : IConnectionMultiplexerAccessor
    {
        private readonly AppConfig _appConfig;
        private readonly Lazy<ConnectionMultiplexer> _lazyConnectionMultiplexer;
        private ConnectionMultiplexer _connectionMultiplexer;

        public ConnectionMultiplexerAccessor(AppConfig appConfig)
        {
            _appConfig = appConfig;
            _lazyConnectionMultiplexer = new Lazy<ConnectionMultiplexer>(GetConnectionMultiplexer);
        }

        public ConnectionMultiplexer ConnectionMultiplexer
        {
            get => _connectionMultiplexer ?? (_connectionMultiplexer = _lazyConnectionMultiplexer.Value);
            set => _connectionMultiplexer = value;
        }

        private ConnectionMultiplexer GetConnectionMultiplexer()
        {
            var connStr = _appConfig.RedisCacheConnectionString;
            if (string.IsNullOrWhiteSpace(connStr))
                throw new ArgumentNullException(nameof(connStr));
            return ConnectionMultiplexer.Connect(connStr);
        }
    }
}