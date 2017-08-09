using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EndavaInternship.Web.Models;

namespace EndavaInternship.Web.Controllers
{
    public class HomeController : Controller
    {
        public static readonly Dictionary<string, UserModel> Users = new Dictionary<string, UserModel>();

        public ActionResult Index()
        {
            var userModels = Users.Select(x => x.Value).ToList();
            ViewData["Users"] = userModels;

            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            model.UserId = Guid.NewGuid().ToString();
            Users.Add(model.UserId, model);
            return RedirectToAction("Index");
        }
    }
}