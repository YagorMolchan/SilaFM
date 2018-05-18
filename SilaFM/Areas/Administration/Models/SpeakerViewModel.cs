using System;
using System.ComponentModel.DataAnnotations;
using Pras.Shared.Enums;

namespace Pras.Web.Areas.Administration.Models
{
    public class SpeakerViewModel : BaseViewModel
    {
        [Display(Name = "Тип")]
        [Required(ErrorMessage = "Пожалуйста, выберите {0}")]
        public SpeakerTypes Type { get; set; }

        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Пожалуйста, выберите Страну")]
        public string Country { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Name { get; set; }

        [Display(Name = "Цена до 30 слов, руб.")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Price30 { get; set; }

        [Display(Name = "Цена до 90 слов, руб.")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Price90 { get; set; }

        [Display(Name = "Статус")]
        [Required(ErrorMessage = "Пожалуйста, выберите {0}")]
        public SpeakerStatuses Status { get; set; }

        [Display(Name = "Файл")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Track { get; set; }

        [Display(Name = "Сроки выполнения")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Terms { get; set; }

        [Display(Name = "Новинка")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public bool IsNovelty { get; set; }

        [Display(Name = "Язык")]
        public string Language { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        [Display(Name = "Добавлено")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public DateTime Created { get; set; }
    }
}
