using System;
using System.Web.Mvc;

namespace BusinessLight.Mvc.Extensions
{
    public static class HtmlExtensions
    {
        public static T ReturnIf<T>(this HtmlHelper htmlHelper, bool condition, T trueCondition, T falseCondition = default(T))
        {
            return condition ? trueCondition : falseCondition;
        }

        public static string ImageData(this HtmlHelper htmlHelper, byte[] imageData)
        {
            var imageBase64 = Convert.ToBase64String(imageData);
            var imageSrc = string.Format("data:image/png;base64,{0}", imageBase64);
            return imageSrc;
        }

        public static string CurrentAction(this HtmlHelper htmlHelper)
        {
            return htmlHelper.ViewContext.RouteData.GetRequiredString("action");
        }

        public static string CurrentController(this HtmlHelper htmlHelper)
        {
            return htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
        }
    }
}
