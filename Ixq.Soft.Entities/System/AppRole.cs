using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Ixq.Core.Entity;
using Ixq.Security.Identity;

namespace Ixq.Soft.Entities.System
{
    public class AppRole : AppIdentityRole, ICreateSpecification, IUpdataSpecification,
        ISoftDeleteSpecification
    {
        public AppRole()
        {
        }

        public AppRole(string name) : base(name)
        {
        }

        public virtual ICollection<AppMenu> Menus { get; set; }

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