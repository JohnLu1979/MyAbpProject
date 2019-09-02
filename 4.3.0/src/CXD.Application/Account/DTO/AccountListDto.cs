using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Account.DTO
{
    [AutoMapFrom(typeof(CXD.Entities.CAccount))]

    public class AccountListDto : FullAuditedEntity<int>
    {
        public virtual int CompanyId { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Account { get; set; }

        public virtual string Password { get; set; }

        public virtual string IMEICode { get; set; }
        public virtual string IsActivated { get; set; }
    }
}
