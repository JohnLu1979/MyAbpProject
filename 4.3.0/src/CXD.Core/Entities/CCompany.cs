using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Entities
{
    [Table("Company")]
    public class CCompany: FullAuditedEntity<int>
    {
      
        public virtual string CompanyName { get; set; }
        public virtual string CompanyAddress { get; set; }
        public virtual string Contactor { get; set; }
        public virtual string Mobile { get; set; }
    }
}
