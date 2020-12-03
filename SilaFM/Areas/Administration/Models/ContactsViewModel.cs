using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pras.Web.Areas.Administration.Models.HelperModels;

namespace Pras.Web.Areas.Administration.Models
{
    public class ContactsViewModel : InformationViewModel
    {
        private Contacts _contacts;

        [JsonIgnore]
        public override string Text { get; set; }

        public Contacts Contacts
        {
            get
            {
                if (_contacts == null)
                {
                    _contacts = string.IsNullOrEmpty(Text) ? new Contacts() : JsonConvert.DeserializeObject<Contacts>(Text);
                }
                else
                {
                    Text = JsonConvert.SerializeObject(_contacts);
                }
                return _contacts;
            }
            set
            {
                _contacts = value;
                Text = JsonConvert.SerializeObject(_contacts);
            }
        }
    }

    public class Contacts
    {
        private List<Item> _phones;
        private List<Item> _schedule;
        private List<SocialContact> _socials;

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Почтовый адрес")]
        public string Address { get; set; }

        [JsonIgnore]
        public string Phones { get; set; }
        [Display(Name = "Телефоны")]
        public List<Item> PhonesList
        {
            get
            {
                if (_phones == null)
                {
                    _phones = string.IsNullOrEmpty(Phones) ? new List<Item>() : JsonConvert.DeserializeObject<List<Item>>(Phones);
                }
                else
                {
                    Phones = JsonConvert.SerializeObject(_phones);
                }
                return _phones;
            }
            set
            {
                _phones = value;
                Phones = JsonConvert.SerializeObject(_phones);
            }
        }

        [JsonIgnore]
        public string Schedule { get; set; }
        [Display(Name = "График работы")]
        public List<Item> ScheduleList
        {
            get
            {
                if (_schedule == null)
                {
                    _schedule = string.IsNullOrEmpty(Schedule) ? new List<Item>() : JsonConvert.DeserializeObject<List<Item>>(Schedule);
                }
                else
                {
                    Schedule = JsonConvert.SerializeObject(_schedule);
                }
                return _schedule;
            }
            set
            {
                _schedule = value;
                Schedule = JsonConvert.SerializeObject(_schedule);
            }
        }

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
    }

}
