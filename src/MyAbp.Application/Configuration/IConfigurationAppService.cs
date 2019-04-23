using System.Threading.Tasks;
using MyAbp.Configuration.Dto;

namespace MyAbp.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
