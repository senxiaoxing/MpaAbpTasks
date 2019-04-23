using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyAbp.Authorization;

namespace MyAbp
{
    [DependsOn(
        typeof(MyAbpCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyAbpApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyAbpAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyAbpApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
