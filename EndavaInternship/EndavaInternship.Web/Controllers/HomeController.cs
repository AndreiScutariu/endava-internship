using System.Web.Mvc;
using EndavaInternship.Web.Models;

namespace EndavaInternship.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Create(UserBankDetailsModel model)
        {
            return RedirectToAction("Index");
        }
    }
}