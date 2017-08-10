using System.Net;
using System.Net.Http;
using System.Web.Http;
using EndavaInternship.Api.BusinessLogicLayer;
using EndavaInternship.Api.BusinessLogicLayer.Exceptions;
using EndavaInternship.Api.Contract;
using EndavaInternship.Api.Dal;

namespace EndavaInternship.Api.Controllers
{
    [RoutePrefix("bankdetails")]
    public class BankDetailsController : ApiController
    {
        private readonly BankDetailsHanlder _bankDetailsHanlder;

        public BankDetailsController()
        {
            var session = NHibernateSessionFactoryInstance.SessionFactory.OpenSession();
            _bankDetailsHanlder = new BankDetailsHanlder(new BankDetailsRepository(session));
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(string id)
        {
            try
            {
                var details = _bankDetailsHanlder.Get(id);
                return Request.CreateResponse(HttpStatusCode.Found, new UserBankDetailsResponse
                {
                    SecurityCode = details.SecurityCode,
                    FullName = details.FullName,
                    CardNumber = details.CardNumber
                });
            }
            catch (ResourceNotFoundException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody] CreateUserBankDetailsRequest createUserBankDetailsRequest)
        {
            try
            {
                _bankDetailsHanlder.Add(createUserBankDetailsRequest.UserId, new BankDetails
                {
                    CardNumber = createUserBankDetailsRequest.CardNumber,
                    SecurityCode = createUserBankDetailsRequest.SecurityCode,
                    FullName = createUserBankDetailsRequest.FullName
                });

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (ResourceAlreadyExistException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (InvalidBankDetailsException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}