using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Login.Dto
{
    [AutoMapFrom(typeof(CXD.Entities.CUser))]
  public  class LoginListDto : Entity<int>
    {
        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }
    }
}
