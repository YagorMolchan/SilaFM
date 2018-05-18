using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pras.BLL.DTO;
using Pras.BLL.Services.Interfaces;
using Pras.Web.Areas.Administration.Models;
using Pras.Web.Areas.Administration.Models.HelperModels;

namespace Pras.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("admin/audio")]
    public class AudioController : BaseController
    {
        private readonly IAudioService _audioService;

        public AudioController(IAudioService audioService)
        {
            _audioService = audioService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            var model = Mapper.Map<List<AudioViewModel>>(_audioService.Find());
            return View(model);
        }

        [HttpGet]
        [Route("edit/{id:Guid?}")]
        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
                return View("Edit",
                    new AudioViewModel
                    {
                        Created = DateTime.Now
                    });
            var model = Mapper.Map<AudioViewModel>(_audioService.Find(id.Value));
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id:Guid?}")]
        public ActionResult Edit(AudioViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var audio = Mapper.Map<AudioDTO>(model);
                    audio = _audioService.Save(audio);
                    BuildMessage(true, model.Title, MessagesType.Save);
                    return RedirectToAction(nameof(Index));
                }
                BuildMessage(null, model.Title, MessagesType.Save);
            }
            catch (Exception e)
            {
                BuildMessage(false, e.Message, MessagesType.Save);
            }
            return View("Edit", model);
        }

        [Route("delete/{id:Guid}")]
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _audioService.Delete(id);
                BuildMessage(true, null, MessagesType.Delete);
            }
            catch (Exception e)
            {
                BuildMessage(false, e.Message, MessagesType.Delete);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}