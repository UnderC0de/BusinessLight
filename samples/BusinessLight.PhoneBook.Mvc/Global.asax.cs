namespace BusinessLight.PhoneBook.Mvc
{
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using BusinessLight.PhoneBook.Data;
    using BusinessLight.PhoneBook.Mapping;
    using BusinessLight.PhoneBook.Mvc.App_Start;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            Database.SetInitializer(new PhoneBookDbContextSeedInitializer());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Configure(typeof(SearchContactDtoToSearchContactFilterProfile).Assembly);
        }
    }
}
