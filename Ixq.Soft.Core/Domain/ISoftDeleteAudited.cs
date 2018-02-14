using System;

namespace Ixq.Soft.Core.Domain
{
    public interface ISoftDeleteAudited
    {
        long DeleteUserId { get; set; }
        DateTime? DeleteTime { get; set; }
        bool IsDeleted { get; set; }
    }
}