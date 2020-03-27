using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using elFinder.NetCore;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pras.Shared.Config;

namespace Pras.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("file")]
    public partial class FileController : Controller
    {
        private readonly AppSettings _appSettings;

        public FileController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [Route("connector")]
        public virtual async Task<IActionResult> Index()
        {
            var connector = GetConnector();
            return await connector.Process(HttpContext.Request);
        }

        [Route("thumb/{hash}")]
        public IActionResult Thumbs(string hash)
        {
            var connector = GetConnector();
            return connector.GetThumbnail(HttpContext.Request, HttpContext.Response, hash);
        }

        private Connector GetConnector()
        {
            var driver = new FileSystemDriver();

            string absoluteUrl = UriHelper.BuildAbsolute(Request.Scheme, Request.Host);
            var uri = new Uri(absoluteUrl);

            var root = new Root(
                new DirectoryInfo(Startup.MapPath("~/Files")),
                string.Format("{0}Files/", _appSettings.CDN),
                string.Format("{0}file/thumb/", _appSettings.CDN))
            {
                // Sample using ASP.NET built in Membership functionality...
                // Only the super user can READ (download files) & WRITE (create folders/files/upload files).
                // Other users can only READ (download files)
                // IsReadOnly = !User.IsInRole(AccountController.SuperUser)

                IsReadOnly = false, // Can be readonly according to user's membership permission
                Alias = "Главная", // Beautiful name given to the root/home folder
                MaxUploadSizeInKb = 50000, // Limit imposed to user uploaded file <= 500 KB
                //LockedFolders = new List<string>(new string[] { "Folder1" })
            };

            //// Was a subfolder selected in Home Index page?
            //if (!string.IsNullOrEmpty(subFolder))
            //{
            //    root.StartPath = new DirectoryInfo(Startup.MapPath("~/Files/" + folder + "/" + subFolder));
            //}

            driver.AddRoot(root);

            return new Connector(driver);
        }

        [Route("select-file")]
        public virtual IActionResult SelectFile(string target)
        {
            var driver = new FileSystemDriver();

            string absoluteUrl = UriHelper.BuildAbsolute(Request.Scheme, Request.Host);
            var uri = new Uri(absoluteUrl);

            driver.AddRoot(
                new Root(
                    new DirectoryInfo(Startup.MapPath("~/Files")),
                    "http://" + uri.Authority + "/Files")
                { IsReadOnly = false });

            var connector = new Connector(driver);

            return Json(connector.GetFileByHash(target).FullName);
        }
    }
}