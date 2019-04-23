using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace MyAbp.Web.Views
{
    public abstract class MyAbpRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MyAbpRazorPage()
        {
            LocalizationSourceName = MyAbpConsts.LocalizationSourceName;
        }
    }
}
