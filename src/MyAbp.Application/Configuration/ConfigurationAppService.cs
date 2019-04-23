using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyAbp.Configuration.Dto;

namespace MyAbp.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyAbpAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
