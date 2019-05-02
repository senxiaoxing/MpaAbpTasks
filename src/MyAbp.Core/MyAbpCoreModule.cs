using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using MyAbp.Authorization.Roles;
using MyAbp.Authorization.Users;
using MyAbp.Configuration;
using MyAbp.Localization;
using MyAbp.MultiTenancy;
using MyAbp.Timing;

namespace MyAbp
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class MyAbpCoreModule : AbpModule
    {
        //預初始化
        //当应用第一次启动的时候，会首先调用这个方法，这个方法是在依赖注入之前，可以在这个方法中自定义启动类
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            MyAbpLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = MyAbpConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        //初始化
        //大多是将一些类库注入到容器中去
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyAbpCoreModule).GetAssembly());
        }

        //提交初始化內容
        //用来解析依赖关系
        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
