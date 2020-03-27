using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using Pras.Web.Areas.Administration.Models.HelperModels;

namespace Pras.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("admin")]
    public class BaseController : Controller
    {
        protected Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Insert class ResultMessages for the TempData["Result"] and view message for the client.
        /// </summary>
        /// <param name="resultAction">Is successfully saved? (null - for the warning)</param>
        /// <param name="value">Title</param>
        /// <param name="messagesType">What action was performed.</param>
        [NonAction]
        protected void BuildMessage(bool? resultAction, string value, MessagesType messagesType)
        {
            TempData["Result"] = JsonConvert.SerializeObject(new ResultMessages
            {
                Value = value,
                MessageType = messagesType,
                ResultType = resultAction == null ?
                    ResultsType.Warning :
                    (bool)resultAction ? ResultsType.Success : ResultsType.Error
            });
        }
    }
}