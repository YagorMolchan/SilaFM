using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pras.Shared.CustomAttributes;

namespace Pras.Web.Models.Forms
{
    public class VideoOrderFormModel : BaseOrderForm
    {
        [JsonIgnore]
        public readonly List<string> ListTypes;
        [JsonIgnore]
        public readonly List<string> ListPoints;
        [JsonIgnore]
        public readonly List<string> ListWorks;
        [JsonIgnore]
        public readonly List<string> ListParameters;

        public VideoOrderFormModel()
        {
            ListTypes = new List<string>
            {
                "озвучка видеорекламы",
                "озвучка мультипликации",
                "озвучка документального фильма",
                "синхронное озвучивание",
                "закадровый текст",
                "русскоязычная адаптация",
                "другое"
            };
            ListPoints = new List<string>
            {
                "секунды",
                "минуты",
                "часы",
                "слова",
                "страницы"
            };
            ListWorks = new List<string>
            {
                "только начитка диктора (1-3 варианта)",
                "начитка, простой монтаж и обработка",
                "начитка, монтаж, обработка и музыкальный фон",
                "начитка, монтаж, обработка, музыкальный фон и эффекты",
                "полный объем работы, включая сведение с видео",
                "другое"
            };
            ListParameters = new List<string>
            {
                "Стандарт для видео (wave, 48kHz, 16bit, stereo)",
                "Стандарт для видео (wave, 48kHz, 16bit, mono)",
                "Экономия 1 (mp3, 44kHz, 320kbps, stereo)",
                "Экономия 2 (mp3, 44kHz, 320kbps, mono)"
            };
        }

        [Display(Name = "Вид озвучки")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Type { get; set; }

        [Display(Name = "Объем заказа")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Count { get; set; }

        [Display(Name = "Единицы")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Points { get; set; }

        [Display(Name = "Фронт работ")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Works { get; set; }

        [Display(Name = "Дикторы")]
        [RequiredIfNot("StudioChoice", "True", ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string SpeakerName { get; set; }

        [Display(Name = "На усмотрение студии")]
        public bool StudioChoice { get; set; }

        [Display(Name = "Текст")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Text { get; set; }

        [Display(Name = "Параметры")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Parameters { get; set; }

        [Display(Name = "Ссылка на видео")]
        public string VideoLink1 { get; set; }
        [Display(Name = "Ссылка на видео 2")]
        public string VideoLink2 { get; set; }
    }
}
