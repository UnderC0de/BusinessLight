namespace BusinessLight.PhoneBook.Mvc.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using BusinessLight.PhoneBook.Dto;
    using BusinessLight.PhoneBook.Mvc.Extensions;
    using BusinessLight.PhoneBook.Service;

    using FluentValidation;

    public class ContactInfosController : Controller
    {
        private readonly ContactApplicationService contactApplicationService;

        public ContactInfosController(ContactApplicationService contactApplicationService)
        {
            if (contactApplicationService == null)
            {
                throw new ArgumentNullException(nameof(contactApplicationService));
            }

            this.contactApplicationService = contactApplicationService;
        }

        public ActionResult Create(Guid contactId)
        {
            var contactInfoDetailDto = new ContactInfoDetailDto
            {
                ContactId = contactId
            };
            return View(contactInfoDetailDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContactInfoDetailDto contactInfoDetailDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this.contactApplicationService.CreateContactInfoAsync(contactInfoDetailDto);
                    return RedirectToAction("Edit", "Contacts", new { id = contactInfoDetailDto.ContactId });
                }
                catch (ValidationException ex)
                {
                    ModelState.AddValidationErrors(ex);
                }
            }

            return View(contactInfoDetailDto);
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var contactInfoDetail = await this.contactApplicationService.GetContactInfoAsync(id);
            if (contactInfoDetail == null)
            {
                return HttpNotFound();
            }
            return View(contactInfoDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactInfoDetailDto contactInfoDetailDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.contactApplicationService.UpdateContactInfoAsync(contactInfoDetailDto);
                    return RedirectToAction("Edit", "Contacts", new { id = contactInfoDetailDto.ContactId });
                }
                catch (ValidationException ex)
                {
                    ModelState.AddValidationErrors(ex);
                }
            }
            return View(contactInfoDetailDto);
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var contactInfoDetail = await this.contactApplicationService.GetContactInfoAsync(id);
            if (contactInfoDetail == null)
            {
                return HttpNotFound();
            }

            return View(contactInfoDetail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            await this.contactApplicationService.DeleteContactInfoAsync(id);
            return RedirectToAction("Index", "Contacts");
        }
    }
}