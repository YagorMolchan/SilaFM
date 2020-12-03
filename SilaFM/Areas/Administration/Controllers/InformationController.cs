using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pras.BLL.DTO;
using Pras.BLL.Services.Interfaces;
using Pras.Shared.Enums;
using Pras.Web.Areas.Administration.Models;
using Pras.Web.Areas.Administration.Models.HelperModels;

namespace Pras.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("admin/info")]
    public class InformationController : BaseController
    {
        private readonly IInformationService _informationService;

        public InformationController(IInformationService informationService)
        {
            _informationService = informationService;
        }
        
        [HttpGet]
        [Route("edit/{type}")]
        public ActionResult Edit(InformationTypes type = InformationTypes.Audio)
        {
            var model = Mapper.Map<InformationViewModel>(_informationService.Find(type));
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{type}")]
        public ActionResult Edit(InformationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var info = Mapper.Map<InformationDTO>(model);
                    info = _informationService.Save(info);
                    BuildMessage(true, model.Title, MessagesType.Save);
                    return RedirectToAction(nameof(Edit), new {type = model.Type});
                }
                BuildMessage(null, model.Title, MessagesType.Save);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                BuildMessage(false, e.Message, MessagesType.Save);
            }
            return View("Edit", model);
        }
    }
}