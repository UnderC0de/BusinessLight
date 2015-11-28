using System.Web.Mvc;

namespace BusinessLight.PhoneBook.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}