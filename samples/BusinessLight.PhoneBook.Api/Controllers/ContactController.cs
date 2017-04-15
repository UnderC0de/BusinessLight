namespace BusinessLight.PhoneBook.Api.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
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
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            var contactDetail = await this.contactApplicationService.GetDetailAsync(id);
            return contactDetail == null ? this.Request.CreateResponse(HttpStatusCode.NoContent) : this.Request.CreateResponse(HttpStatusCode.OK, contactDetail);
        }

        [HttpPost]
        [ResponseType(typeof(IPagedList<ContactDto>))]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IPagedList<ContactDto>))]
        public async Task<HttpResponseMessage> Search(SearchContactDto searchContactDto)
        {
            try
            {
                var searchResult = this.contactApplicationService.SearchAsync(searchContactDto);
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
        public async Task<HttpResponseMessage> Create(ContactDetailDto contact)
        {
            try
            {
                await this.contactApplicationService.CreateContactAsync(contact);
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
        public async Task<HttpResponseMessage> Update(ContactDetailDto contact)
        {
            try
            {
                await this.contactApplicationService.UpdateContactAsync(contact);
                return Request.CreateResponse(HttpStatusCode.OK, contact);
            }
            catch (ValidationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                await this.contactApplicationService.DeleteContactAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ValidationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
