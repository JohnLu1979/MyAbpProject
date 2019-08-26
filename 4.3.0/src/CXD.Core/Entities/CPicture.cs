using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Entities
{
   [Table("zzd_Pictures")]
   public class CPicture : FullAuditedEntity<int>
    {
        public virtual string Title { get; set; }
        public virtual string ImgUrl { get; set; }
        public virtual string IsActivated { get; set; }


    }
}
