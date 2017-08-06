using System;
using EndavaInternship.OpenClosed.Good;

namespace EndavaInternship.DependencyInversion.Bad
{
    public class SecurityService : ISecurityService
    {
        private readonly ILogger _logger;

        public SecurityService()
        {
            _logger = new ConsoleLogger();
        }

        public void ChangeUsersPassword(Guid userId, string newPassword)
        {
            _logger.WriteLog($"user with id {userId} changed password with {newPassword}.");
        }
    }
}