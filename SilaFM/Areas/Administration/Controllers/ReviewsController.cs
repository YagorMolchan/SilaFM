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
    [Route("admin/reviews")]
    public class ReviewsController : BaseController
    {
        private readonly IReviewsService _reviewsService;

        public ReviewsController(IReviewsService reviewsService)
        {
            _reviewsService = reviewsService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            var model = Mapper.Map<List<ReviewViewModel>>(_reviewsService.Find());
            return View(model);
        }

        [HttpGet]
        [Route("edit/{id:Guid?}")]
        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
                return View("Edit", new ReviewViewModel());
            var model = Mapper.Map<ReviewViewModel>(_reviewsService.Find(id.Value));
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id:Guid?}")]
        public ActionResult Edit(ReviewViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var audio = Mapper.Map<ReviewDTO>(model);
                    audio = _reviewsService.Save(audio);
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
                _reviewsService.Delete(id);
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