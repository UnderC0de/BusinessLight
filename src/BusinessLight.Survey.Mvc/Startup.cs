using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusinessLight.Survey.Mvc.Startup))]
namespace BusinessLight.Survey.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
