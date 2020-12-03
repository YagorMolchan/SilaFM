using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using Pras.BLL.Services.Interfaces;
using Pras.Web.Models.Forms;

namespace Pras.Web.Controllers
{
    public class EmailingController : Controller
    {
        protected Logger Logger = LogManager.GetCurrentClassLogger();

        [HttpPost]
        [Route("order-call")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderCall([FromBody] OrderCallFormModel model, [FromServices] IEmailService emailService)
        {
            if (ModelState.IsValid)
            {
                string message = $"<p><strong>Поступила просьба перезвонить:</strong></p>" +
                                 $"<p>Имя: {model.Name}</p>" +
                                 $"<p>Телефон: {model.Phone}</p>";
                try
                {
                    await emailService.SendFeedbackEmailAsync("Перезвоните мне - обратная связь SilaFM", message);
                    return Json(true);
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    return Json(false);
                }

            }
            return Json(null);
        }

        [HttpPost]
        [Route("questionare")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Questionare([FromForm] QuestionareFormModel model, [FromServices] IEmailService emailService)
        {
            if (ModelState.IsValid)
            {
                string message = $"<p><strong>Поступила новая анкета:</strong></p>" +
                                 $"<p>Имя: {model.Name}</p>" +
                                 $"<p>Телефон: {model.Phone}</p>" +
                                 $"<p>E-mail: {model.Email}</p>" +
                                 $"<p>Возраст: {model.Age}</p>" +
                                 $"<p>Место проживания: {model.Address}</p>" +
                                 $"<p>Языки: {model.Languages}</p>" +
                                 $"<p>Место работы: {model.Company}</p>" +
                                 $"<p>Опыт работы: {model.Experience}</p>" +
                                 $"<p>График работы: {model.Shedule}</p>" +
                                 $"<p>Возможность записи начитки дома: {(model.RecordingAtHome ? "да" : "нет")}</p>" +
                                 $"<p>Возможность записи начитки на работе: {(model.RecordingAtWork ? "да" : "нет")}</p>" +
                                 $"<p>Стоимость начитки рекламного текста до 30 сек.: {model.Price30}</p>" +
                                 $"<p>Стоимость начитки 1 страницы печатного текста: {model.PricePage}</p>";
                try
                {
                    await emailService.SendFeedbackEmailAsync("Анкета - обратная связь SilaFM", message, model.Files);
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    TempData["Error"] = "Ошибка при отправке!";
                }
            }
            else
            {
                TempData["Error"] = "Неверно заполнена анкета!";
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("order-speaker")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderSpeaker([FromForm] SpeakerOrderFormModel model, [FromServices] IEmailService emailService)
        {
            if (ModelState.IsValid)
            {
                string message = $"<p><strong>Поступил новый заказ:</strong></p>" +
                                 $"<p>Имя диктора: {(model.StudioChoice ? "на усмотрение студии" : model.SpeakerName)}</p>" +
                                 $"<p>Характер: {model.Voice}</p>" +
                                 $"<p>Текст: {model.Text}</p>" +
                                 $"<p>Хронометраж: {model.Timing}</p>" +
                                 $"<p>Комментарии: {model.Comments}</p>" +
                                 $"<p>Параметры: {model.Parameters}</p>" +
                                 $"<p>Код скидки: {model.Code}</p>" +
                                 $"<p>E-mail: {model.Email}</p>" +
                                 $"<p>Оплата: {model.Payment}</p>";
                try
                {
                    await emailService.SendFeedbackEmailAsync("Новый заказ (дикторский голос) - обратная связь SilaFM",
                        message, new List<IFormFile> {model.File});
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    TempData["ErrorSpeaker"] = "Ошибка при отправке!";
                }
            }
            else
            {
                TempData["ErrorSpeaker"] = "Неверно заполнены поля!";
                TempData["OrderModel"] = JsonConvert.SerializeObject(new OrderViewModel { SpeakerFormModel = model });
            }
            TempData["Tab"] = "speakers";
            //return RedirectToAction("Order", "Home");
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [Route("order-scenario")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderScenario([FromForm] ScenarioOrderFormModel model, [FromServices] IEmailService emailService)
        {
            if (ModelState.IsValid)
            {
                string message = $"<p><strong>Поступил новый заказ:</strong></p>" +
                                 $"<p>Тип ролика: {model.Type}</p>" +
                                 $"<p>Хронометраж: {(model.IsFreeTiming ? "свободный" : model.Timing)}</p>" +
                                 $"<p>Предмет рекламы: {model.AdvertisingSubject}</p>" +
                                 $"<p>Целевая аудитория: {model.TargetAudience}</p>" +
                                 $"<p>Рекламное сообщение: {model.Message}</p>" +
                                 $"<p>Преимущества: {model.Benefits}</p>" +
                                 $"<p>Пожелания по голосам: {model.PreferencesVotes}</p>" +
                                 $"<p>Должно прозвучать: {model.MustSound}</p>" +
                                 $"<p>Корпоративные элементы: {model.CorporateElements}</p>" +
                                 $"<p>Комментарии: {model.Comments}</p>" +
                                 $"<p>Код скидки: {model.Code}</p>" +
                                 $"<p>E-mail: {model.Email}</p>" +
                                 $"<p>Оплата: {model.Payment}</p>";
                try
                {
                    await emailService.SendFeedbackEmailAsync("Новый заказ (сценарий) - обратная связь SilaFM",
                        message, new List<IFormFile> { model.File });
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    TempData["ErrorScenario"] = "Ошибка при отправке!";
                }
            }
            else
            {
                TempData["ErrorScenario"] = "Неверно заполнены поля!";
                TempData["OrderModel"] = JsonConvert.SerializeObject(new OrderViewModel { ScenarioFormModel = model });
            }
            TempData["Tab"] = "scenario";
            return RedirectToAction("Order", "Home");
        }

        [HttpPost]
        [Route("order-audio")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderAudio([FromForm] AudioOrderFormModel model, [FromServices] IEmailService emailService)
        {
            if (ModelState.IsValid)
            {
                string message = $"<p><strong>Поступил новый заказ:</strong></p>" +
                                 $"<p>Тип ролика: {model.Type}</p>" +
                                 $"<p>Характер: {model.Voice}</p>" +
                                 $"<p>Стиль: {model.Style}</p>" +
                                 $"<p>Хронометраж: {(model.IsFreeTiming ? "свободный" : model.Timing)}</p>" +
                                 $"<p>Количество голосов: {model.Count}</p>" +
                                 $"<p>Дикторы: {(model.StudioChoice ? "на усмотрение студии" : model.SpeakerName)}</p>" +
                                 $"<p>Комментарии: {model.Comments}</p>" +
                                 $"<p>Текст: {model.Text}</p>" +
                                 $"<p>Хронометраж: {model.Timing}</p>" +
                                 $"<p>Параметры: {model.Parameters}</p>" +
                                 $"<p>Код скидки: {model.Code}</p>" +
                                 $"<p>E-mail: {model.Email}</p>" +
                                 $"<p>Оплата: {model.Payment}</p>";
                try
                {
                    await emailService.SendFeedbackEmailAsync("Новый заказ (аудиоролик) - обратная связь SilaFM",
                        message, new List<IFormFile> { model.File });
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    TempData["ErrorAudio"] = "Ошибка при отправке!";
                }
            }
            else
            {
                TempData["ErrorAudio"] = "Неверно заполнены поля!";
                TempData["OrderModel"] = JsonConvert.SerializeObject(new OrderViewModel { AudioFormModel = model });
            }
            TempData["Tab"] = "audio";
            return RedirectToAction("Order", "Home");
        }

        [HttpPost]
        [Route("order-video")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderVideo([FromForm] VideoOrderFormModel model, [FromServices] IEmailService emailService)
        {
            if (ModelState.IsValid)
            {
                string message = $"<p><strong>Поступил новый заказ:</strong></p>" +
                                 $"<p>Вид озвучки: {model.Type}</p>" +
                                 $"<p>Объём заказа ({model.Points}): {model.Count}</p>" +
                                 $"<p>Фронт работ: {model.Works}</p>" +
                                 $"<p>Дикторы: {(model.StudioChoice ? "на усмотрение студии" : model.SpeakerName)}</p>" +
                                 $"<p>Текст: {model.Text}</p>" +
                                 $"<p>Комментарии: {model.Comments}</p>" +
                                 $"<p>Параметры: {model.Parameters}</p>" +
                                 $"<p>Ссылки на видео: {(model.VideoLink1 != null ? $", <a href=\"{model.VideoLink1}\">{model.VideoLink1}</a>" : "")}" +
                                 $"{(model.VideoLink2!=null? $", <a href=\"{model.VideoLink2}\">{model.VideoLink2}</a>":"")}</p>" +
                                 $"<p>Код скидки: {model.Code}</p>" +
                                 $"<p>E-mail: {model.Email}</p>" +
                                 $"<p>Оплата: {model.Payment}</p>";
                try
                {
                    await emailService.SendFeedbackEmailAsync("Новый заказ (озвучка видео) - обратная связь SilaFM",
                        message, new List<IFormFile> { model.File });
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    TempData["ErrorVideo"] = "Ошибка при отправке!";
                }
            }
            else
            {
                TempData["ErrorVideo"] = "Неверно заполнены поля!";
                TempData["OrderModel"] = JsonConvert.SerializeObject(new OrderViewModel { VideoFormModel = model });
            }
            TempData["Tab"] = "video";
            return RedirectToAction("Order", "Home");
        }

        [HttpPost]
        [Route("order-music")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderMusic([FromForm] MusicOrderFormModel model, [FromServices] IEmailService emailService)
        {
            if (ModelState.IsValid)
            {
                string message = $"<p><strong>Поступил новый заказ:</strong></p>" +
                                 $"<p>Назначение: {model.Purpose}</p>" +
                                 $"<p>Стиль оформления: {model.Style}</p>" +
                                 $"<p>Хронометраж: {(model.IsFreeTiming ? "свободный" : model.Timing)}</p>" +
                                 $"<p>Похожие песни: {model.SimilarSongs}</p>" +
                                 $"<p>Характер: {model.Voice}</p>" +
                                 $"<p>Темп: {model.Tempo}</p>" +
                                 $"<p>Инструменты: {model.Instruments}</p>" +
                                 $"<p>Вокальное оформление: {model.Vocal}</p>" +
                                 $"<p>Дополнительная информация: {model.Info}</p>" +
                                 $"<p>Комментарии: {model.Comments}</p>" +
                                 $"<p>Код скидки: {model.Code}</p>" +
                                 $"<p>E-mail: {model.Email}</p>" +
                                 $"<p>Оплата: {model.Payment}</p>";
                try
                {
                    await emailService.SendFeedbackEmailAsync("Новый заказ (музыка в рекламе) - обратная связь SilaFM",
                        message, new List<IFormFile> { model.File });
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    TempData["ErrorMusic"] = "Ошибка при отправке!";
                }
            }
            else
            {
                TempData["ErrorMusic"] = "Неверно заполнены поля!";
                TempData["OrderModel"] = JsonConvert.SerializeObject(new OrderViewModel { MusicFormModel = model });
            }
            TempData["Tab"] = "music";
            return RedirectToAction("Order", "Home");
        }

        [HttpPost]
        [Route("interview")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Interview([FromForm] string source, [FromServices] IEmailService emailService)
        {
            if (ModelState.IsValid)
            {
                string message = $"<p><strong>Вопрос: \"Как вы нас нашли?\"</p></strong>" +
                                 $"<p>Ответ: {source}</p>";
                try
                {
                    await emailService.SendFeedbackEmailAsync("Ответ на опрос - обратная связь SilaFM", message);
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    TempData["Error"] = "Ошибка при отправке!";
                }
            }
            else
            {
                TempData["Error"] = "Неверно заполнены поля!";
            }
            return RedirectToAction("Payment", "Home");
        }

        [HttpPost]
        [Route("order-docs")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderDocs([FromForm] string name, [FromForm] string email, [FromServices] IEmailService emailService)
        {
            if (ModelState.IsValid)
            {
                string message = $"<p><strong>Просьба отправить документы по электронной почте</strong></p>" +
                                 $"<p>Компания: {name}</p>" +
                                 $"<p>Email: {email}</p>";
                try
                {
                    await emailService.SendFeedbackEmailAsync("Заказ документов - обратная связь SilaFM", message);
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    TempData["ErrorDocs"] = "Ошибка при отправке!";
                }
            }
            else
            {
                TempData["ErrorDocs"] = "Неверно заполнены поля!";
            }
            return RedirectToAction("Payment", "Home");
        }

        [HttpPost]
        [Route("order-payment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderPayment([FromForm] PopupPaymentFormModel model, [FromServices] IEmailService emailService)
        {
            if (ModelState.IsValid)
            {
                string message = $"<p><strong>Оплата по безналичному расчету</strong>:</p>" +
                                 $"<p>Дата: {model.Date}</p>" +
                                 $"<p>Номер счета: {model.Account}</p>" +
                                 $"<p>Сумма в рублях: {model.Amount}</p>" +
                                 $"<p>Способ оплаты: {model.PaymentMethod}</p>" +
                                 $"<p>Плательщик: {model.Payer}</p>" +
                                 $"<p>Назначение: {model.Purpose}</p>" +
                                 $"<p>Реквизиты: {model.Requisites}</p>" +
                                 $"<p>E-mail: {model.Email}</p>" +
                                 $"<p>Акт и счет: {(model.NeedAct ? "да" : "нет")}</p>" +
                                 $"<p>Документооборот: {model.DocumentManagement}</p>";
                try
                {
                    await emailService.SendFeedbackEmailAsync("Оплата по безналичному расчету - обратная связь SilaFM", message);
                    if (model.Action==0)
                    {
                        await emailService.SendEmailAsync("Оплата по безналичному расчету - SilaFM", model.Email, message);
                    }
                    if (model.Action == 1)
                    {
                        TempData["Print"] = message;
                    }
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    TempData["Error"+model.Type] = "Ошибка при отправке!";
                }
            }
            else
            {
                TempData["Error" + model.Type] = "Неверно заполнены поля!";
            }
            return RedirectToAction("Payment", "Home");
        }

        [HttpPost]
        [Route("choice-speaker")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChoiceSpeaker([FromForm] ChoiceSpeakerViewModel model, [FromServices] IEmailService emailService)
        {
            if (ModelState.IsValid)
            {
                string message = $"<p><strong>Заказ на подбор диктора:</strong></p>" +
                                 $"<p>Бюджет: {model.Budget}</p>" +
                                 $"<p>Голос: {model.Voice}</p>" +
                                 $"<p>Место размещения: {model.Placement}</p>" +
                                 $"<p>Задание: {model.Task}</p>" +
                                 $"<p>Пожелания по диктору: {model.Comment}</p>" +
                                 $"<p>E-mail: {model.Email}</p>";
                try
                {
                    await emailService.SendFeedbackEmailAsync("Новый заказ (подбор диктора) - обратная связь SilaFM",
                        message, model.File != null ? new List<IFormFile> {model.File} : null);
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    TempData["ErrorChoice"] = "Ошибка при отправке!";
                    TempData["OrderModel"] = JsonConvert.SerializeObject(model);
                }
            }
            else
            {
                TempData["ErrorChoice"] = "Неверно заполнены поля!";
                TempData["OrderModel"] = JsonConvert.SerializeObject(model);
            }
            return RedirectToAction("ChoiceSpeaker", "Home");
        }

        [HttpPost]
        [Route("identify-voice")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IdentifyVoice([FromForm] IdentifyVoiceViewModel model, [FromServices] IEmailService emailService)
        {
            if (ModelState.IsValid)
            {
                string message = $"<p><strong>Заказ на опознание диктора:</strong></p>" +
                                 $"<p>Ссылки на ролик: {model.Link}</p>" +
                                 $"<p>Комментарии: {model.Comment}</p>" +
                                 $"<p>E-mail: {model.Email}</p>";
                try
                {
                    await emailService.SendFeedbackEmailAsync("Новый заказ (опознание диктора) - обратная связь SilaFM",
                        message, model.File != null ? new List<IFormFile> { model.File } : null);
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    TempData["ErrorChoice"] = "Ошибка при отправке!";
                    TempData["OrderModel"] = JsonConvert.SerializeObject(model);
                }
            }
            else
            {
                TempData["ErrorChoice"] = "Неверно заполнены поля!";
                TempData["OrderModel"] = JsonConvert.SerializeObject(model);
            }
            return RedirectToAction("IdentifyVoice", "Home");
        }
    }
}