using System.Threading.Tasks;
using Abp.Application.Services;
using CXD.Sessions.Dto;

namespace CXD.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
