using System.ComponentModel.DataAnnotations;

namespace Pras.Web.Models.Forms
{
    public class OrderCallFormModel
    {
        [Display(Name = "Ваше имя")]
        [Required(ErrorMessage = "Введите ваше имя")]
        public string Name { get; set; }

        [Display(Name = "Ваш номер телефона")]
        [Required(ErrorMessage = "Введите ваш номер телефона")]
        public string Phone { get; set; }

        [Display(Name = "Ваш email")]
        [EmailAddress(ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; set; }

        [Display(Name = "Ваше сообщение")]
        public string Message { get; set; }
    }
}
