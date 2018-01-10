using Ixq.Core.Entity;
using Ixq.Core.Repository;

namespace Ixq.Soft.Repository.System
{
    public interface IAppRoleRepository<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
    }
}
