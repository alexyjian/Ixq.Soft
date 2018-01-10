using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ixq.Core.Entity;
using Ixq.Core.Repository;

namespace Ixq.Soft.Repository.Interface
{
    public interface IAppRoleRepository<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
    }
}
