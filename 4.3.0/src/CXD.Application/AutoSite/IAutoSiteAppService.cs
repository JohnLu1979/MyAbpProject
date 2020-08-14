using Abp.Application.Services;
using CXD.Base.Dto;
using CXD.VaisalaAWS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.AutoSite
{
    public interface IAutoSiteAppService : IApplicationService
    {
        Task<CDataResults<VaisalaAWSListDto>> GetAutoSiteDataByToday();
        Task<CDataResult<VaisalaAWSListDto>> GetLastAutoSiteByToday();
    }
}
