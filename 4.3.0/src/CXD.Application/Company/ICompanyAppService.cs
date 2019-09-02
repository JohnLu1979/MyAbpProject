using Abp.Application.Services;
using CXD.Base.Dto;
using CXD.Company.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Company
{
   public interface ICompanyAppService: IApplicationService
    {
        Task<CDataResults<CompanyListDto>> GetAll(CompanyInput input);
        CDataResult<CompanyListDto> GetCompanyDetail(CompanyInput input);
        CDataResult<CompanyListDto> UpdateCompany(CompanyInput input);
        CDataResult<int> AddCompany(CompanyInput input);
        CDataResult<int> CompanyDelete(CompanyInput input);
    }
}
