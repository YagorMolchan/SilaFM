using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Pras.Web.Models.HelperModels;

namespace Pras.Web.Models
{
    public class PersonViewModel
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public string ImageSmall { get; set; }

        public string Socials { get; set; }
        public List<SocialContact> SocialsList => JsonConvert.DeserializeObject<List<SocialContact>>(Socials??"[]");
        public string Summary { get; set; }
    }
}
