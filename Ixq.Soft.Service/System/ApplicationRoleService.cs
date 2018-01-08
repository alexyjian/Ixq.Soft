﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using Ixq.Core.Repository;
using Ixq.Soft.Core.Dtos.System;
using Ixq.Soft.Entities.System;
using Ixq.Soft.Service.Interface;
using Ixq.Web.Mvc;

namespace Ixq.Soft.Service.System
{
    public class ApplicationRoleService : EntityService<ApplicationRole, ApplicationRoleDto, long> , IApplicationRoleService
    {
        public ApplicationRoleService(IRepositoryBase<ApplicationRole, long> repository, RequestContext requestContxt,
            IEntityControllerDescriptor entityControllerData) : base(repository, requestContxt, entityControllerData)
        {
        }
    }
}
