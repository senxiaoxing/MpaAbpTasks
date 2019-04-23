using System.Collections.Generic;
using MyAbp.Roles.Dto;

namespace MyAbp.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}