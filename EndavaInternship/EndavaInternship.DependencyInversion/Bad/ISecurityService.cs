using System;

namespace EndavaInternship.DependencyInversion.Bad
{
    public interface ISecurityService
    {
        void ChangeUsersPassword(Guid userId, string newPassword);
    }
}