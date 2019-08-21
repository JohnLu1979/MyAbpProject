using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace CXD.Entities
{
    [Table("zzd_Accounts")]
    public class CAccount : FullAuditedEntity<int>
    {
        [MaxLength(50)]
        public virtual string AccountName { get; set; }
        [MaxLength(50)]
        public virtual string UserName { get; set; }
        [MaxLength(50)]
        public virtual string Password { get; set; }
 
        public virtual string IMEICode { get; set; }

        public virtual string IsActivated { get; set; }

    }
}
