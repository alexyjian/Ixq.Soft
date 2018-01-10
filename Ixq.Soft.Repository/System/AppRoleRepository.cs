using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Core.Repository;
using Ixq.Data.Repository;
using Ixq.Soft.Entities.System;

namespace Ixq.Soft.Repository.System
{
    public class AppRoleRepository : RepositoryBase<AppRole, long>, IAppRoleRepository<AppRole, long>
    {
        public AppRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
