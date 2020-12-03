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
    [Route("admin/team")]
    public class TeamController : BaseController
    {
        private readonly IPeopleService _peopleService;

        public TeamController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            var model = Mapper.Map<List<PersonViewModel>>(_peopleService.Find());
            return View(model);
        }

        [HttpGet]
        [Route("edit/{id:Guid?}")]
        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
                return View("Edit", new PersonViewModel());
            var model = Mapper.Map<PersonViewModel>(_peopleService.Find(id.Value));
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id:Guid?}")]
        public ActionResult Edit(PersonViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var person = Mapper.Map<PersonDTO>(model);
                    person = _peopleService.Save(person);
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
                _peopleService.Delete(id);
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