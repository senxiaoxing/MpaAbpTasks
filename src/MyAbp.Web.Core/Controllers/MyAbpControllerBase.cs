using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyAbp.Controllers
{
    public abstract class MyAbpControllerBase: AbpController
    {
        protected MyAbpControllerBase()
        {
            LocalizationSourceName = MyAbpConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
