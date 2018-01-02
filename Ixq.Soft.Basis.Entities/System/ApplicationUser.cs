using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Ixq.Core.Entity;
using Ixq.Security.Identity;
using Microsoft.AspNet.Identity;

namespace Ixq.Soft.Basis.Entities.System
{
    public class ApplicationUser : AppIdentityUser, ICreateSpecification, IUpdataSpecification,
        ISoftDeleteSpecification
    {
        public virtual int Age { get; set; }
        [StringLength(2048)]
        public string Description { get; set; }
        [StringLength(200)]
        public string SoteCode { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime? UpdataDate { get; set; }
        public virtual DateTime? DeleteDate { get; set; }
        public virtual bool IsDeleted { get; set; }
        public void OnCreateComplete()
        {
        }
        public void OnUpdataComplete()
        {
        }
        public void OnSoftDeleteComplete()
        {
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(AppUserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
