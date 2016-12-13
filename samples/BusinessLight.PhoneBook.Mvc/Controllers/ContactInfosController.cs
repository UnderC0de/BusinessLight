namespace BusinessLight.PhoneBook.Mvc.Controllers
{
    using System;
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
        public ActionResult Create(ContactInfoDetailDto contactInfoDetailDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.contactApplicationService.CreateContactInfo(contactInfoDetailDto);
                    return RedirectToAction("Edit", "Contacts", new { id = contactInfoDetailDto.ContactId });
                }
                catch (ValidationException ex)
                {
                    ModelState.AddValidationErrors(ex);
                }
            }

            return View(contactInfoDetailDto);
        }

        public ActionResult Edit(Guid id)
        {
            var contactInfoDetail = this.contactApplicationService.GetContactInfo(id);
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
                    this.contactApplicationService.UpdateContactInfo(contactInfoDetailDto);
                    return RedirectToAction("Edit", "Contacts", new { id = contactInfoDetailDto.ContactId });
                }
                catch (ValidationException ex)
                {
                    ModelState.AddValidationErrors(ex);
                }
            }
            return View(contactInfoDetailDto);
        }

        public ActionResult Delete(Guid id)
        {
            var contactInfoDetail = this.contactApplicationService.GetContactInfo(id);
            if (contactInfoDetail == null)
            {
                return HttpNotFound();
            }

            return View(contactInfoDetail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            this.contactApplicationService.DeleteContactInfo(id);
            return RedirectToAction("Index", "Contacts");
        }
    }
}