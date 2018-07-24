using System;

namespace Ixq.Soft.Core.Domain
{
    /// <summary>
    ///     实体基类。
    /// </summary>
    public class EntityBase : IEntityBase<int>, ICreationAudited, IUpdateAudited, ISoftDeleteAudited
    {
        public virtual long CreationUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public virtual int Id { get; set; }
        public virtual string SoteCode { get; set; }
        public virtual long DeleteUserId { get; set; }
        public virtual DateTime? DeleteTime { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual long UpdateUserId { get; set; }
        public virtual DateTime? UpdateTime { get; set; }
    }
}