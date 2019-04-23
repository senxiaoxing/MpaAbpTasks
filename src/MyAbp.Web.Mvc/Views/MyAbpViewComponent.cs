using Abp.AspNetCore.Mvc.ViewComponents;

namespace MyAbp.Web.Views
{
    public abstract class MyAbpViewComponent : AbpViewComponent
    {
        protected MyAbpViewComponent()
        {
            LocalizationSourceName = MyAbpConsts.LocalizationSourceName;
        }
    }
}
