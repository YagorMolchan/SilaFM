using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Pras.Web.Areas.Administration.Models.HelperModels;

namespace Pras.Web.Areas.Administration.Models
{
    public class PersonViewModel : BaseViewModel
    {
        private List<SocialContact> _socials;

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Name { get; set; }

        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Position { get; set; }

        [Display(Name = "Изображение большое")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Image { get; set; }

        [Display(Name = "Изображение маленькое")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string ImageSmall { get; set; }

        [JsonIgnore]
        public string Socials { get; set; }
        [Display(Name = "Соцсети")]
        public List<SocialContact> SocialsList
        {
            get
            {
                if (_socials == null)
                {
                    _socials = string.IsNullOrEmpty(Socials) ? new List<SocialContact>() : JsonConvert.DeserializeObject<List<SocialContact>>(Socials);
                }
                else
                {
                    Socials = JsonConvert.SerializeObject(_socials);
                }
                return _socials;
            }
            set
            {
                _socials = value;
                Socials = JsonConvert.SerializeObject(_socials);
            }
        }

        [Display(Name = "Описание")]
        public string Summary { get; set; }

        [Display(Name = "№ на странице")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public int Order { get; set; }
    }
}
