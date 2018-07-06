using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Ixq.Soft.Core.Infrastructure
{
    /// <summary>
    /// 授权用于访问器。
    /// </summary>
    public sealed class UserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor accessor)
        {
            _httpContextAccessor = accessor;
        }

        /// <summary>
        /// 获取当前授权用户。
        /// </summary>
        public ClaimsPrincipal User =>
            _httpContextAccessor?.HttpContext.User ?? System.Threading.Thread.CurrentPrincipal as ClaimsPrincipal;
    }
}