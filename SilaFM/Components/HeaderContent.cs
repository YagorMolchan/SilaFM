using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pras.BLL.Services.Interfaces;
using Pras.Web.Models;

namespace Pras.Web.Components
{
    public class HeaderContent : ViewComponent
    {
        ISettingsService _settingsService;
        public HeaderContent(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public IViewComponentResult Invoke()
        {
            return View("_HeaderContent", Mapper.Map<SettingsViewModel>(_settingsService.Find()));
        }
    }
}
