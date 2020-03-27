using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Pras.Web.Models.Forms
{
    public class BaseOrderForm
    {
        [JsonIgnore]
        public readonly List<string> ListPayments;

        public BaseOrderForm()
        {
            ListPayments = new List<string>
            {
                "Безналичная оплата (+6%)",
                "Карта Сбербанка",
                "Яндекс-деньги",
                "Карта Альфабанка",
                "QIWI-кошелек",
                "Visa/Mastercard (+6%)",
                "WebMoney",
                "PayPal"
            };
        }


        [Display(Name = "Комментарии")]
        public string Comments { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        [EmailAddress(ErrorMessage = "Введен неверный email")]
        public string Email { get; set; }
        [Display(Name = "Код")]
        public string Code { get; set; }
        [Display(Name = "Оплата")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        public string Payment { get; set; }
        [Display(Name = "Ваш файл")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле \"{0}\"")]
        [JsonIgnore]
        public IFormFile File { get; set; }
    }
}
