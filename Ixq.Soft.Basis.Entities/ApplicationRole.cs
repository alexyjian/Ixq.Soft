using System;
using System.ComponentModel.DataAnnotations;
using Ixq.Core.Entity;
using Ixq.Security.Identity;

namespace Ixq.Soft.Basis.Entities
{
    public class ApplicationRole : AppIdentityRole, ICreateSpecification, IUpdataSpecification,
        ISoftDeleteSpecification
    {
        public ApplicationRole()
        {
        }

        public ApplicationRole(string name) : base(name)
        {
        }

        [StringLength(2048)]
        public string Description { get; set; }
        [StringLength(200)]
        public string SoteCode { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdataDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }


        public void OnCreateComplete()
        {
            CreateDate = DateTime.Now;
        }

        public void OnUpdataComplete()
        {
        }

        public void OnSoftDeleteComplete()
        {
        }
    }
}