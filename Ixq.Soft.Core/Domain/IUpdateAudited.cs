using System;

namespace Ixq.Soft.Core.Domain
{
    public interface IUpdateAudited
    {
        long UpdateUserId { get; set; }
        DateTime? UpdateTime { get; set; }
    }
}