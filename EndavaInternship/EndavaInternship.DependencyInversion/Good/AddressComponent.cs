using System;
using EndavaInternship.OpenClosed.Good;

namespace EndavaInternship.DependencyInversion.Good
{
    public class AddressComponent
    {
        private readonly ILogger _consoleLogger;

        public AddressComponent(ILogger consoleLogger)
        {
            _consoleLogger = consoleLogger;
        }

        public void ChangePostalCode(Guid id, string postalCode)
        {
            _consoleLogger.WriteLog($"user {id} changed postal code");
        }
    }
}