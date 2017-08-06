using System;
using EndavaInternship.OpenClosed.Good;

namespace EndavaInternship.DependencyInversion.Good
{
    public class Program
    {
        public static void Start()
        {
            var accountController = new AccountComponent(new SecurityService(new ConsoleLogger()));
            accountController.ChangePassword(Guid.NewGuid(), "new pass");
        }
    }
}