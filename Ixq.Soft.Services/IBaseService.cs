using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Ixq.Soft.Services
{
    /// <summary>
    /// 应用服务接口。
    /// </summary>
    public interface IBaseService
    {
        /// <summary>
        /// 获取此服务的日志记录器。
        /// </summary>
        ILogger Logger { get; }
        /// <summary>
        /// 获取授权用户。
        /// </summary>
        ClaimsPrincipal User { get; }
    }
}