using Abp.Authorization;
using MyABPProject.Authorization.Roles;
using MyABPProject.Authorization.Users;

namespace MyABPProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
