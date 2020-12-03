using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pras.Web.Models.Forms
{
    public class PopupPaymentFormModel
    {
        [Display(Name = "Тип")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public int Type { get; set; }

        [Display(Name = "Дата")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Date { get; set; }

        [Display(Name = "Номер счета")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Account { get; set; }

        [Display(Name = "Сумма")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Amount { get; set; }

        [Display(Name = "Способ оплаты")]
        //[Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string PaymentMethod { get; set; }

        [Display(Name = "Плательщик")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Payer { get; set; }

        [Display(Name = "Назначение платежа")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Purpose { get; set; }

        [Display(Name = "Реквизиты")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Requisites { get; set; }

        [Display(Name = "Действие")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public int Action { get; set; }

        [Display(Name = "Акт и счет")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public bool NeedAct { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        [EmailAddress(ErrorMessage = "Введен неверный email")]
        public string Email { get; set; }

        [Display(Name = "Документооборот")]
        //[Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string DocumentManagement { get; set; }
    }
}
