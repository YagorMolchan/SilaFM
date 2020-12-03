using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pras.BLL.Services.Interfaces;
using Pras.Shared.Enums;
using Pras.Web.Models;

namespace Pras.Web.Components
{
    public class SidebarContent : ViewComponent
    {
        readonly IInformationService _infoService;
        public SidebarContent(IInformationService infoService)
        {
            _infoService = infoService;
        }
        public IViewComponentResult Invoke()
        {
            return View("_SidebarContent", Mapper.Map<ContactsViewModel>(_infoService.Find(InformationTypes.Contacts)));
        }
    }
}
