using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CXD.MultiTenancy.Dto;

namespace CXD.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
