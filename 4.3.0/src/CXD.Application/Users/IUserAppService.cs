using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CXD.Roles.Dto;
using CXD.Users.Dto;

namespace CXD.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}