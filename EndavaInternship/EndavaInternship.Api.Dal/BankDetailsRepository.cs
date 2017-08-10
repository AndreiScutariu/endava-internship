using System;
using System.Collections.Generic;
using System.Linq;
using EndavaInternship.Api.BusinessLogicLayer;
using NHibernate;

namespace EndavaInternship.Api.Dal
{
    public class BankDetailsRepository : IBankDetailsRepository
    {
        public static Dictionary<string, BankDetails> Persister = new Dictionary<string, BankDetails>();
        private readonly ISession _session;

        public BankDetailsRepository(ISession session)
        {
            _session = session;
        }

        public void Save(string userId, BankDetails bankDetails)
        {
            using (var tx = _session.BeginTransaction())
            {
                _session.Save(new BankDetailsEntity
                {
                    FullName = bankDetails.FullName,
                    SecurityCode = bankDetails.SecurityCode,
                    CardNumber = bankDetails.CardNumber,
                    UserId = userId
                });

                tx.Commit();
            }

            //Persister.Add(userId, bankDetails);
        }

        public BankDetails Get(string userId)
        {
            var bankDetailsEntity = _session.Get<BankDetailsEntity>(userId);

            return new BankDetails
            {
                SecurityCode = bankDetailsEntity.SecurityCode,
                FullName = bankDetailsEntity.FullName,
                CardNumber = bankDetailsEntity.CardNumber
            };
        }
    }
}