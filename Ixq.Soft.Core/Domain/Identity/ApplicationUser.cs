using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Ixq.Soft.Core.Domain.Identity
{
    public class ApplicationUser : IdentityUser<long>, IEntityBase<long>
    {
        public ApplicationUser() { }

        public ApplicationUser(string userName)
        {
            UserName = userName;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SoteCode { get; set; }
    }
}
