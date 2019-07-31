using System.Threading.Tasks;
using Abp.Application.Services;
using MyABPProject.Sessions.Dto;

namespace MyABPProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
