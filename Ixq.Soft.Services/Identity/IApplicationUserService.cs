using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Core.Domain.Identity;
using Ixq.Soft.Repository;

namespace Ixq.Soft.Services.Identity
{
    public interface IApplicationUserService : IBaseService
    {
        IList<ApplicationUser> GetApplicationUserList();
    }
}
