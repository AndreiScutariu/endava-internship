using System;

namespace EndavaInternship.DependencyInversion.Good
{
    public class AccountComponent
    {
        private readonly ISecurityService _securityService;

        public AccountComponent(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        public void ChangePassword(Guid userId, string newPassword)
        {
            _securityService.ChangeUsersPassword(userId, newPassword);
        }
    }
}