using System;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Pras.Shared.Enums;

namespace Pras.Web.Helpers
{
    public static class CurrentMenuHelper
    {
        /// <summary>
        /// Determination of the active menu about Controller
        /// </summary>
        public static HtmlString CurrentMenu<TModel>(this IHtmlHelper<TModel> htmlHelper,
                                                        RouteData current,
                                                        string controller,
                                                        string className)
        {
            var currentController = current.Values["controller"] as string ?? "Home";
            return new HtmlString(String.CompareOrdinal(controller.ToLower(), currentController.ToLower()) == 0 ? className : string.Empty);
        }

        /// <summary>
        /// Determination of the active menu about Controller and parameters from url
        /// </summary>
        public static HtmlString CurrentMenuTreeFirst<TModel>(this IHtmlHelper<TModel> htmlHelper,
                                                        RouteData current,
                                                        HttpRequest request,
                                                        string action,
                                                        string currentUrl,
                                                        string className)
        {
            var currentAdditional = string.Empty;
            var currentAction = (current.Values["action"] as string ?? "Index").ToLower();
            currentAdditional = current.Values["url"] as string ?? string.Empty;
            return new HtmlString(String.CompareOrdinal(currentAction, action) == 0 &&
                                     String.CompareOrdinal(currentUrl.ToLower(), currentAdditional.ToLower()) == 0 ? className : string.Empty);
        }

        /// <summary>
        /// Determination of the active menu about Controller and parameters from url
        /// </summary>
        public static HtmlString CurrentMenuTreeSecond<TModel>(this IHtmlHelper<TModel> htmlHelper,
                                                        RouteData current,
                                                        HttpRequest request,
                                                        string action,
                                                        string currentUrl,
                                                        string currentFurnitureUrl,
                                                        string className)
        {
            var currentAdditional1 = string.Empty;
            var currentAdditional2 = string.Empty;
            var currentAction = (current.Values["action"] as string ?? "Index").ToLower();
            if (currentAction == "leftnavigationfurniture")
            {
                currentAdditional1 = current.Values["url"] as string ?? string.Empty;
                currentAdditional2 = current.Values["furnitureUrl"] as string ?? string.Empty;
            }
            return new HtmlString(String.CompareOrdinal(currentAction, action) == 0 &&
                                     String.CompareOrdinal(currentUrl.ToLower(), currentAdditional1.ToLower()) == 0 &&
                                     String.CompareOrdinal(currentFurnitureUrl.ToLower(), currentAdditional2.ToLower()) == 0 ? className : string.Empty);
        }

        /// <summary>
        /// Determination of the active menu about Controller and Action
        /// </summary>
        public static HtmlString CurrentMenu<TModel>(this IHtmlHelper<TModel> htmlHelper,
                                                        RouteData current,
                                                        string controller,
                                                        string action,
                                                        string className)
        {
            var currentController = current.Values["controller"] as string ?? "Home";
            var currentAction = current.Values["action"] as string ?? "Index";
            return new HtmlString(String.CompareOrdinal(controller.ToLower(), currentController.ToLower()) == 0 &&
                                     String.CompareOrdinal(action.ToLower(), currentAction.ToLower()) == 0 ? className : string.Empty);
        }


        /// <summary>
        /// Determination of the active menu about Controller, Action and parameters from url
        /// </summary>
        public static HtmlString CurrentMenu<TModel>(this IHtmlHelper<TModel> htmlHelper,
                                                        RouteData current,
                                                        string controller,
                                                        string action,
                                                        string className,
                                                        ObjectValue objectValue)
        {
            var currentController = current.Values["controller"] as string ?? "Home";
            var currentAction = current.Values["action"] as string ?? "Index";
            string currentAdditional = "";
            if (objectValue.Type == typeof(InformationTypes))
            {
                currentAdditional = current.Values["type"] as string ?? "Main";
            }
            return new HtmlString(String.CompareOrdinal(controller.ToLower(), currentController.ToLower()) == 0 &&
                                     String.CompareOrdinal(action.ToLower(), currentAction.ToLower()) == 0 &&
                                     String.CompareOrdinal(currentAdditional.ToLower(), objectValue.Value.ToString().ToLower()) == 0 ? className : string.Empty);
        }

        /// <summary>
        /// Determination of the active menu about Controller for treeView
        /// </summary>
        public static HtmlString CurrentMenu<TModel>(this IHtmlHelper<TModel> htmlHelper,
                                                        string[] liControllers,
                                                        string className)
        {
            for (int i = 0; i < liControllers.Length; i++)
            {
                liControllers[i] = liControllers[i].ToLower();
            }

            return new HtmlString(liControllers.Count(p => !string.IsNullOrEmpty(p)) != 0 ? className : string.Empty);
        }
    }

    public struct ObjectValue
    {
        public object Value { get; set; }
        public Type Type { get; set; }
    }

    public class Link
    {
        public string Text { get; set; }
        public string Href { get; set; }
    }
}
