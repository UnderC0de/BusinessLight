namespace BusinessLight.PhoneBook.Api
{
    using System.Data.Entity;
    using System.Web.Http;

    using BusinessLight.Data;
    using BusinessLight.Data.EntityFramework;
    using BusinessLight.PhoneBook.Data;
    using BusinessLight.PhoneBook.Service;

    using Microsoft.Practices.Unity;

    using Unity.WebApi;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUnitOfWorkFactory, EntityFrameworkUnitOfWorkFactory>();
            container.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>();
            container.RegisterType<DbContext, PhoneBookDbContext>();
            container.RegisterType<ContactApplicationService, ContactApplicationService>();
            //container.RegisterType<IMapper, AutoMapperMapping>();
            //container.RegisterType<IValidationFactory, UnityValidationFactory>();
            //container.RegisterType<IValidator<SearchContactSpecification>, SearchContactFilterValidator>();
            //container.RegisterType<IValidator<Contact>, ContactValidator>();
            //container.RegisterType<IValidator<ContactInfo>, ContactInfoValidator>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}