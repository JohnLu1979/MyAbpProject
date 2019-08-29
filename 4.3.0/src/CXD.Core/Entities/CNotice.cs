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
    [Table("zzd_Notices")]
    public class CNotice : FullAuditedEntity<int> 
    {
        public virtual int CompanyId { get; set; }
        public virtual string Title { get; set; }
        public virtual string NewsAuthor { get; set; }
        public virtual int? DisplayIndex { get; set; }
        public virtual string NewsContent { get; set; }
    }
}
