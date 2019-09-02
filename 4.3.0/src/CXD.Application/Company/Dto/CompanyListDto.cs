using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Company.Dto
{
    [AutoMapFrom(typeof(CXD.Entities.CCompany))]
    public class CompanyListDto : FullAuditedEntity<int>
    {
        public virtual string CompanyName { get; set; }
        public virtual string CompanyAddress { get; set; }
        public virtual string Contactor { get; set; }
        public virtual string Mobile { get; set; }
    }
}
