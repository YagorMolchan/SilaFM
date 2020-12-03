using System;
using System.Collections.Generic;
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
    [Route("admin/speakers")]
    public class SpeakersController : BaseController
    {
        private readonly ISpeakersService _speakersService;

        public SpeakersController(ISpeakersService speakersService)
        {
            _speakersService = speakersService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            var model = Mapper.Map<List<SpeakerViewModel>>(_speakersService.Find());
            return View(model);
        }

        [HttpGet]
        [Route("edit/{id:Guid?}")]
        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
                return View("Edit",
                    new SpeakerViewModel
                    {
                        Created = DateTime.Now
                    });
            var model = Mapper.Map<SpeakerViewModel>(_speakersService.Find(id.Value));
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id:Guid?}")]
        public ActionResult Edit(SpeakerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var audio = Mapper.Map<SpeakerDTO>(model);
                    audio = _speakersService.Save(audio);
                    BuildMessage(true, model.Name, MessagesType.Save);
                    return RedirectToAction(nameof(Index));
                }
                BuildMessage(null, model.Name, MessagesType.Save);
            }
            catch (Exception e)
            {
                Logger.Error(e);
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
                _speakersService.Delete(id);
                BuildMessage(true, null, MessagesType.Delete);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                BuildMessage(false, e.Message, MessagesType.Delete);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}