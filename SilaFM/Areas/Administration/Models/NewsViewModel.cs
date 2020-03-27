using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Pras.Web.Areas.Administration.Models
{
    public class NewsViewModel : BaseViewModel
    {
        [Display(Name = "Заголовок")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Title { get; set; }
        [Display(Name = "Url-адрес")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        [Remote("CheckUrl", "News", AdditionalFields = "Id", ErrorMessage = "Страница с таким url-адресом уже существует.")]
        public string Url { get; set; }
        [Display(Name = "Текст")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Text { get; set; }

        [Display(Name = "Добавлено")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public DateTime Created { get; set; }
        [Display(Name = "Мета-заголовок")]
        public string MetaTitle { get; set; }
        [Display(Name = "Мета-описание")]
        public string MetaDescription { get; set; }
    }
}
