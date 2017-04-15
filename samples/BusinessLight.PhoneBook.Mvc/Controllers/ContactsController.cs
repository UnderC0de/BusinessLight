namespace BusinessLight.PhoneBook.Mvc.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
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
        public async Task<ActionResult> Index(SearchContactViewModel searchContactViewModel)
        {
            try
            {
                searchContactViewModel.PagedResult = await this.contactApplicationService.SearchAsync(searchContactViewModel.PagedFilter);
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
        public async Task<ActionResult> Create(ContactDetailDto contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this.contactApplicationService.CreateContactAsync(contact);
                    return RedirectToAction("Index");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddValidationErrors(ex);
                }
            }

            return View(contact);
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var contactDetail = await this.contactApplicationService.GetDetailAsync(id);
            if (contactDetail == null)
            {
                return HttpNotFound();
            }
            return View(contactDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ContactDetailDto contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this.contactApplicationService.UpdateContactAsync(contact);
                    return RedirectToAction("Index");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddValidationErrors(ex);
                }
            }

            contact.ContactInfos = (await this.contactApplicationService.GetContactInfosForContactAsync(contact.Id)).ToList();
            return View(contact);
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var contactDetail = await this.contactApplicationService.GetDetailAsync(id);
            if (contactDetail == null)
            {
                return HttpNotFound();
            }
            return View(contactDetail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            await this.contactApplicationService.DeleteContactAsync(id);
            return RedirectToAction("Index");
        }
    }
}
