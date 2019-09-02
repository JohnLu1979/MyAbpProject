using CXD.Base.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Account.DTO
{
    public class AccountInput : CBaseInput
    {

        public virtual string searchContent { get; set; }
        public virtual int CompanyId { get; set; }

        public virtual string UserName { get; set; }
        public virtual string Account { get; set; }

        public virtual string Password { get; set; }

        public virtual string IMEICode { get; set; }
        public virtual string IsActivated { get; set; }
    }
}
