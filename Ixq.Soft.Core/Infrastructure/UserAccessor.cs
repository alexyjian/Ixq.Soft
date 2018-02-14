using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Ixq.Soft.Core.Infrastructure
{
    public sealed class UserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor accessor)
        {
            _httpContextAccessor = accessor;
        }

        public ClaimsPrincipal User =>
            _httpContextAccessor?.HttpContext.User ?? System.Threading.Thread.CurrentPrincipal as ClaimsPrincipal;
    }
}