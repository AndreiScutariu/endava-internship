using System.Web.Mvc;
using EndavaInternship.Web.Models;

namespace EndavaInternship.Web.Controllers
{
    public class BankDetailsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserBankDetailsModel model)
        {
            return RedirectToAction("Index");
        }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserBankDetailsModel model)
        {
            return RedirectToAction("Index");
        }
    }
}