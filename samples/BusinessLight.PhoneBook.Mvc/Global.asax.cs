using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BusinessLight.Mapping.AutoMapper;
using BusinessLight.PhoneBook.Data;
using BusinessLight.PhoneBook.Mapping;

namespace BusinessLight.PhoneBook.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            AutoMapperConfiguration.Configure(typeof(SearchContactDtoToSearchContactFilterProfile).Assembly);
            Database.SetInitializer(new PhoneBookDbContextSeedInitializer());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
