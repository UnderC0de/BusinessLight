namespace BusinessLight.Mvc.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Web.Mvc;

    /// <summary>
    /// Set the thread culture based on route parameter
    /// </summary>
    /// <seealso cref="System.Web.Mvc.ActionFilterAttribute" />
    public class RouteLanguageAttribute : ActionFilterAttribute
    {
        public RouteLanguageAttribute()
        {
            RouteDataParameterName = "language";
            SupportedCultures = new List<CultureInfo>();
        }

        public string RouteDataParameterName
        {
            get;
            set;
        }

        public List<CultureInfo> SupportedCultures
        {
            get;
            set;
        }

        /// <summary>
        /// The on action executing.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var routeLanguage = (string)filterContext.RouteData.Values[RouteDataParameterName];

                if (string.IsNullOrWhiteSpace(routeLanguage))
                {
                    return;
                }

                var routeCulture = CultureInfo.CreateSpecificCulture(routeLanguage);

                if (SupportedCultures.Any() && !SupportedCultures.Contains(routeCulture))
                {
                    return;
                }

                Thread.CurrentThread.CurrentCulture = routeCulture;
                Thread.CurrentThread.CurrentUICulture = routeCulture;
            }
            catch (Exception)
            {
            }
            ////return;
            ////// Not a valid route culture..try from request..

            ////var userLanguages = filterContext.RequestContext.HttpContext.Request.UserLanguages;
            ////if (userLanguages == null || !userLanguages.Any())
            ////{
            ////    return;
            ////}

            ////var firstRequestLanguage = userLanguages.First();
            ////var requestCulture = CultureInfo.CreateSpecificCulture(firstRequestLanguage);

            ////if (!SupportedCultures.Contains(requestCulture))
            ////{
            ////    return;
            ////}

            ////Thread.CurrentThread.CurrentCulture = requestCulture;
            ////Thread.CurrentThread.CurrentUICulture = requestCulture;
        }

        
    }
}
