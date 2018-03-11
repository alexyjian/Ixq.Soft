using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Ixq.Soft.Mvc.DataAnnotations;

namespace Ixq.Soft.Mvc.Models.IdentityViewModels
{
    public class ApplicationUserModel
    {
        [Required]
        public long Id { get; set; }

        [Searcher]
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Searcher]
        [Display(Name = "电子邮箱")]
        public string Email { get; set; }

        [Searcher]
        [Display(Name = "电话号码")]
        public string PhoneNumber { get; set; }

        [Display(Name = "是否锁定")]
        public bool LockoutEnabled { get; set; }
    }
}