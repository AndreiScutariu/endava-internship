using System;
using System.Collections.Generic;
using EndavaInternship.Api.BusinessLogicLayer.Exceptions;

namespace EndavaInternship.Api.BusinessLogicLayer
{
    public class BankDetailsHanlder
    {
        private readonly IBankDetailsRepository _repository;

        public BankDetailsHanlder(IBankDetailsRepository repository)
        {
            _repository = repository;
        }

        public void Add(string userId, BankDetails bankDetails)
        {
            if (bankDetails.CardNumber == "")
            {
                throw new InvalidBankDetailsException("Card Number is empty");
            }

            try
            {
                _repository.Save(userId, bankDetails);
            }
            catch (ArgumentException)
            {
                throw new ResourceAlreadyExistException($"User {userId} already have bank details");
            }
        }

        public BankDetails Get(string userId)
        {
            try
            {
                var bankDetails = _repository.Get(userId);
                return bankDetails;
            }
            catch (KeyNotFoundException)
            {
                throw new ResourceNotFoundException();
            }
        }
    }
}