using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using BusinessLight.Data;
using BusinessLight.Data.EntityFramework;
using BusinessLight.Data.Unity;
using BusinessLight.Mapping;
using BusinessLight.Mapping.AutoMapper;
using BusinessLight.PhoneBook.Data;
using BusinessLight.PhoneBook.Domain;
using BusinessLight.PhoneBook.Service;
using BusinessLight.PhoneBook.Service.Filters;
using BusinessLight.PhoneBook.Validation;
using BusinessLight.Validation;
using BusinessLight.Validation.Unity;
using Unity.WebApi;

namespace BusinessLight.PhoneBook.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUnitOfWorkFactory, UnityUnitOfWorkFactory>();
            container.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>();
            container.RegisterType<DbContext, PhoneBookDbContext>();
            container.RegisterType<ContactCrudService, ContactCrudService>();
            container.RegisterType<IMapper, AutoMapperMapping>();
            container.RegisterType<IValidationFactory, UnityValidationFactory>();
            container.RegisterType<IValidator<SearchContactFilter>, SearchContactFilterValidator>();
            container.RegisterType<IValidator<Contact>, ContactValidator>();
            container.RegisterType<IValidator<ContactInfo>, ContactInfoValidator>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}