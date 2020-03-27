using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pras.BLL.Services.Interfaces;
using Pras.Shared.Enums;
using Pras.Web.Models;

namespace Pras.Web.Controllers
{
    [Route("wg")]
    public class WgController : Controller
    {
        [Route("ru")]
        public IActionResult Index([FromServices]ISpeakersService speakersService)
        {
            ViewBag.Title = "Бюджетные дикторы России";
            var model = new WGViewModel()
            {
                NewSpeakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.GetLastSpeakers(4)),
                Speakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.Find(SpeakerCountries.Russia, SpeakerTypes.Speaker))
            };
            return View("Index", model);
        }
        [Route("federal")]
        public IActionResult Federal([FromServices]ISpeakersService speakersService)
        {
            ViewBag.Title = "Федеральные дикторы России";
            var model = new WGViewModel()
            {
                NewSpeakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.GetLastSpeakers(4)),
                Speakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.Find(SpeakerCountries.Russia, SpeakerTypes.Federal))
            };
            return View("Index", model);
        }
        [Route("foreign")]
        public IActionResult Foreign([FromServices]ISpeakersService speakersService)
        {
            ViewBag.Title = "Иностанные дикторы";
            var model = new WGViewModel()
            {
                NewSpeakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.GetLastSpeakers(4)),
                Speakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.Find(SpeakerCountries.Other, SpeakerTypes.Federal, SpeakerTypes.Speaker))
            };
            return View("Index", model);
        }
        [Route("ua")]
        public IActionResult Ukraine([FromServices]ISpeakersService speakersService)
        {
            ViewBag.Title = "Дикторы Украины";
            var model = new WGViewModel()
            {
                NewSpeakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.GetLastSpeakers(4)),
                Speakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.Find(SpeakerCountries.Ukraine, SpeakerTypes.Federal, SpeakerTypes.Speaker))
            };
            return View("Index", model);
        }
        [Route("speakers/{url}")]
        public IActionResult Inner(string url, [FromServices]ISpeakersService speakersService)
        {
            var model = Mapper.Map<FullSpeakerViewModel>(speakersService.Find(url));
            if (model == null)
                return NotFound();
            return View("Detail", model);
        }
    }
}