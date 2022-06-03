using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Pras.BLL.Services.Interfaces;
using Pras.DAL.Entities;
using Pras.DAL.Interfaces;
using System;
using AutoMapper;
using System.Collections.Generic;
using Pras.Web.Areas.Administration.Models.CharacterViewModels;
using System.IO;
using Pras.BLL.DTO;
using NLog;

namespace Pras.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Administration")]
    [Route("admin/characters")]
    public class CharactersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _env;

        public CharactersController(IUnitOfWork unitOfWork, IHostingEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var model = Mapper.Map<List<CharacterViewModel>>(_unitOfWork.CharactersRepository.Find());
            return View(model);
        }

        [HttpGet]
        [Route("edit/{id:Guid?}")]
        public ActionResult Edit(Guid? id)
        {
            CharacterEditViewModel model = new CharacterEditViewModel
            {
                Speakers = new SelectList(_unitOfWork.SpeakersRepository.Find(), "Id", "Name")
            };

            if (!id.HasValue)
            {
                return View("Edit", model);
            }
            model = Mapper.Map<CharacterEditViewModel>(_unitOfWork.CharactersRepository.FindById(id.Value));
            return View("Edit", model);
        }

        [HttpPost]
        [Route("edit/{id:Guid?}")]
        public ActionResult Edit(CharacterEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ImagePath = UploadImageFile(model);
                    var characterDTO = Mapper.Map<CharacterDTO>(model);
                    characterDTO.Speaker = Mapper.Map<SpeakerDTO>(_unitOfWork.SpeakersRepository.FindById(model.SpeakerId.Value));
                    var character = Mapper.Map<Character>(characterDTO);
                    _unitOfWork.CharactersRepository.InsertOrUpdate(character);
                    //BuildMessage(true, model.Title, MessagesType.Save);
                    return RedirectToAction(nameof(Index));
                }
                //BuildMessage(null, model.Title, MessagesType.Save);
            }
            catch (Exception e)
            {
                //Logger.Error(e);
                //BuildMessage(false, e.Message, MessagesType.Save);
            }
            return View("Edit", model);
        }

        private string UploadImageFile(CharacterEditViewModel model)
        {
            string uniqueFileName = null;

            if (model.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "admin/images/characters");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }



    }
}
