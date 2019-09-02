using Abp.AutoMapper;
using Abp.Domain.Repositories;
using CXD.Base;
using CXD.Base.Dto;
using CXD.Company.Dto;
using CXD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Company
{
    public class CompanyAppService : CBaseAppService, ICompanyAppService
    {
        public readonly IRepository<CCompany, int> _companyRepository;

        public CompanyAppService(IRepository<CCompany, int> companyRepository) : base()
        {
            this._companyRepository = companyRepository;
        }
        public CDataResult<int> AddCompany(CompanyInput input)
        {
            var newCompany = new CCompany()
            {
                CompanyName = input.CompanyName,
                CompanyAddress = input.CompanyAddress,
                Contactor = input.Contactor,
                Mobile = input.Mobile
            };

            var newNoticeId = this._companyRepository.InsertAndGetId(newCompany);
            return new CDataResult<int>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = newNoticeId
            };
        }

        public CDataResult<int> CompanyDelete(CompanyInput input)
        {
            this._companyRepository.Delete(input.Id);
            return new CDataResult<int>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = 1
            };
        }

        public Task<CDataResults<CompanyListDto>> GetAll(CompanyInput input)
        {
            var query = this._companyRepository.GetAll();
            if (input.CompanyName != null)
            {
                query = query.Where(p => p.CompanyName.Contains(input.CompanyName));
            }
            var total = query.Count();
            if (input.pageNumber.HasValue && input.pageNumber.Value > 0 && input.pageSize.HasValue)
            {
                query = query.OrderByDescending(r => r.Id).Take(input.pageSize.Value * input.pageNumber.Value).Skip(input.pageSize.Value * (input.pageNumber.Value - 1));
            }
            var result = query.ToList().MapTo<List<CompanyListDto>>();

            return Task.FromResult(new CDataResults<CompanyListDto>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = result,
                Total = total
            });
        }

        public CDataResult<CompanyListDto> GetCompanyDetail(CompanyInput input)
        {
            var item = this._companyRepository.Get(input.Id);
            if (item == null)
            {
                return new CDataResult<CompanyListDto>()
                {
                    IsSuccess = false,
                    ErrorMessage = null,
                    Data = null
                };
            }
            else
            {
                return new CDataResult<CompanyListDto>()
                {
                    IsSuccess = true,
                    ErrorMessage = null,
                    Data = item.MapTo<CompanyListDto>()
                };
            }
        }

        public CDataResult<CompanyListDto> UpdateCompany(CompanyInput input)
        {
            var result = new CDataResult<CompanyListDto>()
            {
                IsSuccess = false,
                ErrorMessage = null,
                Data = null
            };
            var company = this._companyRepository.Get(input.Id);
            if (company == null)
            {
                result.IsSuccess = false;
            }
            else
            {
                company.CompanyName = input.CompanyName;
                company.CompanyAddress = input.CompanyAddress;
                company.Contactor = input.Contactor;
                company.Mobile = input.Mobile;
                company.Id = input.Id;
            }

            var updateNotice = this._companyRepository.Update(company);

            if (updateNotice == null)
            {
                result.IsSuccess = false;
            }
            else
            {
                result.IsSuccess = true;
                result.Data = updateNotice.MapTo<CompanyListDto>();
            }
            return result;
        }
    }
}
