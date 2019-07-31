using Abp.AutoMapper;
using MyABPProject.Sessions.Dto;

namespace MyABPProject.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}