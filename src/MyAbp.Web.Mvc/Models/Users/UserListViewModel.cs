using System.Collections.Generic;
using MyAbp.Roles.Dto;
using MyAbp.Users.Dto;

namespace MyAbp.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
