using System;

namespace EndavaInternship.DependencyInversion.Good
{
    public interface ISecurityService
    {
        void ChangeUsersPassword(Guid userId, string newPassword);
    }
}