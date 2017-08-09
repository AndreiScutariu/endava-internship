using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EndavaInternship.Api.BusinessLogic.BankDetails;
using EndavaInternship.Api.Contracts;
using EndavaInternship.Api.Persistence;

namespace EndavaInternship.Api.Controllers
{
    [RoutePrefix("bankdetails")]
    public class BankDetailsController : ApiController
    {
        private readonly BankDetailsHandler _bankDetailsHandler;

        public BankDetailsController()
        {
            _bankDetailsHandler = new BankDetailsHandler(new BankDetailsRepository());
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(string id)
        {
            var bankDetails = _bankDetailsHandler.GetBankDetails(id);
            return Request.CreateResponse(HttpStatusCode.OK, bankDetails);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody] CreateUserBankDetailsRequest createUserBankDetailsRequest)
        {
            try
            {
                _bankDetailsHandler.AddBankDetails(createUserBankDetailsRequest.UserId, new BankDetails
                {
                    CardNumber = createUserBankDetailsRequest.CardNumber,
                    FullName = createUserBankDetailsRequest.FullName,
                    SecurityCode = createUserBankDetailsRequest.SecurityCode
                });
            }
            catch (InvalidOperationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}