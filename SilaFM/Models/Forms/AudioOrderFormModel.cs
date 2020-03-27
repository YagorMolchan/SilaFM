using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Pras.Shared.CustomAttributes;

namespace Pras.Web.Models.Forms
{
    public class AudioOrderFormModel:BaseOrderForm
    {
        [JsonIgnore]
        public readonly List<string> ListVoices;
        [JsonIgnore]
        public readonly List<string> ListParameters;
        [JsonIgnore]
        public readonly List<string> ListTypes;
        [JsonIgnore]
        public readonly List<string> ListStyles;

        public AudioOrderFormModel()
        {
            ListParameters = new List<string>
            {
                "Стандарт для радио (mp3, 44kHz, 320kbps, stereo)",
                "Стандарт для радио (wave, 44kHz, 16bit, stereo)",
                "Экономия 1 (mp3, 44kHz, 256kbps, stereo)",
                "Экономия 2 (mp3, 44kHz, 160kbps, stereo)"
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
        }
        [Display(Name = "Тип ролика")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Type { get; set; }

        [Display(Name = "Хронометраж")]
        [RequiredIfNot("IsFreeTiming", "True", ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Timing { get; set; }

        [Display(Name = "Хронометраж свободный")]
        public bool IsFreeTiming { get; set; }

        [Display(Name = "Характер")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Voice { get; set; }

        [Display(Name = "Стиль")]
        public string Style { get; set; }

        [Display(Name = "Количество голосов")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Count { get; set; }

        [Display(Name = "Текст")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Text { get; set; }

        [Display(Name = "Дикторы")]
        [RequiredIfNot("StudioChoice", "True", ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string SpeakerName { get; set; }

        [Display(Name = "На усмотрение студии")]
        public bool StudioChoice { get; set; }

        [Display(Name = "Параметры")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Parameters { get; set; }
    }
}
