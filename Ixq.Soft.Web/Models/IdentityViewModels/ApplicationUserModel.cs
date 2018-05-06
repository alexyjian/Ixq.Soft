using System.ComponentModel.DataAnnotations;
using Ixq.Soft.Mvc.DataAnnotations;

namespace Ixq.Soft.Web.Models.IdentityViewModels
{
    [PageConfig(PageTitle = "用户管理", SortField = nameof(UserName))]
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