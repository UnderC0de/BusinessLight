namespace BusinessLight.PhoneBook.Api.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Web.Http.Description;

    using BusinessLight.Paging;
    using BusinessLight.PhoneBook.Dto;
    using BusinessLight.PhoneBook.Dto.Filters;
    using BusinessLight.PhoneBook.Service;

    using FluentValidation;

    using Swashbuckle.Swagger.Annotations;

    [EnableCors("*", "*", "*")]
    public class ContactController : ApiController
    {
        private readonly ContactApplicationService contactApplicationService;

        public ContactController(ContactApplicationService contactApplicationService)
        {
            if (contactApplicationService == null)
            {
                throw new ArgumentNullException(nameof(contactApplicationService));
            }

            this.contactApplicationService = contactApplicationService;
        }

        [HttpGet]
        [ResponseType(typeof(ContactDetailDto))]
        public HttpResponseMessage Get(Guid id)
        {
            var contactDetail = this.contactApplicationService.GetDetail(id);
            return contactDetail == null ? this.Request.CreateResponse(HttpStatusCode.NoContent) : this.Request.CreateResponse(HttpStatusCode.OK, contactDetail);
        }

        [HttpPost]
        [ResponseType(typeof(IPagedList<ContactDto>))]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IPagedList<ContactDto>))]
        public HttpResponseMessage Search(SearchContactDto searchContactDto)
        {
            try
            {
                var searchResult = this.contactApplicationService.Search(searchContactDto);
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
                this.contactApplicationService.CreateContact(contact);
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
                this.contactApplicationService.UpdateContact(contact);
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
                this.contactApplicationService.DeleteContact(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
