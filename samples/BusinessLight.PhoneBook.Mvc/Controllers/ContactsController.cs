namespace BusinessLight.PhoneBook.Mvc.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using BusinessLight.PhoneBook.Dto;
    using BusinessLight.PhoneBook.Mvc.Extensions;
    using BusinessLight.PhoneBook.Mvc.ViewModels;
    using BusinessLight.PhoneBook.Service;

    using FluentValidation;

    public class ContactsController : Controller
    {
        private readonly ContactApplicationService contactApplicationService;

        public ContactsController(ContactApplicationService contactApplicationService)
        {
            if (contactApplicationService == null)
            {
                throw new ArgumentNullException(nameof(contactApplicationService));
            }

            this.contactApplicationService = contactApplicationService;
        }

        public ActionResult Index()
        {
            return View(new SearchContactViewModel());
        }

        [HttpPost]
        public ActionResult Index(SearchContactViewModel searchContactViewModel)
        {
            try
            {
                searchContactViewModel.PagedResult = this.contactApplicationService.Search(searchContactViewModel.PagedFilter);
            }
            catch (ValidationException ex)
            {
                ModelState.AddValidationErrors(ex);
            }

            return View(searchContactViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactDetailDto contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.contactApplicationService.CreateContact(contact);
                    return RedirectToAction("Index");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddValidationErrors(ex);
                }
            }

            return View(contact);
        }

        public ActionResult Edit(Guid id)
        {
            var contactDetail = this.contactApplicationService.GetDetail(id);
            if (contactDetail == null)
            {
                return HttpNotFound();
            }
            return View(contactDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactDetailDto contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.contactApplicationService.UpdateContact(contact);
                    return RedirectToAction("Index");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddValidationErrors(ex);
                }
            }

            contact.ContactInfos = this.contactApplicationService.GetContactInfosForContact(contact.Id).ToList();
            return View(contact);
        }

        public ActionResult Delete(Guid id)
        {
            var contactDetail = this.contactApplicationService.GetDetail(id);
            if (contactDetail == null)
            {
                return HttpNotFound();
            }
            return View(contactDetail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            this.contactApplicationService.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}
