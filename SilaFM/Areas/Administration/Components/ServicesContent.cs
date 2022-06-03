using Microsoft.AspNetCore.Mvc;
using Pras.Web.Areas.Administration.Models;
using System.Collections.Generic;

namespace Pras.Web.Areas.Administration.Components
{
    public class ServicesContent:ViewComponent
    {
        public IViewComponentResult Invoke(List<ServiceViewModel> models)
        {
            return View("_ServicesContent", models);
        }
    }
}
