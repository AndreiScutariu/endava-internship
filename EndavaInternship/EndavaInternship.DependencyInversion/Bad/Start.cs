using System;

namespace EndavaInternship.DependencyInversion.Bad
{
    public class Program
    {
        public static void Start(string[] args)
        {
            var accountController = new AccountComponent();
            accountController.ChangePassword(Guid.NewGuid(), "new pass");
        }
    }
}