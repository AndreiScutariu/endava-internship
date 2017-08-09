using System;
using System.Collections.Generic;

namespace EndavaInternship.Api.BusinessLogic.BankDetails
{
    public class BankDetailsHandler
    {
        private readonly IBankDetailsRepository _bankDetailsRepository;

        public BankDetailsHandler(IBankDetailsRepository bankDetailsRepository)
        {
            _bankDetailsRepository = bankDetailsRepository;
        }

        public void AddBankDetails(string userId, BankDetails bankDetails)
        {
            if (string.IsNullOrEmpty(bankDetails.CardNumber))
                throw new InvalidOperationException("Card number is empty!");

            try
            {
                _bankDetailsRepository.Save(userId, bankDetails);
            }
            catch (ArgumentException)
            {
                throw new InvalidOperationException("This user already has bank details!");
            }
        }

        public BankDetails GetBankDetails(string userId)
        {
            try
            {
                return _bankDetailsRepository.Get(userId);
            }
            catch (KeyNotFoundException)
            {
                throw new InvalidOperationException("This user not have bank details!");
            }
        }
    }
}