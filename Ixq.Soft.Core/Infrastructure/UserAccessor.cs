using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

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
