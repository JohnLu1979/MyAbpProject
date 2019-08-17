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
    [Table("Notice")]
    public class Notice : CreationAuditedEntity<long> 
    {
        [MaxLength(50)]
        public virtual string Title { get; set; }
        [MaxLength(50)]
        public virtual string NewsAuthor { get; set; }
        public virtual int? DisplayIndex { get; set; }

        public virtual string NewsContent { get; set; }
    }
}
