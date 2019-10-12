using Abp.AutoMapper;
using Abp.Domain.Repositories;
using CXD.Account.DTO;
using CXD.Base;
using CXD.Base.Dto;
using CXD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Account
{
    public class AccountAppService : CBaseAppService, IAccountAppService
    {
        public readonly IRepository<CAccount, int> _accountRepository;
        public AccountAppService(
            IRepository<CAccount, int> accountRepository
            ) : base()
        {
            this._accountRepository = accountRepository;
        }
        public CDataResult<int> Add(AccountInput input)
        {
            var query = this._accountRepository.GetAll().Where(r => r.UserName == input.UserName);
            if (query.Count() > 0)
            {
                return new CDataResult<int>()
                {
                    IsSuccess = false,
                    ErrorMessage = "电话号码已存在！",
                    Data = 0
                };
            }
            var newAccount = new CAccount()
            {
                UserName = input.UserName,
                Password = "111111",
                CompanyId = input.CompanyId,
                Account = input.Account,
                IMEICode = input.IMEICode,
                IsActivated = input.IsActivated
            };

            var newNoticeId = this._accountRepository.InsertAndGetId(newAccount);
            return new CDataResult<int>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = newNoticeId
            };

        }

        public CDataResult<int> ChangePassword(AccountInput input)
        {
            throw new NotImplementedException();
        }

        public CDataResult<int> Delete(AccountInput input)
        {
            this._accountRepository.Delete(input.Id);
            return new CDataResult<int>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = 1
            };
        }

        public Task<CDataResults<AccountListDto>> GetAll(AccountInput input)
        {
            var query = this._accountRepository.GetAll().Where(w => w.CompanyId == input.CompanyId);
            if (!string.IsNullOrWhiteSpace(input.searchContent))
            {
                query = query.Where(p => p.Account.Contains(input.searchContent) || p.UserName.Contains(input.searchContent));
            }
            if (!string.IsNullOrWhiteSpace(input.IsActivated))
            {
                query = query.Where(w => w.IsActivated == input.IsActivated);
            }

            var total = query.Count();
            if (input.pageNumber.HasValue && input.pageNumber.Value > 0 && input.pageSize.HasValue)
            {
                query = query.OrderByDescending(r => r.Id).Take(input.pageSize.Value * input.pageNumber.Value).Skip(input.pageSize.Value * (input.pageNumber.Value - 1));
            }
            var result = query.ToList().MapTo<List<AccountListDto>>();

            return Task.FromResult(new CDataResults<AccountListDto>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = result,
                Total = total
            });
        }

        public CDataResult<AccountListDto> GetDetail(AccountInput input)
        {
            var item = this._accountRepository.Get(input.Id);
            if (item == null)
            {
                return new CDataResult<AccountListDto>()
                {
                    IsSuccess = false,
                    ErrorMessage = null,
                    Data = null
                };
            }
            else
            {
                return new CDataResult<AccountListDto>()
                {
                    IsSuccess = true,
                    ErrorMessage = null,
                    Data = item.MapTo<AccountListDto>()
                };
            }
        }

        public CDataResult<AccountListDto> Update(AccountInput input)
        {
            var result = new CDataResult<AccountListDto>()
            {
                IsSuccess = false,
                ErrorMessage = null,
                Data = null
            };
            var account = this._accountRepository.Get(input.Id);
            if (account == null)
            {
                result.IsSuccess = false;
            }
            else
            {
                account.UserName = input.UserName;
                account.Account = input.Account;
                account.IMEICode = input.IMEICode;
                account.IsActivated = input.IsActivated;
                account.Id = input.Id;
            }

            var updateNotice = this._accountRepository.Update(account);

            if (updateNotice == null)
            {
                result.IsSuccess = false;
            }
            else
            {
                result.IsSuccess = true;
                result.Data = updateNotice.MapTo<AccountListDto>();
            }
            return result;
        }
        public CDataResult<AccountListDto> ChangeStatus(AccountInput input)
        {
            var result = new CDataResult<AccountListDto>()
            {
                IsSuccess = false,
                ErrorMessage = null,
                Data = null
            };
            var account = this._accountRepository.Get(input.Id);
            if (account == null)
            {
                result.IsSuccess = false;
                result.ErrorMessage = "用户启用失败！";
            }
            else
            {
                account.IsActivated = input.IsActivated;
                account.Id = input.Id;
            }
            var updateAccount = this._accountRepository.Update(account);

            if (updateAccount == null)
            {
                result.IsSuccess = false;
                result.ErrorMessage = "用户启用失败！";
            }
            else
            {
                result.IsSuccess = true;
                result.Data = updateAccount.MapTo<AccountListDto>();
            }
            return result;
        }

        public CDataResults<AccountListDto> MobileLogin(AccountInput input)
        {

            var result = new CDataResults<AccountListDto>()
            {
                IsSuccess = false,
                ErrorMessage = "null",
                Data = null,
                Total = 0
            };

            var queryCode = this._accountRepository.GetAll().Where(w => w.IMEICode == input.IMEICode);
            var total = queryCode.Count();
            if (total < 1)
            {
                result.IsSuccess = false;
                result.ErrorMessage = "IMEI码不存在，请联系管理员。";
            }
            else
            {
                var query = from u in this._accountRepository.GetAll().Where(p => p.Account == input.Account && p.Password == input.Password)
                            select new AccountListDto
                            {
                                Id=u.Id,
                                UserName = u.UserName,
                                Account = u.Account,
                                CompanyId = u.CompanyId,
                                IMEICode = u.IMEICode,
                                IsActivated = u.IsActivated
                            };
                var item = query.ToList();
                if (item.Count() > 0)
                {
                    var account = item.Where(w => w.IsActivated == "1").ToList();
                    if (account.Count() > 0)
                    {
                        result.IsSuccess = true;
                        result.ErrorMessage = null;
                        result.Data = item;
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.ErrorMessage = "该账户已被禁用，请联系管理员。";
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "用户名或密码错误。";
                }
            }
            return result;
        }
    }
}

