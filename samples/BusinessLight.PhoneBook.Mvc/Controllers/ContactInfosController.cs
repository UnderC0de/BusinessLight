﻿using System;
using System.Web.Mvc;
using BusinessLight.PhoneBook.Dto;
using BusinessLight.PhoneBook.Mvc.Extensions;
using BusinessLight.PhoneBook.Service;
using BusinessLight.Validation;

namespace BusinessLight.PhoneBook.Mvc.Controllers
{
    public class ContactInfosController : Controller
    {
        private readonly ContactApplicationService _contactApplicationService;

        public ContactInfosController(ContactApplicationService contactApplicationService)
        {
            if (contactApplicationService == null)
            {
                throw new ArgumentNullException("contactApplicationService");
            }

            _contactApplicationService = contactApplicationService;
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
                    _contactApplicationService.CreateContactInfo(contactInfoDetailDto);
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
            var contactInfoDetail = _contactApplicationService.GetContactInfo(id);
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
                    _contactApplicationService.UpdateContactInfo(contactInfoDetailDto);
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
            var contactInfoDetail = _contactApplicationService.GetContactInfo(id);
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
            var contactInfoDetail = _contactApplicationService.GetContactInfo(id);
            _contactApplicationService.DeleteContactInfo(id);
            return RedirectToAction("Edit", "Contacts", new { id = contactInfoDetail.ContactId });
        }
    }
}