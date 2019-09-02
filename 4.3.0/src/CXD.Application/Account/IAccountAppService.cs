using Abp.Application.Services;
using CXD.Account.DTO;
using CXD.Base.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Account
{
    public interface IAccountAppService : IApplicationService
    {
        Task<CDataResults<AccountListDto>> GetAll(AccountInput input);
        CDataResult<AccountListDto> GetDetail(AccountInput input);
        CDataResult<AccountListDto> Update(AccountInput input);
        CDataResult<int> Add(AccountInput input);
        CDataResult<int> Delete(AccountInput input);
        CDataResult<int> ChangePassword(AccountInput input);
        CDataResult<AccountListDto> ChangeStatus(AccountInput input);
        CDataResults<AccountListDto> MobileLogin(AccountInput input);

    }
}
