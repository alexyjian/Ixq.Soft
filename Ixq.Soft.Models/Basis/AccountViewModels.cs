using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ixq.Soft.Models.Basis
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
        [Required]
        public string Code { get; set; }
        public bool RememberMe { get; set; }
    }
}
