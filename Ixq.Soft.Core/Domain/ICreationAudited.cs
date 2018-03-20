using System;

namespace Ixq.Soft.Core.Domain
{
    public interface ICreationAudited
    {
        long CreationUserId { get; set; }
        DateTime CreationTime { get; set; }
    }
}