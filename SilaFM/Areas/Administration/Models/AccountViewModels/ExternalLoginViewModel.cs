using System.ComponentModel.DataAnnotations;

namespace Pras.Web.Areas.Administration.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
