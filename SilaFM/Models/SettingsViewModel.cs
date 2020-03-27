using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Pras.Web.Models.HelperModels;

namespace Pras.Web.Models
{
    public class SettingsViewModel
    {
        //Header
        public string Logo { get; set; }
        public string LogoSubtitle { get; set; }
        public string Phones { get; set; }
        //Body
        public string About { get; set; }

        public string Block1Title { get; set; }
        public string Block2Title { get; set; }
        public string Block3Title { get; set; }
        public string Block4Title { get; set; }
        public string Block5Title { get; set; }
        public string Block6Title { get; set; }

        public string Block1Subtitle { get; set; }
        public string Block2Subtitle { get; set; }
        public string Block3Subtitle { get; set; }
        public string Block4Subtitle { get; set; }
        public string Block5Subtitle { get; set; }
        public string Block6Subtitle { get; set; }

        public string Block1Link { get; set; }
        public string Block2Link { get; set; }
        public string Block3Link { get; set; }
        public string Block4Link { get; set; }
        public string Block5Link { get; set; }
        public string Block6Link { get; set; }

        [JsonIgnore]
        public string FullContacts { get; set; }
        [JsonIgnore]
        public string Projects { get; set; }
        [JsonIgnore]
        public string Partners { get; set; }

        public List<ItemGroup> FullContactsGroups => JsonConvert.DeserializeObject<List<ItemGroup>>(FullContacts ?? "");

        public List<Item> ProjectsList => JsonConvert.DeserializeObject<List<Item>>(Projects ?? "");

        public List<Item> PartnersList => JsonConvert.DeserializeObject<List<Item>>(Partners ?? "");

        //Footer
        public string Principles { get; set; }
        public string Shedule { get; set; }
        public string Contacts { get; set; }
        public string Address { get; set; }
        public string Partnership { get; set; }
        //SEO
        public DateTime Created { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
    }
}
