using System;

namespace EndavaInternship.Api.BusinessLogicLayer.Exceptions
{
    public class InvalidBankDetailsException : Exception
    {
        public InvalidBankDetailsException(string message) : base(message)
        {
        }
    }
}