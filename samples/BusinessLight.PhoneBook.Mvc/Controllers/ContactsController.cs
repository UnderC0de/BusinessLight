using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using BusinessLight.PhoneBook.Dto;
using BusinessLight.PhoneBook.Dto.Filters;
using BusinessLight.PhoneBook.Mvc.ViewModels;
using BusinessLight.PhoneBook.Service;


namespace BusinessLight.PhoneBook.Mvc.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactCrudService _contactCrudService;

        public ContactsController(ContactCrudService contactCrudService)
        {
            if (contactCrudService == null)
            {
                throw new ArgumentNullException("contactCrudService");
            }

            _contactCrudService = contactCrudService;
        }

        public ActionResult Index()
        {
            var searchContactDto = new SearchContactDto();
            var pagedList = _contactCrudService.Search(searchContactDto);
            var searchContactViewModel = new SearchContactViewModel
            {
                SearchContactDto = searchContactDto,
                PagedResult = pagedList
            };
            return View(searchContactViewModel);
        }

        [HttpPost]
        public ActionResult Index(SearchContactViewModel searchContactViewModel)
        {
            searchContactViewModel.PagedResult = _contactCrudService.Search(searchContactViewModel.SearchContactDto);
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
                _contactCrudService.CreateContact(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        public ActionResult Edit(Guid id)
        {
            var contactDetail = _contactCrudService.GetDetail(id);
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
                _contactCrudService.UpdateContact(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public ActionResult Delete(Guid id)
        {
            var contactDetail = _contactCrudService.GetDetail(id);
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
            _contactCrudService.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}
