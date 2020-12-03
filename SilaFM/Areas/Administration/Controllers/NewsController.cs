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
    [Route("admin/news")]
    public class NewsController : BaseController
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            var model = Mapper.Map<List<NewsViewModel>>(_newsService.Find());
            return View(model);
        }

        [HttpGet]
        [Route("edit/{id:Guid?}")]
        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
                return View("Edit", new NewsViewModel {Created = DateTime.Now});
            var model = Mapper.Map<NewsViewModel>(_newsService.Find(id.Value));
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id:Guid?}")]
        public ActionResult Edit(NewsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var news = Mapper.Map<NewsDTO>(model);
                    news = _newsService.Save(news);
                    BuildMessage(true, model.Title, MessagesType.Save);
                    return RedirectToAction(nameof(Index));
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

        [Route("delete/{id:Guid}")]
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _newsService.Delete(id);
                BuildMessage(true, null, MessagesType.Delete);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                BuildMessage(false, e.Message, MessagesType.Delete);
            }

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Action for check is url of added news unique
        /// </summary>
        /// <param name="url">news url</param>
        /// <param name="id">news id</param>
        /// <returns>json true or false</returns>
        [Route("checkurl")]
        public JsonResult CheckUrl(string url, Guid id)
        {
            var result = _newsService.Find().Count(p => p.Url == url && p.Id != id) == 0;
            return Json(result);
        }
    }
}