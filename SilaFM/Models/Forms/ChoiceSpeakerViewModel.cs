using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Pras.Web.Models.Forms
{
    public class ChoiceSpeakerViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        [EmailAddress(ErrorMessage = "Введен неверный email")]
        public string Email { get; set; }

        [Display(Name = "Бюджет")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Budget { get; set; }

        [Display(Name = "Голос")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Voice { get; set; }

        [Display(Name = "Место размещения")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Placement { get; set; }

        [Display(Name = "Задание")]
        [JsonIgnore]
        public IFormFile File { get; set; }

        [Display(Name = "Задание")]
        public string Task { get; set; }

        [Display(Name = "Пожелания по диктору")]
        public string Comment { get; set; }
    }
}
