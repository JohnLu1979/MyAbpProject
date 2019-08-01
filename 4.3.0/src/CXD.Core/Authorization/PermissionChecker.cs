using Abp.Authorization;
using CXD.Authorization.Roles;
using CXD.Authorization.Users;

namespace CXD.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
