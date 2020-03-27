using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pras.BLL.Services.Interfaces;
using Pras.Shared.Helpers;
using Pras.Web.Models;

namespace Pras.Web.Components
{
    public class FooterContent : ViewComponent
    {
        ISettingsService _settingsService;
        public FooterContent(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public IViewComponentResult Invoke()
        {
            var model = Mapper.Map<SettingsViewModel>(_settingsService.Find());
            ViewBag.CountryCode = HttpContext.Session.GetString("CountryCode");

            return View("_FooterContent", model);
        }
    }
}
