using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pras.BLL.DTO;
using Pras.BLL.Services.Interfaces;
using Pras.Shared.Enums;
using Pras.Web.Areas.Administration.Models;
using Pras.Web.Areas.Administration.Models.HelperModels;

namespace Pras.Web.Areas.Administration.Controllers
{
    public class ContactsController : BaseController
    {
        private readonly IInformationService _informationService;

        public ContactsController(IInformationService informationService)
        {
            _informationService = informationService;
        }

        [HttpGet]
        [Route("contacts")]
        public ActionResult Edit()
        {
            var model = Mapper.Map<ContactsViewModel>(_informationService.Find(InformationTypes.Contacts));
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("contacts")]
        public ActionResult Edit(ContactsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var info = Mapper.Map<InformationDTO>(model);
                    info = _informationService.Save(info);
                    BuildMessage(true, model.Title, MessagesType.Save);
                    return RedirectToAction("Edit", new { type = model.Type });
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