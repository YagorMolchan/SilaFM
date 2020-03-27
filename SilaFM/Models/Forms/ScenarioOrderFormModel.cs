using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pras.Shared.CustomAttributes;

namespace Pras.Web.Models.Forms
{
    public class ScenarioOrderFormModel : BaseOrderForm
    {
        [JsonIgnore]
        public readonly List<string> ListTypes;

        public ScenarioOrderFormModel()
        {
            ListTypes = new List<string>
            {
                "информационная начитка",
                "информационно-музыкальный",
                "имиджевый",
                "игровой",
                "пропевка",
                "рекламная песня",
                "гимн"
            };
        }

        [Display(Name = "Тип ролика")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Type { get; set; }
        [Display(Name = "Хронометраж")]
        [RequiredIfNot("IsFreeTiming", "True", ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Timing { get; set; }
        [Display(Name = "Хронометраж свободный")]
        public bool IsFreeTiming { get; set; }
        [Display(Name = "Предмет рекламы")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string AdvertisingSubject { get; set; }
        [Display(Name = "Целевая аудитория")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string TargetAudience { get; set; }
        [Display(Name = "Рекламное сообщение")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Message { get; set; }
        [Display(Name = "Преимущества")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Benefits { get; set; }
        [Display(Name = "Пожелания по голосам")]
        public string PreferencesVotes { get; set; }
        [Display(Name = "Должно прозвучать")]
        public string MustSound { get; set; }
        [Display(Name = "Корпоративные элементы")]
        public string CorporateElements { get; set; }
    }
}
