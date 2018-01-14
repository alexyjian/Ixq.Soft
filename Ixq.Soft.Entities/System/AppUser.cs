using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Ixq.Core.Entity;
using Ixq.Security.Identity;
using Microsoft.AspNet.Identity;

namespace Ixq.Soft.Entities.System
{
    public class AppUser : AppIdentityUser, ICreateSpecification, IUpdateSpecification,
        ISoftDeleteSpecification
    {
        public virtual int Age { get; set; }

        public virtual AppDepartment Department { get; set; }

        [StringLength(2048)]
        public string Description { get; set; }
        [StringLength(200)]
        public string SoteCode { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public virtual DateTime? UpdataDate { get; set; }
        public string UpdateUserId { get; set; }
        public virtual DateTime? DeleteDate { get; set; }
        public string DeleteUserId { get; set; }
        public virtual bool IsDeleted { get; set; }
        public void OnCreateComplete()
        {
            CreateDate = DateTime.Now;
        }
        public void OnUpdataComplete()
        {
            UpdataDate = DateTime.Now;
        }
        public void OnSoftDeleteComplete()
        {
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(AppUserManager<AppUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
