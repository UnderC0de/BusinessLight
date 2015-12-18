using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BusinessLight.Mapping.AutoMapper;
using BusinessLight.PhoneBook.Mapping;

namespace BusinessLight.PhoneBook.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            AutoMapperConfiguration.Configure(typeof(SearchContactDtoToSearchContactFilterProfile).Assembly);
            UnityConfig.RegisterComponents();                           
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
