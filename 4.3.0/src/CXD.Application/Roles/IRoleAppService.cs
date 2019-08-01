using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CXD.Roles.Dto;

namespace CXD.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
