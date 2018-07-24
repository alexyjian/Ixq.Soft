using System;
using Microsoft.AspNetCore.Identity;

namespace Ixq.Soft.Core.Domain.Identity
{
    public class ApplicationUser : IdentityUser<long>, IEntityBase<long>, ICreationAudited, IUpdateAudited,
        ISoftDeleteAudited
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName)
        {
            UserName = userName;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public long CreationUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public string SoteCode { get; set; }
        public long DeleteUserId { get; set; }
        public DateTime? DeleteTime { get; set; }
        public bool IsDeleted { get; set; }
        public long UpdateUserId { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}