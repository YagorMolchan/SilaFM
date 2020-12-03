using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Pras.Web.Areas.Administration.Models.HelperModels;

namespace Pras.Web.Areas.Administration.Models
{
    public class SettingsViewModel : BaseViewModel
    {
        private List<ItemGroup> _fullContacts;
        private List<Item> _projects;
        private List<Item> _partners;

        //Header
        [Display(Name = "Логотип")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Logo { get; set; }
        [Display(Name = "Подпись под логотипом")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string LogoSubtitle { get; set; }
        [Display(Name = "Телефоны в шапке")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Phones { get; set; }
        //Body
        [Display(Name = "Информация о нас")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string About { get; set; }

        [Display(Name = "Блок №1. Заголовок")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Block1Title { get; set; }
        [Display(Name = "Блок №2. Заголовок")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Block2Title { get; set; }
        [Display(Name = "Блок №3. Заголовок")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Block3Title { get; set; }
        [Display(Name = "Блок №4. Заголовок")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Block4Title { get; set; }
        [Display(Name = "Блок №5. Заголовок")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Block5Title { get; set; }
        [Display(Name = "Блок №6. Заголовок")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Block6Title { get; set; }

        [Display(Name = "Блок №1. Подзаголовок")]
        public string Block1Subtitle { get; set; }
        [Display(Name = "Блок №2. Подзаголовок")]
        public string Block2Subtitle { get; set; }
        [Display(Name = "Блок №3. Подзаголовок")]
        public string Block3Subtitle { get; set; }
        [Display(Name = "Блок №4. Подзаголовок")]
        public string Block4Subtitle { get; set; }
        [Display(Name = "Блок №5. Подзаголовок")]
        public string Block5Subtitle { get; set; }
        [Display(Name = "Блок №6. Подзаголовок")]
        public string Block6Subtitle { get; set; }

        [Display(Name = "Блок №1. Ссылка")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Block1Link { get; set; }
        [Display(Name = "Блок №2. Ссылка")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Block2Link { get; set; }
        [Display(Name = "Блок №3. Ссылка")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Block3Link { get; set; }
        [Display(Name = "Блок №4. Ссылка")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Block4Link { get; set; }
        [Display(Name = "Блок №5. Ссылка")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Block5Link { get; set; }
        [Display(Name = "Блок №6. Ссылка")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Block6Link { get; set; }

        [JsonIgnore]
        public string FullContacts { get; set; }
        [JsonIgnore]
        public string Projects { get; set; }
        [JsonIgnore]
        public string Partners { get; set; }

        [Display(Name = "Наши контакты")]
        public List<ItemGroup> FullContactsGroups
        {
            get
            {
                if (_fullContacts == null)
                {
                    _fullContacts = string.IsNullOrEmpty(FullContacts) ? new List<ItemGroup>() : JsonConvert.DeserializeObject<List<ItemGroup>>(FullContacts);
                }
                else
                {
                    FullContacts = JsonConvert.SerializeObject(_fullContacts);
                }

                return _fullContacts;
            }
            set
            {
                FullContacts = JsonConvert.SerializeObject(value);
                _fullContacts = value;
            }
        }
        [Display(Name = "Наши проекты")]
        public List<Item> ProjectsList
        {
            get
            {
                if (_projects == null)
                {
                    _projects = string.IsNullOrEmpty(Projects) ? new List<Item>() : JsonConvert.DeserializeObject<List<Item>>(Projects);
                }
                else
                {
                    Projects = JsonConvert.SerializeObject(_projects);
                }
                return _projects;
            }
            set
            {
                _projects = value;
                Projects = JsonConvert.SerializeObject(_projects);
            }
        }
        [Display(Name = "Наши партнеры")]
        public List<Item> PartnersList
        {
            get
            {
                if (_partners == null)
                {
                    if (string.IsNullOrEmpty(Partners))
                        _partners = new List<Item>();
                    else
                    {
                        _partners = JsonConvert.DeserializeObject<List<Item>>(Partners);
                    }
                }
                else
                {
                    Partners = JsonConvert.SerializeObject(_partners);
                }
                return _partners;
            }
            set
            {
                _partners = value;
                Partners = JsonConvert.SerializeObject(_partners);
            }
        }

        //Footer
        [Display(Name = "Наши принципы")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Principles { get; set; }
        [Display(Name = "График работы")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Shedule { get; set; }
        [Display(Name = "Контакты")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Contacts { get; set; }
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Address { get; set; }
        [Display(Name = "Сотрудничество")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Partnership { get; set; }
        //SEO
        [Display(Name = "Добавлено")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Created { get; set; }
        [Display(Name = "Мета-заголовок")]
        public string MetaTitle { get; set; }
        [Display(Name = "Мета-описание")]
        public string MetaDescription { get; set; }
    }
}
