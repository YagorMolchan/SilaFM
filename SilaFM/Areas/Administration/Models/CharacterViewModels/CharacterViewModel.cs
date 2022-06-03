using System.ComponentModel.DataAnnotations;

namespace Pras.Web.Areas.Administration.Models.CharacterViewModels
{
    public class CharacterViewModel:BaseViewModel
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Диктор")]
        public string SpeakerName { get; set; }
    }
}
