﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ixq.Soft.Core;
using Ixq.Soft.Core.Application.Service;
using Ixq.Soft.Core.Extensions;
using Ixq.Soft.Core.Domain.Identity;
using Ixq.Soft.Core.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Ixq.Soft.Services.Identity
{
    public class ApplicationUserService : EntityAppService<ApplicationUser, long>, IApplicationUserService
    {
    }
}