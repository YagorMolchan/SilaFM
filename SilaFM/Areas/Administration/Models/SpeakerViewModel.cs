using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Pras.Shared.Enums;
using Pras.Web.Areas.Administration.Models.HelperModels;

namespace Pras.Web.Areas.Administration.Models
{
    public class SpeakerViewModel : BaseViewModel
    {
        private VoiceParams _params;
        private List<FileItem> _languages;
        private List<FileItem> _voices;
        private List<FileItem> _workTypes;
        private List<FileItem> _industries;
        private List<FileItem> _videos;
        private List<int> _workingHours;
        private List<int> _workingDays;

        public SpeakerViewModel()
        {
            Rating = 5;
            VacationStartDate = DateTime.Today;
            VacationEndDate = DateTime.Today.AddDays(14);
        }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Name { get; set; }

        [Display(Name = "Url")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Url { get; set; }
        [Display(Name = "Особенности")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Summary { get; set; }
        [Display(Name = "Фото")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Image { get; set; }
        [Display(Name = "Рейтинг")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        [Range(1, 5, ErrorMessage = "Значение должно быть от 1 до 5")]
        public int Rating { get; set; }

        [Display(Name = "Общее демо")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Demo { get; set; }
        [Display(Name = "Демо рекламы")]
        public string DemoAdvertising { get; set; }
        [Display(Name = "Демо озвучки")]
        public string DemoVoiceOver { get; set; }
        [Display(Name = "Портфолио брендов")]
        public string Portfolio { get; set; }

        [Display(Name = "Описание голоса")]
        public string VoiceDescription { get; set; }
        [Display(Name = "Характеристики голоса")]
        public string Params { get; set; }
        public VoiceParams VoiceParams
        {
            get
            {
                if (_params == null)
                {
                    if (string.IsNullOrEmpty(Params))
                        _params = new VoiceParams();
                    else
                    {
                        _params = JsonConvert.DeserializeObject<VoiceParams>(Params);
                    }
                }
                else
                {
                    Params = JsonConvert.SerializeObject(_params);
                }

                return _params;
            }
            set
            {
                Params = JsonConvert.SerializeObject(value);
                _params = value;
            }
        }

        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public VoiceAge VoiceAge { get; set; }
        [Display(Name = "Пол голоса")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public Gender Gender { get; set; }

        [Display(Name = "Цена до 30 слов")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Price30 { get; set; }
        [Display(Name = "Цена до 90 слов")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Price90 { get; set; }
        [Display(Name = "Цена за страницу текста")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string PricePage { get; set; }
        [Display(Name = "Валюта")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public Currency Currency { get; set; }
        [Display(Name = "Ценовая категория")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public PriceCategory PriceCategory { get; set; }

        [Display(Name = "Часы работы")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string WorkingHours { get; set; }
        public List<int> ListHours
        {
            get
            {
                if (_workingHours == null)
                {
                    _workingHours = string.IsNullOrEmpty(WorkingHours) ? new List<int>() : JsonConvert.DeserializeObject<List<int>>(WorkingHours);
                }
                else
                {
                    WorkingHours = JsonConvert.SerializeObject(_workingHours);
                }

                return _workingHours;
            }
            set
            {
                WorkingHours = JsonConvert.SerializeObject(value);
                _workingHours = value;
            }
        }
        [Display(Name = "Рабочие дни")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string WorkingDays { get; set; }
        public List<int> ListDays
        {
            get
            {
                if (_workingDays == null)
                {
                    _workingDays = string.IsNullOrEmpty(WorkingDays) ? new List<int>() : JsonConvert.DeserializeObject<List<int>>(WorkingDays);
                }
                else
                {
                    WorkingDays = JsonConvert.SerializeObject(_workingDays);
                }

                return _workingDays;
            }
            set
            {
                WorkingDays = JsonConvert.SerializeObject(value);
                _workingDays = value;
            }
        }
        [Display(Name = "Отпуск (начало)")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public DateTime VacationStartDate { get; set; }
        [Display(Name = "Отпуск (конец)")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public DateTime VacationEndDate { get; set; }
        [Display(Name = "Сроки выполнения")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Terms { get; set; }
        [Display(Name = "Возможность режиссирования")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public bool CanDirect { get; set; }

        [Display(Name = "Языки")]
        public string Languages { get; set; }
        public List<FileItem> VoiceLanguages
        {
            get
            {
                if (_languages == null)
                {
                    _languages = string.IsNullOrEmpty(Languages) ? new List<FileItem>() : JsonConvert.DeserializeObject<List<FileItem>>(Languages);
                }
                else
                {
                    Languages = JsonConvert.SerializeObject(_languages);
                }

                return _languages;
            }
            set
            {
                Languages = JsonConvert.SerializeObject(value);
                _languages = value;
            }
        }
        [Display(Name = "Характеристика голоса")]
        public string Voices { get; set; }
        public List<FileItem> VoiceCharacteristics
        {
            get
            {
                if (_voices == null)
                {
                    _voices = string.IsNullOrEmpty(Voices) ? new List<FileItem>() : JsonConvert.DeserializeObject<List<FileItem>>(Voices);
                }
                else
                {
                    Voices = JsonConvert.SerializeObject(_voices);
                }

                return _voices;
            }
            set
            {
                Voices = JsonConvert.SerializeObject(value);
                _voices = value;
            }
        }
        [Display(Name = "Виды работ")]
        public string WorkTypes { get; set; }
        public List<FileItem> VoiceWorkTypes
        {
            get
            {
                if (_workTypes == null)
                {
                    _workTypes = string.IsNullOrEmpty(WorkTypes) ? new List<FileItem>() : JsonConvert.DeserializeObject<List<FileItem>>(WorkTypes);
                }
                else
                {
                    WorkTypes = JsonConvert.SerializeObject(_workTypes);
                }

                return _workTypes;
            }
            set
            {
                WorkTypes = JsonConvert.SerializeObject(value);
                _workTypes = value;
            }
        }
        [Display(Name = "Индустрии")]
        public string Industries { get; set; }
        public List<FileItem> VoiceIndustries
        {
            get
            {
                if (_industries == null)
                {
                    _industries = string.IsNullOrEmpty(Industries) ? new List<FileItem>() : JsonConvert.DeserializeObject<List<FileItem>>(Industries);
                }
                else
                {
                    Industries = JsonConvert.SerializeObject(_industries);
                }

                return _industries;
            }
            set
            {
                Industries = JsonConvert.SerializeObject(value);
                _industries = value;
            }
        }
        [Display(Name = "Видео")]
        public string Videos { get; set; }
        public List<FileItem> ListVideos
        {
            get
            {
                if (_videos == null)
                {
                    _videos = string.IsNullOrEmpty(Videos) ? new List<FileItem>() : JsonConvert.DeserializeObject<List<FileItem>>(Videos);
                }
                else
                {
                    Videos = JsonConvert.SerializeObject(_videos);
                }

                return _videos;
            }
            set
            {
                Videos = JsonConvert.SerializeObject(value);
                _videos = value;
            }
        }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        [Display(Name = "Тип")]
        [Required(ErrorMessage = "Пожалуйста, выберите {0}")]
        public SpeakerTypes Type { get; set; }
        [Display(Name = "Национальность")]
        [Required(ErrorMessage = "Пожалуйста, выберите Страну")]
        public string Nationality { get; set; }
        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Пожалуйста, выберите Страну")]
        public string Country { get; set; }
        [Display(Name = "Статус")]
        [Required(ErrorMessage = "Пожалуйста, выберите {0}")]
        public SpeakerStatuses Status { get; set; }

        [Display(Name = "Новинка")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public bool IsNovelty { get; set; }
        [Display(Name = "VIP")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public bool IsVip { get; set; }

        [Display(Name = "Добавлено")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public DateTime Created { get; set; }

        public Dictionary<string, string> TermsList = new Dictionary<string, string>()
        {
            {"0,5", "30 минут" },
            {"1", "1 час" },
            {"2", "2 часа" },
            {"3", "3 часа" },
            {"6", "6 часов" },
            {"24", "1 день" },
        };
    }
}
