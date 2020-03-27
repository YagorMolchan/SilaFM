using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Pras.Web.Models.Forms
{
    public class IdentifyVoiceViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        [EmailAddress(ErrorMessage = "Введен неверный email")]
        public string Email { get; set; }

        [Display(Name = "Файл")]
        [JsonIgnore]
        public IFormFile File { get; set; }

        [Display(Name = "Ссылка на ролик")]
        public string Link { get; set; }

        [Display(Name = "Комментарии")]
        public string Comment { get; set; }
    }
}
