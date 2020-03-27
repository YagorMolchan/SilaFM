using System;
using System.ComponentModel.DataAnnotations;

namespace Pras.Web.Areas.Administration.Models
{
    public class ReviewViewModel : BaseViewModel
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Name { get; set; }

        [Display(Name = "Изображение")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Image { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Text { get; set; }

        [Display(Name = "Добавлен")]
        public DateTime Created { get; private set; }
    }
}
