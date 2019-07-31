using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyABPProject.MultiTenancy.Dto;

namespace MyABPProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
