using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pras.Shared.Enums;

namespace Pras.Web.Areas.Administration.Models.HelperModels
{
    public class SocialContact
    {
        public SocialContact()
        {
            Link = Link ?? Mask;
        }
        public SocialsType Type { get; set; }
        public string Link { get; set; }

        public string Mask
        {
            get
            {
                switch (Type)
                {
                    case SocialsType.Facebook: return "https://facebook.com/";
                    case SocialsType.Instagram: return "https://instagram.com/";
                    case SocialsType.LinkedIn: return "https://linkedin.com/";
                    case SocialsType.Skype: return "skype:username";
                    case SocialsType.Telegram: return "https://telegram.me/username";
                    case SocialsType.Viber: return "viber://chat?number=+71234567890";
                    case SocialsType.Vk: return "https://vk.com/";
                    case SocialsType.WhatsApp: return "https://wa.me/71234567890";
                    default: return "";
                }
            }
        }
    }
}
