using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ixq.Core.Repository;
using Ixq.Soft.Core.Dtos.System;
using Ixq.Soft.Entities.System;
using Ixq.Web.Mvc;

namespace Ixq.Soft.Web.Areas.Admin.Controllers
{
    public class ApplicationRoleController : EntityController<ApplicationRole, ApplicationRoleDto, long>
    {
        public ApplicationRoleController(IRepositoryBase<ApplicationRole, long> repository) : base(repository)
        {
        }
    }
}