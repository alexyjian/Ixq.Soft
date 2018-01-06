using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Core.Repository;
using Ixq.Data.Repository;
using Ixq.Soft.Entities.System;
using Ixq.Soft.Repository.Interface;

namespace Ixq.Soft.Repository.System
{
    public class ApplicationRoleRepository : RepositoryBase<ApplicationRole, long>, IApplicationRoleRepository
    {
        public ApplicationRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
