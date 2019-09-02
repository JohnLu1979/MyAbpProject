using Abp.Domain.Repositories;
using CXD.Base;
using CXD.Base.Dto;
using CXD.Login;
using CXD.Login.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Login
{
  public  class LoginAppService : CBaseAppService, ILoginAppService
    {
        public readonly IRepository<CXD.Entities.CUser, int> _userRepository;
        public LoginAppService(
            IRepository<CXD.Entities.CUser, int> userRepository
            ) : base()
        {
            this._userRepository = userRepository;
        }

        public CDataResults<LoginListDto> Login(LoginInput input)
        {
            var query = from u in this._userRepository.GetAll().Where(p => p.UserName == input.UserName && p.Password == input.Password)
                        select new LoginListDto
                        {
                            UserName = u.UserName,
                            CompanyId=u.CompanyId,
                            UserType=u.UserType
                        };
            var item = query.ToList();
            var total = item.Count();
            if (total > 0)
            {
                return new CDataResults<LoginListDto>
                {
                    IsSuccess = true,
                    ErrorMessage = null,
                    Data = item,
                    Total = total
                };
            }

            return new CDataResults<LoginListDto>
            {
                IsSuccess = false,
                ErrorMessage = "用户名或密码错误",
                Data = null,
                Total = 0
            };
        }
    }
}
