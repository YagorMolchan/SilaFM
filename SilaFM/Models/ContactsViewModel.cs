using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pras.Web.Models.HelperModels;

namespace Pras.Web.Models
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

        public string Email { get; set; }
        public string Address { get; set; }

        [JsonIgnore]
        public string Phones { get; set; }
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
