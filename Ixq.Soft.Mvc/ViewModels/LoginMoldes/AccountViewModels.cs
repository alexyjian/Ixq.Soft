using System.ComponentModel.DataAnnotations;

namespace Ixq.Soft.Mvc.ViewModels.LoginMoldes
{
    public class LoginViewModel
    {
        [Display(Name = "用户名")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "密码")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "验证码")]
        public string Code { get; set; }
        public bool RememberMe { get; set; }
    }
}
