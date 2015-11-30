using System;
using System.Data.Entity;
using BusinessLight.Data.EntityFramework;
using BusinessLight.Mapping.AutoMapper;
using BusinessLight.PhoneBook.Data;
using BusinessLight.PhoneBook.Dto.Filters;
using BusinessLight.PhoneBook.Mapping;
using BusinessLight.PhoneBook.Service;
using BusinessLight.PhoneBook.Validation;
using BusinessLight.Validation;

namespace BusinessLight.PhoneBook.Console
{
    public class Program
    {
        private static ContactCrudService _contactCrudService;
        public static void Main(string[] args)
        {
            try
            {
                BootStrap();

                var searchResult = _contactCrudService.Search(new SearchContactDto
                {
                    FirstName = "name"
                });
                foreach (var contactDto in searchResult.Result)
                {
                    System.Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine("{0} {1}", contactDto.LastName, contactDto.FirstName);
                }
            }
            catch (ValidationException ex)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine(ex);
            }
            System.Console.ReadKey();
        }

        private static void BootStrap()
        {
            AutoMapperConfiguration.Configure(typeof(SearchContactDtoToSearchContactFilterProfile).Assembly);
            Database.SetInitializer(new PhoneBookDbContextSeedInitializer());

            var unitOfWork = new EntityFrameworkUnitOfWork(new PhoneBookDbContext());
            var mapper = new AutoMapperMapping();
            var validationFactory = new ValidationFactory();
            validationFactory.Register(new SearchContactFilterValidator());
            _contactCrudService = new ContactCrudService(unitOfWork, mapper, validationFactory);
        }
    }
}
