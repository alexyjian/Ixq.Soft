using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Ixq.Core.Entity;
using Ixq.Security.Identity;

namespace Ixq.Soft.Entities.System
{
    public class AppRole : AppIdentityRole, ICreateSpecification, IUpdateSpecification,
        ISoftDeleteSpecification
    {
        #region const

        public const int DescriptionMaxLength = 2048;
        public const int SoteCodeMaxLength = 200;

        #endregion
        public AppRole()
        {
        }

        public AppRole(string name) : base(name)
        {
        }

        public string Description { get; set; }
        public string SoteCode { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? UpdataDate { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string DeleteUserId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<AppMenuRole> Menus { get; set; }

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