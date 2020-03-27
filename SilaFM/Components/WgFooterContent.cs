using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pras.BLL.Services.Interfaces;
using Pras.Web.Models;

namespace Pras.Web.Components
{
    public class WgFooterContent : ViewComponent
    {
        ISettingsService _settingsService;
        public WgFooterContent(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public IViewComponentResult Invoke()
        {
            return View("_WgFooterContent", Mapper.Map<SettingsViewModel>(_settingsService.Find()));
        }
    }
}
