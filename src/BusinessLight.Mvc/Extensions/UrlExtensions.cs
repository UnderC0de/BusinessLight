using System;

namespace BusinessLight.Mvc.Extensions
{
    using System.Web.Mvc;

    public static class UrlExtensions
    {
        public static string Abs(this UrlHelper urlHelper, string relativeOrAbsoluteUrl)
        {
            var uri = new Uri(relativeOrAbsoluteUrl, UriKind.RelativeOrAbsolute);
            if (uri.IsAbsoluteUri)
            {
                return relativeOrAbsoluteUrl;
            }

            Uri combinedUri;
            if (Uri.TryCreate(BaseUrl(urlHelper), relativeOrAbsoluteUrl, out combinedUri))
            {
                return combinedUri.AbsoluteUri;
            }

            throw new Exception($"Could not create absolute url for {relativeOrAbsoluteUrl} using baseUri {BaseUrl(urlHelper)}");
        }

        private static Uri BaseUrl(UrlHelper urlHelper)
        {
            var baseUrl = ""; //ConfigurationManager.AppSettings[BASE_URL_KEY];

            //No configuration given, so use the one from the context
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                if (urlHelper.RequestContext?.HttpContext?.Request.Url != null)
                    baseUrl = urlHelper.RequestContext.HttpContext.Request.Url.GetLeftPart(UriPartial.Authority);
            }

            return new Uri(baseUrl);
        }

    }
}
