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
        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
        {
            if (contactService == null)
            {
                throw new ArgumentNullException("contactService");
            }

            _contactService = contactService;
        }

        [HttpPost]
        public HttpResponseMessage Search([FromBody]SearchContactDto searchContactDto)
        {
            try
            {
                var searchResult = _contactService.Search(searchContactDto);
                return Request.CreateResponse(HttpStatusCode.OK, searchResult);
            }
            catch (ValidationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
