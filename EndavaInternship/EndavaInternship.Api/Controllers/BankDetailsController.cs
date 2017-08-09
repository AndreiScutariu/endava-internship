using System.Collections.Generic;
using System.Web.Http;
using EndavaInternship.Api.Models;

namespace EndavaInternship.Api.Controllers
{
    [RoutePrefix("bankdetails")]
    public class BankDetailsController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<UserBankDetails> Get()
        {
            return null;
        }

        [HttpGet]
        [Route("{id}")]
        public UserBankDetails Get(int id)
        {
            return null;
        }

        [HttpPost]
        [Route("")]
        public void Post([FromBody] UserBankDetails userBankDetails)
        {
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(string id)
        {
        }
    }
}