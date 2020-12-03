using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Pras.Shared.Enums;
using Pras.Shared.Enums.Extensions;
using Pras.Web.Models.HelperModels;

namespace Pras.Web.Models
{
    public class SpeakerViewModel
    {
        private List<FileItem> _languages;

        public SpeakerTypes Type { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Url { get; set; }

        public int Rating { get; set; }

        public string Price30 { get; set; }
        public string Price90 { get; set; }
        public string PricePage { get; set; }
        public Currency Currency { get; set; }
        public SpeakerStatuses Status { get; set; }
        public string Demo { get; set; }
        public float Terms { get; set; }
        public string TermsStr
        {
            get
            {
                var key = Terms.ToString("0.#");
                return TermsList.ContainsKey(key) ? TermsList[key] : null;
            }
        }
        public bool IsNovelty { get; set; }
        public Gender Gender { get; set; }
        public bool CanDirect { get; set; }

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

        public DateTime? VacationStartDate { get; set; }
        public DateTime? VacationEndDate { get; set; }

        public string Comment { get; set; }

        public string CommentRaw => Comment?.Replace(Environment.NewLine, "<br/>");

        public DateTime Created { get; set; }

        public string GroupTitle
        {
            get
            {
                if (Type == SpeakerTypes.Child)
                    return "Детские голоса от 5-ти до 14 лет";
                if (Type == SpeakerTypes.Federal)
                {
                    var title = EnumExtensions.GetDescription(Type);
                    if (Country == SpeakerCountries.Russia.ToString())
                        title += " России";
                    if (Country == SpeakerCountries.Ukraine.ToString())
                        title += " Украины";
                    title += ". " + (Gender == Gender.Male ? "Мужские голоса" : "Женские голоса");
                    return title;
                }
                if (Type == SpeakerTypes.Speaker)
                {
                    var title = "Дикторы";
                    if (Country == SpeakerCountries.Russia.ToString())
                        title += " России";
                    if (Country == SpeakerCountries.Ukraine.ToString())
                        title += " Украины";
                    if (Country == SpeakerCountries.Other.ToString())
                        title = "Иностранные дикторы";
                    title += ". " + (Gender == Gender.Male ? "Мужские голоса" : "Женские голоса");
                    return title;
                }

                return EnumExtensions.GetDescription(Type);
            }
        }


        public Dictionary<string, string> TermsList = new Dictionary<string, string>()
        {
            {"0,5", "30 минут" },
            {"1", "1 час" },
            {"2", "2 часа" },
            {"3", "3 часа" },
            {"6", "6 часов" },
            {"24", "1 день" },
        };

        public string GetCurrency(string price)
        {
            if (Regex.IsMatch(price, "^([^0-9]*)$"))
            {
                return "";
            }
            switch (Currency)
            {
                case Currency.Dollars: return "$";
                case Currency.Euro: return "Euro";
                case Currency.Hryvnia: return "грн.";
                case Currency.Rubles: return "руб.";
                default: return Currency.ToString();
            }
        }
    }
}
