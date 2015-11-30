using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLight.PhoneBook.Dto.Filters;
using BusinessLight.PhoneBook.Service;
using BusinessLight.Validation;

namespace BusinessLight.PhoneBook.Api.Controllers
{
    public class ContactController : ApiController
    {
        private readonly ContactCrudService _contactCrudService;

        public ContactController(ContactCrudService contactCrudService)
        {
            if (contactCrudService == null)
            {
                throw new ArgumentNullException("contactCrudService");
            }

            _contactCrudService = contactCrudService;
        }

        [HttpPost]
        public HttpResponseMessage Search([FromBody]SearchContactDto searchContactDto)
        {
            try
            {
                var searchResult = _contactCrudService.Search(searchContactDto);
                return Request.CreateResponse(HttpStatusCode.OK, searchResult);
            }
            catch (ValidationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
