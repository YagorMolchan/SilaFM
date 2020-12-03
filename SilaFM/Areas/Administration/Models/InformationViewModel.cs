using System;
using System.ComponentModel.DataAnnotations;
using Pras.Shared.Enums;

namespace Pras.Web.Areas.Administration.Models
{
    public class InformationViewModel : BaseViewModel
    {
        [Display(Name = "Тип")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public InformationTypes Type { get; set; }

        [Display(Name = "Заголовок")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Title { get; set; }

        [Display(Name = "Текст")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public virtual string Text { get; set; }

        [Display(Name = "Добавлено")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public DateTime Created { get; set; }

        [Display(Name = "Мета-заголовок")]
        public string MetaTitle { get; set; }

        [Display(Name = "Мета-описание")]
        public string MetaDescription { get; set; }
    }
}
