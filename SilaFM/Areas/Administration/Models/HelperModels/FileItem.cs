using System.ComponentModel.DataAnnotations;

namespace Pras.Web.Areas.Administration.Models.HelperModels
{
    public class FileItem
    {
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Name { get; set; }
        [Display(Name = "Файл")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Path { get; set; }
    }
}
