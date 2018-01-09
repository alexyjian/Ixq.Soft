using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Soft.Core.Dtos.System;
using Ixq.Soft.Entities.System;
using Ixq.Web.Mvc;

namespace Ixq.Soft.Service.Interface
{
    public interface IApplicationRoleService : IEntityService<AppRole, ApplicationRoleDto, long>
    {
    }
}
