using System.Collections.Generic;

namespace Pras.Web.Models
{
    public class AudioPageViewModel
    {
        public InformationViewModel Information { get; set; }
        public List<AudioViewModel> Audio { get; set; }
    }
}
