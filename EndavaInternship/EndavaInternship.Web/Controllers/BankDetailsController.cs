using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using EndavaInternship.Api.Client;
using EndavaInternship.Web.Models;

namespace EndavaInternship.Web.Controllers
{
    public class BankDetailsController : Controller
    {
        private readonly BankDetailsApi _bankDetailsApi;

        public BankDetailsController()
        {
            _bankDetailsApi = new BankDetailsApi();
        }


        private static IEnumerable<string> UsersIds
        {
            get { return HomeController.Users.Select(x => x.Key).ToList(); }
        }

        public async Task<ActionResult> Index()
        {
            var list = new List<UserBankDetailsModel>();

            foreach (var userId in UsersIds)
                try
                {
                    var bankDetails = await _bankDetailsApi.Get(userId);

                    list.Add(new UserBankDetailsModel
                    {
                        UserId = userId,
                        CardNumber = bankDetails.CardNumber,
                        FullName = bankDetails.FullName,
                        SecurityCode = bankDetails.SecurityCode
                    });
                }
                catch (Exception)
                {
                    list.Add(new UserBankDetailsModel
                    {
                        UserId = userId,
                        CardNumber = "No bank details!"
                    });
                }

            ViewData["BankDetails"] = list;

            return View();
        }

        [HttpPost]
        public ActionResult Create(UserBankDetailsModel model)
        {
            return RedirectToAction("Index");
        }
    }
}