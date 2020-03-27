using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Pras.Web.Models.Forms
{
    public class QuestionareFormModel
    {
        public QuestionareFormModel()
        {
            Age = Age ?? 18;
        }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Name { get; set; }
        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Phone { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Email { get; set; }
        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public int? Age { get; set; }
        [Display(Name = "Место проживания")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Address { get; set; }
        [Display(Name = "Язык")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Languages { get; set; }
        [Display(Name = "Место работы")]
        public string Company { get; set; }
        [Display(Name = "Опыт работы")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Experience { get; set; }
        [Display(Name = "График работы")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Shedule { get; set; }
        [Display(Name = "Возможность начитки дома")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public bool RecordingAtHome { get; set; }
        [Display(Name = "Возможность начитки на работе")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public bool RecordingAtWork { get; set; }
        [Display(Name = "Стоимость за 30 сек")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Price30 { get; set; }
        [Display(Name = "Стоимость за 1 страницу текста")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string PricePage { get; set; }
        [Display(Name = "Портфолио")]
        public List<IFormFile> Files { get; set; }
    }
}
