using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using BusinessLight.PhoneBook.Dto;
using BusinessLight.PhoneBook.Service;
using BusinessLight.Validation;
using Swashbuckle.Swagger.Annotations;

namespace BusinessLight.PhoneBook.Api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ContactInfoController : ApiController
    {
        private readonly ContactCrudService _contactCrudService;

        public ContactInfoController(ContactCrudService contactCrudService)
        {
            if (contactCrudService == null)
            {
                throw new ArgumentNullException("contactCrudService");
            }

            _contactCrudService = contactCrudService;
        }

        [HttpGet]
        [ResponseType(typeof(ContactInfoDetailDto))]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ContactInfoDetailDto))]
        public HttpResponseMessage Get(Guid id)
        {
            var contactDetail = _contactCrudService.GetContactInfo(id);
            if (contactDetail == null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return Request.CreateResponse(HttpStatusCode.OK, contactDetail);
        }


        [HttpPost]
        public HttpResponseMessage Create(ContactInfoDetailDto contact)
        {
            try
            {
                _contactCrudService.CreateContactInfo(contact);
                return Request.CreateResponse(HttpStatusCode.Created, contact);
            }
            catch (ValidationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [ResponseType(typeof(ContactInfoDetailDto))]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ContactInfoDetailDto))]
        public HttpResponseMessage Update(ContactInfoDetailDto contact)
        {
            try
            {
                _contactCrudService.UpdateContactInfo(contact);
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
                _contactCrudService.DeleteContactInfo(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}