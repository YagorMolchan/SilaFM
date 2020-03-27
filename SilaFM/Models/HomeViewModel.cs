using System.Collections.Generic;

namespace Pras.Web.Models
{
    public class HomeViewModel
    {
        public SettingsViewModel Settings { get; set; }
        public List<string> LastProjects { get; set; }
        public List<string> LastSpeakers { get; set; }
        public List<ReviewViewModel> LastReviews { get; set; }
    }
}
