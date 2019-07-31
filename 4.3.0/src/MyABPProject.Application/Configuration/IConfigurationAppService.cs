using System.Threading.Tasks;
using Abp.Application.Services;
using MyABPProject.Configuration.Dto;

namespace MyABPProject.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}