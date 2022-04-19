using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pras.BLL.Services.Interfaces;
using Pras.Shared.Enums;
using Pras.Shared.Helpers;
using Pras.Web.Models;
using Pras.Web.Models.HelperModels;

namespace Pras.Web.Components
{
    public class BurgerPhones : ViewComponent
    {
        readonly IInformationService _informationService;
        public BurgerPhones(IInformationService informationService)
        {
            _informationService = informationService;
        }
        public IViewComponentResult Invoke()
        {
            //var model = Mapper.Map<SettingsViewModel>(_settingsService.Find());
            var model = Mapper.Map<ContactsViewModel>(_informationService.Find(InformationTypes.Contacts))?.Contacts?.PhonesList;

            return View("_BurgerPhones", model);
        }
    }
}
