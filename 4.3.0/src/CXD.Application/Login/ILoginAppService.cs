using Abp.Application.Services;
using CXD.Base.Dto;
using CXD.Login.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Login
{
   public interface ILoginAppService : IApplicationService
    {
        CDataResults<LoginListDto> Login(LoginInput input);
    }
}
