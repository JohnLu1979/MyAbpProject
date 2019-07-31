using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyABPProject.Configuration.Dto;

namespace MyABPProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyABPProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
