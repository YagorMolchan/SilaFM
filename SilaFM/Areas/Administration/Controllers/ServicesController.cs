using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pras.BLL.Services.Interfaces;
using Pras.Web.Areas.Administration.Models;
using System.Collections.Generic;
using AutoMapper;
using System;
using Pras.BLL.DTO;
using Microsoft.Extensions.Logging;
using NLog;

namespace Pras.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Administration")]
    [Route("admin/services")]
    public class ServicesController : Controller
    {
        private readonly IServiceService _service;

        public ServicesController(IServiceService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var model = Mapper.Map<List<ServiceViewModel>>(_service.Find());
            return View(model);
        }

        [HttpGet]
        [Route("edit/{id:Guid?}")]
        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
                return View("Edit", new ServiceViewModel());
            var model = Mapper.Map<ServiceViewModel>(_service.Find(id.Value));
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id:Guid?}")]
        public ActionResult Edit(ServiceViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var news = Mapper.Map<ServiceDTO>(model);
                    news = _service.Save(news);
                    //BuildMessage(true, model.Title, MessagesType.Save);
                    return RedirectToAction(nameof(Index));
                }
                //BuildMessage(null, model.Title, MessagesType.Save);
            }
            catch (Exception e)
            {
                //Logger.Error()
                //BuildMessage(false, e.Message, MessagesType.Save);
            }
            return View("Edit", model);
        }

        [Route("delete/{id:Guid}")]
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _service.Delete(id);
                //BuildMessage(true, null, MessagesType.Delete);
            }
            catch (Exception e)
            {
                //Logger.Error(e);
                //BuildMessage(false, e.Message, MessagesType.Delete);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
