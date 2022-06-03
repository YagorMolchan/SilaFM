using System.ComponentModel.DataAnnotations;

namespace Pras.Web.Areas.Administration.Models
{
    public class ServiceViewModel:BaseViewModel
    {
        [Display(Name="Название")]
        public string Name { get; set; }

        [Display(Name = "Ссылка")]
        public string Link { get; set; }
    }
}
