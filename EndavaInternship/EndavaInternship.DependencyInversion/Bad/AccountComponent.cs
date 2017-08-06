using System;

namespace EndavaInternship.DependencyInversion.Bad
{
    public class AccountComponent
    {
        private readonly SecurityService _securityService;

        public AccountComponent()
        {
            _securityService = new SecurityService();
        }

        public void ChangePassword(Guid userId, string newPassword)
        {
            _securityService.ChangeUsersPassword(userId, newPassword);
        }
    }
}