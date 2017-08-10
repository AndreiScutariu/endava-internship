using System;

namespace EndavaInternship.Api.BusinessLogicLayer.Exceptions
{
    public class ResourceAlreadyExistException : Exception
    {
        public ResourceAlreadyExistException(string message) : base(message)
        {
        }
    }
}