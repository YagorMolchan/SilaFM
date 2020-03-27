using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Pras.Shared.CustomAttributes;

namespace Pras.Web.Models.Forms
{
    public class SpeakerOrderFormModel : BaseOrderForm
    {
        [JsonIgnore]
        public readonly List<string> ListVoices;
        [JsonIgnore]
        public readonly List<string> ListParameters;

        public SpeakerOrderFormModel()
        {
            ListParameters = new List<string>
            {
                "wave, 44kHz, 16bit, mono",
                "Стандарт для видео (wave, 48kHz, 16bit, mono)",
                "Стандарт для видео (wave, 48kHz, 16bit, stereo)",
                "Стандарт для радио (mp3, 44kHz, 160kbps, stereo)",
                "Стандарт для радио (mp3, 44kHz, 320kbps, stereo)"
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
        }

        [Display(Name = "Диктор")]
        [RequiredIfNot("StudioChoice", "True", ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string SpeakerName { get; set; }

        [Display(Name = "На усмотрение студии")]
        public bool StudioChoice { get; set; }

        [Display(Name = "Характер")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Voice { get; set; }

        [Display(Name = "Текст")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Text { get; set; }

        [Display(Name = "Хронометраж")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Timing { get; set; }

        [Display(Name = "Параметры")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Parameters { get; set; }
    }
}