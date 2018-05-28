using System;

namespace Ixq.Soft.Core.Domain
{
    public class EntityBase : IEntityBase<int>, ICreationAudited, IUpdateAudited, ISoftDeleteAudited
    {
        public int Id { get; set; }
        public string SoteCode { get; set; }
        public long CreationUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long UpdateUserId { get; set; }
        public DateTime? UpdateTime { get; set; }
        public long DeleteUserId { get; set; }
        public DateTime? DeleteTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}