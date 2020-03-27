using System.Collections.Generic;

namespace Pras.Web.Models
{
    public class SpeakersPageViewModel
    {
        public InformationViewModel Information { get; set; }
        public List<SpeakerViewModel> Speakers { get; set; }
    }
}
