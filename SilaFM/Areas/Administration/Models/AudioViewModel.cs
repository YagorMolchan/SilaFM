﻿using System;
using System.ComponentModel.DataAnnotations;
using Pras.Shared.Enums;

namespace Pras.Web.Areas.Administration.Models
{
    public class AudioViewModel : BaseViewModel
    {
        public AudioViewModel()
        {
            Created = Created == DateTime.MinValue ? DateTime.Now : Created;
        }

        [Display(Name = "Тип")]
        [Required(ErrorMessage = "Пожалуйста, выберите {0}")]
        public AudioTypes Type { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Summary { get; set; }

        [Display(Name = "Файл")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Path { get; set; }

        [Display(Name = "Новинка")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public bool IsNovelty { get; set; }

        [Display(Name = "Добавлено")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public DateTime Created { get; set; }
    }
}
