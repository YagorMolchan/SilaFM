using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Pras.BLL.DTO;
using Pras.BLL.Services.Interfaces;
using Pras.Web.Areas.Administration.Models;

namespace Pras.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("admin/settings")]
    public class SettingsController : BaseController
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Edit()
        {
            var model = Mapper.Map<SettingsViewModel>(_settingsService.Find());
            return View("Edit", model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("")]
        public JsonResult Edit([FromBody] SettingsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var info = Mapper.Map<SettingsDTO>(model);
                    info = _settingsService.Save(info);
                    return Json(Mapper.Map<SettingsViewModel>(info), new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
                }
                Logger.Error(String.Join(";\n", ModelState.Values.SelectMany(p=>p.Errors.Select(e=>e.ErrorMessage))));
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return Json(false);
            }
            return Json(null);
        }
    }
}