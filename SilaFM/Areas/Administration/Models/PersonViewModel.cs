using System.ComponentModel.DataAnnotations;

namespace Pras.Web.Areas.Administration.Models
{
    public class PersonViewModel : BaseViewModel
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Name { get; set; }

        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Position { get; set; }

        [Display(Name = "Изображение")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Image { get; set; }

        [Display(Name = "Описание")]
        public string Summary { get; set; }

        [Display(Name = "№ на странице")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public int Order { get; set; }
    }
}
