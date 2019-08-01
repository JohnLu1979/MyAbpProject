using System.Threading.Tasks;
using Abp.Application.Services;
using CXD.Configuration.Dto;

namespace CXD.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}