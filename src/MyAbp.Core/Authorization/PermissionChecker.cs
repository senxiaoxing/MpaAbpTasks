using Abp.Authorization;
using MyAbp.Authorization.Roles;
using MyAbp.Authorization.Users;

namespace MyAbp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
