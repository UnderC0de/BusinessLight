using System;
using System.Data.Entity;
using BusinessLight.Data;
using BusinessLight.Data.EntityFramework;
using BusinessLight.Mapping;
using BusinessLight.Mapping.AutoMapper;
using BusinessLight.PhoneBook.Data;
using BusinessLight.PhoneBook.Domain;
using BusinessLight.PhoneBook.Service;
using BusinessLight.PhoneBook.Service.Filters;
using BusinessLight.PhoneBook.Validation;
using BusinessLight.Validation;
using BusinessLight.Validation.Unity;
using Microsoft.Practices.Unity;

namespace BusinessLight.PhoneBook.Mvc
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static readonly Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ContactCrudService, ContactCrudService>();
            container.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>();
            container.RegisterType<DbContext, PhoneBookDbContext>();
            container.RegisterType<IMapper, AutoMapperMapping>();
            container.RegisterType<IValidationFactory, UnityValidationFactory>();
            container.RegisterType<IValidator<SearchContactFilter>, SearchContactFilterValidator>();
            container.RegisterType<IValidator<Contact>, ContactValidator>();
            container.RegisterType<IValidator<ContactInfo>, ContactInfoValidator>();
        }
    }
}
