using Abp.Application.Services;
using CXD.Base.Dto;
using CXD.Current.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Current
{
    public interface ICurrentAppService : IApplicationService
    {
        Task<CDataResult<CurrentDto>> GetCurrentInfo(CurrentInput input);
    }
}
