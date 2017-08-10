using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using EndavaInternship.Api.Contract;
using EndavaInternship.Api.Wrapper;
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
            {
                var bankDetails = await _bankDetailsApi.GetAsync(userId);

                if (bankDetails == null)
                {
                    list.Add(new UserBankDetailsModel
                    {
                        UserId = userId,
                        CardNumber = "",
                        FullName = "No bank details",
                        SecurityCode = ""
                    });
                }
                else
                {
                    list.Add(new UserBankDetailsModel
                    {
                        UserId = userId,
                        CardNumber = bankDetails.CardNumber,
                        FullName = bankDetails.FullName,
                        SecurityCode = bankDetails.SecurityCode
                    });
                }

               
            }

            ViewData["BankDetails"] = list;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(UserBankDetailsModel model)
        {
            await _bankDetailsApi.AddAsync(new CreateUserBankDetailsRequest
            {
                UserId = model.UserId,
                FullName = model.FullName,
                SecurityCode = model.SecurityCode,
                CardNumber = model.CardNumber
            });

            return RedirectToAction("Index");
        }
    }
}