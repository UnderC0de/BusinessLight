using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLight.Paging;
using BusinessLight.PhoneBook.Dto;
using BusinessLight.PhoneBook.Dto.Filters;
using BusinessLight.PhoneBook.Service;
using BusinessLight.Validation;
using Swashbuckle.Swagger.Annotations;

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

        [HttpGet]
        [ResponseType(typeof(ContactDetailDto))]
        public HttpResponseMessage Get(Guid id)
        {
            var contactDetail = _contactCrudService.GetDetail(id);
            if (contactDetail == null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return Request.CreateResponse(HttpStatusCode.OK, contactDetail);
        }

        [HttpPost]
        [ResponseType(typeof(IPagedList<ContactDto>))]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IPagedList<ContactDto>))]
        public HttpResponseMessage Search(SearchContactDto searchContactDto)
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

        [HttpPost]
        [ResponseType(typeof(ContactDetailDto))]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ContactDetailDto))]
        public HttpResponseMessage Create(ContactDetailDto contact)
        {
            try
            {
                _contactCrudService.CreateContact(contact);
                return Request.CreateResponse(HttpStatusCode.Created, contact);
            }
            catch (ValidationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [ResponseType(typeof(ContactDetailDto))]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ContactDetailDto))]
        public HttpResponseMessage Update(ContactDetailDto contact)
        {
            try
            {
                _contactCrudService.UpdateContact(contact);
                return Request.CreateResponse(HttpStatusCode.OK, contact);
            }
            catch (ValidationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                _contactCrudService.DeleteContact(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
