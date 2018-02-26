using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Ixq.Soft.Services
{
    public interface IBaseService
    {
        ClaimsPrincipal User { get; }
    }
}
