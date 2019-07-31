using System.Threading.Tasks;
using Abp.Application.Services;
using MyABPProject.Authorization.Accounts.Dto;

namespace MyABPProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
