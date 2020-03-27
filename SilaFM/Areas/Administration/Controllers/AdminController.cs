using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Pras.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        [Route("")]
        [Route("filemanager")]
        public IActionResult Index()
        {
            return View();
        }
        
        [Route("elfinder")]
        public IActionResult ElFinder()
        {
            return View();
        }
    }
}