using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pras.DAL.Entities
{
    [Table("Settings", Schema = "db_owner")]
    public class Settings : Entity
    {
        //Header
        public string Logo { get; set; }
        public string LogoSubtitle { get; set; }
        public string Phones { get; set; }
        public string Socials { get; set; }
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

        public string FullContacts { get; set; }//remove
        public string Projects { get; set; }//remove
        public string Partners { get; set; }//remove

        //Footer
        public string Principles { get; set; }
        public string Shedule { get; set; }//remove
        public string Contacts { get; set; }//remove
        public string Address { get; set; }//remove
        public string Partnership { get; set; }
        //SEO
        public DateTime Created { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
    }
}
