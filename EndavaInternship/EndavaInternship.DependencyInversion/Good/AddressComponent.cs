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

        public void ChangePostalCode(Guid newGuid, string s)
        {
            _consoleLogger.WriteLog("change postal code");
        }
    }
}