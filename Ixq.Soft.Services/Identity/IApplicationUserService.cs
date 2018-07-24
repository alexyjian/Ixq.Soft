using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Core;
using Ixq.Soft.Core.Application.Service;
using Ixq.Soft.Core.Domain.Identity;

namespace Ixq.Soft.Services.Identity
{
    public interface IApplicationUserService : IEntityAppService<ApplicationUser, long>
    {
    }
}
