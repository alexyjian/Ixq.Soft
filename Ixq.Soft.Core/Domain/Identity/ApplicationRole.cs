using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Ixq.Soft.Core.Domain.Identity
{
    public class ApplicationRole : IdentityRole<long>, IEntityBase<long>, ICreationAudited, IUpdateAudited, ISoftDeleteAudited
    {
        public ApplicationRole() { }
        public ApplicationRole(string roleName)
        {
            Name = roleName;
        }
        public string Description { get; set; }
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
