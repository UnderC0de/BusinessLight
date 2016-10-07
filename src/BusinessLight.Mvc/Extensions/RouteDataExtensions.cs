namespace BusinessLight.Mvc.Extensions
{
    using System.Web.Routing;

    public static class RouteDataExtensions
    {
        public static string GetControllerName(this RouteData routeData)
        {
            return routeData.GetSafeRequiredString("controller");
        }

        public static string GetActionName(this RouteData routeData)
        {
            return routeData.GetSafeRequiredString("action");
        }

        public static string GetSafeRequiredString(this RouteData routeData, string key)
        {
            return routeData.Values.ContainsKey(key) ? routeData.Values[key].ToString() : string.Empty;
        }
    }
}