using System.Collections.Generic;
using EndavaInternship.Api.BusinessLogic.BankDetails;

namespace EndavaInternship.Api.Persistence
{
    public class BankDetailsRepository : IBankDetailsRepository
    {
        protected static readonly Dictionary<string, BankDetails> Persister = new Dictionary<string, BankDetails>();

        public void Save(string userId, BankDetails bankDetails)
        {
            Persister.Add(userId, bankDetails);
        }

        public BankDetails Get(string userId)
        {
            return Persister[userId];
        }
    }
}