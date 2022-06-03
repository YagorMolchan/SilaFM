using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pras.Web.Areas.Administration.Models.CharacterViewModels
{
    public class CharacterEditViewModel:BaseViewModel
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Изображение")]
        public string ImagePath { get; set; }

        [Display(Name = "Загрузить файл")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Диктор")]
        public Guid? SpeakerId { get; set; }

        public SelectList Speakers { get; set; }
    }
}
