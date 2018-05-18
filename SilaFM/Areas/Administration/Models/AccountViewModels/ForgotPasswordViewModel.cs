using System.ComponentModel.DataAnnotations;

namespace Pras.Web.Areas.Administration.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
