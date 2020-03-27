using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pras.BLL.Services.Interfaces;
using Pras.Web.Models;

namespace Pras.Web.Components
{
    public class SidebarContent : ViewComponent
    {
        ISettingsService _settingsService;
        public SidebarContent(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public IViewComponentResult Invoke()
        {
            return View("_SidebarContent", Mapper.Map<SettingsViewModel>(_settingsService.Find()));
        }
    }
}
