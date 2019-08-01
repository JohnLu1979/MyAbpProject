using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CXD.Authorization.Users;
using CXD.Users;

namespace CXD.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
