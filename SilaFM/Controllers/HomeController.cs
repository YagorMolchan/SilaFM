using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pras.BLL.Services.Interfaces;
using Pras.Shared.Enums;
using Pras.Web.Models;
using Pras.Web.Models.Forms;

namespace Pras.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices] ISettingsService settingsService, [FromServices] ISpeakersService speakersService, [FromServices] IAudioService audioService, [FromServices] IReviewsService reviewsService)
        {
            var model = new HomeViewModel
            {
                Settings = Mapper.Map<SettingsViewModel>(settingsService.Find()),
                LastSpeakers = speakersService.GetLastSpeakersNames(8),
                LastProjects = audioService.GetLastAudio(8),
                LastReviews = Mapper.Map<List<ReviewViewModel>>(reviewsService.GetLastReviews(4))
            };
            return View(model);
        }

        [Route("speakers")]
        public IActionResult Speakers([FromServices] IInformationService informationService, [FromServices] ISpeakersService speakersService)
        {
            var model = new SpeakersPageViewModel
            {
                Information = Mapper.Map<InformationViewModel>(informationService.Find(InformationTypes.Speakers)),
                Speakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.Find())
            };

            if (Request.Query.ContainsKey("man"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Male).ToList();
            else if (Request.Query.ContainsKey("woman"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Female).ToList();

            return View("Speakers", model);
        }

        [Route("speakers/kids")]
        public IActionResult SpeakersChild([FromServices] IInformationService informationService, [FromServices] ISpeakersService speakersService)
        {
            var model = new SpeakersPageViewModel
            {
                Information = Mapper.Map<InformationViewModel>(informationService.Find(InformationTypes.SpeakersChild)),
                Speakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.Find(SpeakerTypes.Child))
            };
            if (Request.Query.ContainsKey("man"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Male).ToList();
            else if (Request.Query.ContainsKey("woman"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Female).ToList();

            return View("Speakers", model);
        }

        [Route("speakers/russia")]
        public IActionResult SpeakersRu([FromServices] IInformationService informationService, [FromServices] ISpeakersService speakersService)
        {
            var model = new SpeakersPageViewModel
            {
                Information = Mapper.Map<InformationViewModel>(informationService.Find(InformationTypes.SpeakersRu)),
                Speakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.Find(SpeakerCountries.Russia, SpeakerTypes.Speaker))
            };
            if (Request.Query.ContainsKey("man"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Male).ToList();
            else if (Request.Query.ContainsKey("woman"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Female).ToList();

            return View("Speakers", model);
        }

        [Route("speakers/federal")]
        public IActionResult SpeakersFederal([FromServices] IInformationService informationService, [FromServices] ISpeakersService speakersService)
        {
            var model = new SpeakersPageViewModel
            {
                Information = Mapper.Map<InformationViewModel>(informationService.Find(InformationTypes.SpeakersFederal)),
                Speakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.Find(SpeakerCountries.Russia, SpeakerTypes.Federal))
            };
            if (Request.Query.ContainsKey("man"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Male).ToList();
            else if (Request.Query.ContainsKey("woman"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Female).ToList();

            return View("Speakers", model);
        }

        [Route("speakers/ukraine")]
        public IActionResult SpeakersUk([FromServices] IInformationService informationService, [FromServices] ISpeakersService speakersService)
        {
            var model = new SpeakersPageViewModel
            {
                Information = Mapper.Map<InformationViewModel>(informationService.Find(InformationTypes.SpeakersUk)),
                Speakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.Find(SpeakerCountries.Ukraine, SpeakerTypes.Speaker))
            };
            if (Request.Query.ContainsKey("man"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Male).ToList();
            else if (Request.Query.ContainsKey("woman"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Female).ToList();

            return View("Speakers", model);
        }

        [Route("speakers/foreign")]
        public IActionResult SpeakersFor([FromServices] IInformationService informationService, [FromServices] ISpeakersService speakersService)
        {
            var model = new SpeakersPageViewModel
            {
                Information = Mapper.Map<InformationViewModel>(informationService.Find(InformationTypes.SpeakersFor)),
                Speakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.Find(SpeakerCountries.Other))
            };
            if (Request.Query.ContainsKey("man"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Male).ToList();
            else if (Request.Query.ContainsKey("woman"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Female).ToList();

            return View("Speakers", model);
        }

        [Route("speakers/parodists")]
        public IActionResult SpeakersParodists([FromServices] IInformationService informationService, [FromServices] ISpeakersService speakersService)
        {
            var model = new SpeakersPageViewModel
            {
                Information = Mapper.Map<InformationViewModel>(informationService.Find(InformationTypes.SpeakersParodist)),
                Speakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.Find(SpeakerTypes.Parodist))
            };
            if (Request.Query.ContainsKey("man"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Male).ToList();
            else if (Request.Query.ContainsKey("woman"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Female).ToList();

            return View("Speakers", model);
        }

        [Route("speakers/vocalists")]
        public IActionResult SpeakersVocalists([FromServices] IInformationService informationService, [FromServices] ISpeakersService speakersService)
        {
            var model = new SpeakersPageViewModel
            {
                Information = Mapper.Map<InformationViewModel>(informationService.Find(InformationTypes.SpeakersVocalist)),
                Speakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.Find(SpeakerTypes.Vocalist))
            };
            if (Request.Query.ContainsKey("man"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Male).ToList();
            else if (Request.Query.ContainsKey("woman"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Female).ToList();

            return View("Speakers", model);
        }

        [Route("speakers/vip")]
        public IActionResult SpeakersVip([FromServices] IInformationService informationService, [FromServices] ISpeakersService speakersService)
        {
            var model = new SpeakersPageViewModel
            {
                Information = Mapper.Map<InformationViewModel>(informationService.Find(InformationTypes.SpeakersVip)),
                Speakers = Mapper.Map<List<SpeakerViewModel>>(speakersService.FindVip())
            };
            if (Request.Query.ContainsKey("man"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Male).ToList();
            else if (Request.Query.ContainsKey("woman"))
                model.Speakers = model.Speakers.Where(p => p.Gender == Gender.Female).ToList();

            return View("Speakers", model);
        }

        [Route("speakers/{url}")]
        public IActionResult Inner(string url, [FromServices]ISpeakersService speakersService)
        {
            var model = Mapper.Map<FullSpeakerViewModel>(speakersService.Find(url));
            if (model == null)
                return NotFound();
            return View("Inner", model);
        }

        [Route("/news/{url}")]
        public IActionResult NewsInner([FromServices] INewsService newsService, string url)
        {
            var model = Mapper.Map<NewsViewModel>(newsService.Find(url));
            if (model == null)
                return NotFound();
            return View(model);
        }

        [Route("scenario")]
        public IActionResult Scenario([FromServices] IInformationService informationService)
        {
            var model = Mapper.Map<InformationViewModel>(informationService.Find(InformationTypes.Scenario));

            return View(model);
        }

        [Route("audio")]
        public IActionResult Audio([FromServices] IInformationService informationService, [FromServices] IAudioService audioService)
        {
            var model = new AudioPageViewModel
            {
                Information = Mapper.Map<InformationViewModel>(informationService.Find(InformationTypes.Audio)),
                Audio = Mapper.Map<List<AudioViewModel>>(audioService.Find().OrderByDescending(p => p.Created))
            };

            return View(model);
        }

        [Route("games")]
        public IActionResult Games([FromServices] IInformationService informationService)
        {
            var model = Mapper.Map<InformationViewModel>(informationService.Find(InformationTypes.Games));

            return View(model);
        }

        [Route("video")]
        public IActionResult Video([FromServices] IVideoService videoService)
        {
            var model = Mapper.Map<List<VideoViewModel>>(videoService.Find().OrderByDescending(p => p.Created));

            return View(model);
        }

        [Route("video-creating")]
        public IActionResult VideoCreating([FromServices] IInformationService informationService)
        {
            var model = Mapper.Map<InformationViewModel>(informationService.Find(InformationTypes.Video));

            return View(model);
        }

        [Route("music")]
        public IActionResult Music([FromServices] IInformationService informationService)
        {
            var model = Mapper.Map<InformationViewModel>(informationService.Find(InformationTypes.Music));

            return View(model);
        }

        [Route("contacts")]
        public IActionResult Contact([FromServices] IPeopleService peopleService)
        {
            var model = Mapper.Map<List<PersonViewModel>>(peopleService.Find().OrderBy(p => p.Order));

            return View(model);
        }

        [Route("payment")]
        public IActionResult Payment([FromServices] IInformationService informationService)
        {
            var model = Mapper.Map<InformationViewModel>(informationService.Find(InformationTypes.Payment));

            return View(model);
        }

        [Route("order")]
        public IActionResult Order(string speaker=null)
        {
            var model = TempData["OrderModel"] != null
                ? JsonConvert.DeserializeObject<OrderViewModel>(TempData["OrderModel"] as string)
                : new OrderViewModel {SpeakerFormModel = new SpeakerOrderFormModel {SpeakerName = speaker}};
            return View(model);
        }

        [Route("choice-speaker")]
        public IActionResult ChoiceSpeaker()
        {
            var model = TempData["OrderModel"] != null ? JsonConvert.DeserializeObject<ChoiceSpeakerViewModel>(TempData["OrderModel"] as string) :
                new ChoiceSpeakerViewModel();
            return View(model);
        }

        [Route("identify-voice")]
        public IActionResult IdentifyVoice()
        {
            var model = TempData["OrderModel"] != null ? JsonConvert.DeserializeObject<IdentifyVoiceViewModel>(TempData["OrderModel"] as string) :
                new IdentifyVoiceViewModel();
            return View(model);
        }

        [Route("error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("chronomer")]
        public IActionResult Chronomer()
        {
            return View();
        }

        [Route("pages")]
        public IActionResult Pages()
        {
            return View();
        }

        [Route("cabinet")]
        public IActionResult Cabinet()
        {
            return View();
        }
    }
}
