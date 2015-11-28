using System;
using System.Web.Mvc;
using BusinessLight.PhoneBook.Dto.Filters;
using BusinessLight.PhoneBook.Mvc.ViewModels;
using BusinessLight.PhoneBook.Service;


namespace BusinessLight.PhoneBook.Mvc.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            if (contactService == null)
            {
                throw new ArgumentNullException(nameof(contactService));
            }

            _contactService = contactService;
        }

        public ActionResult Index()
        {
            var searchContactDto = new SearchContactDto();
            var pagedList = _contactService.Search(searchContactDto);
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
            searchContactViewModel.PagedResult = _contactService.Search(searchContactViewModel.SearchContactDto);
            return View(searchContactViewModel);
        }

        //// GET: Contacts/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Contact contact = db.Contacts.Find(id);
        //    if (contact == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contact);
        //}

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Contacts/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Contact contact)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    contact.Id = Guid.NewGuid();
        //    //    db.Contacts.Add(contact);
        //    //    db.SaveChanges();
        //    //    return RedirectToAction("Index");
        //    //}

        //    return View(contact);
        //}

        //// GET: Contacts/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Contact contact = db.Contacts.Find(id);
        //    if (contact == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contact);
        //}

        //// POST: Contacts/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,BirthDate,Note")] Contact contact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(contact).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(contact);
        //}

        //// GET: Contacts/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Contact contact = db.Contacts.Find(id);
        //    if (contact == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contact);
        //}

        //// POST: Contacts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    Contact contact = db.Contacts.Find(id);
        //    db.Contacts.Remove(contact);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
