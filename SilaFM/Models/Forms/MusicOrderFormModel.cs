using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pras.Shared.CustomAttributes;

namespace Pras.Web.Models.Forms
{
    public class MusicOrderFormModel : BaseOrderForm
    {
        [JsonIgnore]
        public readonly List<string> ListPurposes;
        [JsonIgnore]
        public readonly List<string> ListStyles;
        [JsonIgnore]
        public List<string> ListVoices { get; set; }
        [JsonIgnore]
        public List<string> ListTempos { get; set; }
        [JsonIgnore]
        public List<string> ListInstruments { get; set; }

        public MusicOrderFormModel()
        {
            ListPurposes = new List<string>
            {
                "радио",
                "телевидение",
                "торговый центр",
                "интернет",
                "компьютерная игра",
                "презентация",
                "песня в подарок",
                "другое"
            };
            ListStyles = new List<string>
            {
                "поп",
                "рок",
                "джаз",
                "шансон",
                "блюз",
                "романс",
                "танго",
                "фолк (народный)",
                "гимн",
                "марш",
                "диско",
                "рок-н-ролл",
                "р-н-б",
                "рэп",
                "корпоратив"
            };
            ListVoices = new List<string>
            {
                "веселый (мажорный)",
                "грустный (минорный)",
                "лирический",
                "агрессивный",
                "задорный",
                "спокойный",
                "торжественный",
                "сексуальный",
                "уверенный (серьезный)",
                "как в примере"
            };
            ListTempos = new List<string>
            {
                "медленный",
                "умеренный",
                "быстрый",
                "очень быстрый"
            };
            ListInstruments = new List<string>
            {
                "фортепиано",
                "оркестровка",
                "современные",
                "электронные",
                "этнические",
                "как в примере"
            };
        }


        [Display(Name = "Назначение")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Purpose { get; set; }

        [Display(Name = "Стиль оформления")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Style { get; set; }

        [Display(Name = "Хронометраж")]
        [RequiredIfNot("IsFreeTiming", "True", ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Timing { get; set; }

        [Display(Name = "на усмотрение студии")]
        public bool IsFreeTiming { get; set; }

        [Display(Name = "Похожие песни (если есть)")]
        public string SimilarSongs { get; set; }

        [Display(Name = "Характер")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Voice { get; set; }

        [Display(Name = "Темп")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Tempo { get; set; }

        [Display(Name = "Инструменты")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Instruments { get; set; }

        [Display(Name = "Вокальное оформление")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Vocal { get; set; }

        [Display(Name = "Дополнительная информация")]
        public string Info { get; set; }
    }
}
