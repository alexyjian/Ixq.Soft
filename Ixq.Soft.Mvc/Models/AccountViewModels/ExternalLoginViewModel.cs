using System.ComponentModel.DataAnnotations;

namespace Ixq.Soft.Mvc.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
