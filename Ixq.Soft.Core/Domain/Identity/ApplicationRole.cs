using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Ixq.Soft.Core.Domain.Identity
{
    public class ApplicationRole : IdentityRole<long>, IEntityBase<long>
    {
        public ApplicationRole() { }
        public ApplicationRole(string roleName)
        {
            Name = roleName;
        }
        public string Description { get; set; }
        public string SoteCode { get; set; }
    }
}
