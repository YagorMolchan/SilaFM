using System.ComponentModel.DataAnnotations;

namespace Pras.Web.Models.Forms
{
    public class PopupVisaFormModel
    {
        [Display(Name = "Номер счета")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Account { get; set; }

        [Display(Name = "Сумма")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Amount { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string FirstName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        [EmailAddress(ErrorMessage = "Введен неверный email")]
        public string Email { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Город")]
        public string City { get; set; }
    }
}
