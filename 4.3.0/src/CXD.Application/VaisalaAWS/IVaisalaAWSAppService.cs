using Abp.Application.Services;
using CXD.Base.Dto;
using CXD.vaisala_wxt536_view.Dto;
using CXD.VaisalaAWS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.VaisalaAWS
{
    public interface IVaisalaAWSAppService : IApplicationService
    {
        Task<CDataResults<VaisalaAWSTaListDto>> GetVaisalaAWSTaByToday();
        Task<CDataResults<VaisalaAWSTaListDto>> GetVaisalaAWSTaByMonth();
        Task<CDataResult<VaisalaAWSTaShelfDto>> GetVaisalaAWSTaShelfByToday();
    }
}
