using System;
using EndavaInternship.OpenClosed.Good;

namespace EndavaInternship.DependencyInversion.Good
{
    public class Program
    {
        public static void Start(string[] args)
        {
            var accountComponent = new AccountComponent(new SecurityService(new ConsoleLogger()));
            var addressComponent = new AddressComponent(new ConsoleLogger());

            accountComponent.ChangePassword(Guid.NewGuid(), "new pass");
            addressComponent.ChangePostalCode(Guid.NewGuid(), "1234");
        }
    }
}