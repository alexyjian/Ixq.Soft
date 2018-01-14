using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ixq.Core.Repository;
using Ixq.Soft.Core.Dtos.System;
using Ixq.Soft.Entities.System;
using Ixq.Soft.Repository.System;
using Ixq.Soft.Service.System;
using Ixq.Web.Mvc;

namespace Ixq.Soft.Web.Areas.Admin.Controllers
{
    public class AppRoleController : EntityController<AppRole, AppRoleDto, long>
    {
        public AppRoleController(IAppRoleRepository<AppRole, long> repository) : base(repository)
        {
        }

        protected override void CreateEntityService(RequestContext requestContext)
        {
            EntityService = new AppRoleService(Repository, requestContext, this);
        }
    }
}